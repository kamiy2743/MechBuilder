using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MB
{
    public partial class PlaceItemProcessor : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        private ItemID _lastItemID = ItemID.EmptyID;
        private PreviewObject _previewObject = new PreviewObject();

        // TODO Unitの調査
        private Subject<Unit> _observable = new Subject<Unit>();

        public PlaceItemProcessor()
        {
            _observable
                .Where(_ => InputProvider.Intance.PlaceItem())
                .ThrottleFirst(System.TimeSpan.FromSeconds(0.5f))
                .Subscribe(_ =>
                {
                    PlaceItem();
                });
        }

        public void Hit(RaycastHit hit)
        {
            var other = hit.collider.GetComponent<IFieldItem>();
            Preview(hit, other);
            _observable.OnNext(new Unit());
        }

        private void Preview(RaycastHit hit, IFieldItem other)
        {
            var itemInhand = PlayerInventory.Instance.ItemInHand;
            if (itemInhand == InventoryItem.Empty) return;

            if (_lastItemID != other.ID)
            {
                _lastItemID = other.ID;
                _previewObject.CopyMeshAndMaterial(itemInhand.ID);
            }

            var otherRotation = hit.collider.transform.rotation;

            _previewObject.SetVisible(true);
            _previewObject.Transform.position = CalcPreviewPosition(hit, itemInhand.ID, other);
            _previewObject.Transform.rotation = otherRotation;
        }

        private Vector3 CalcPreviewPosition(RaycastHit hit, ItemID itemIDInHand, IFieldItem other)
        {
            var normal = hit.normal;
            var hitPoint = hit.point;
            var originalItemInhand = OriginalFieldItems.Instance.GetOriginalData(itemIDInHand);

            var point = Vector3.zero;

            if (InputProvider.Intance.EnableSnap())
            {
                point = other.Collider.CalcNearestSnapPoint(hitPoint);
            }
            else
            {
                point = hitPoint;
            }

            return point + normal * (originalItemInhand.Collider.Size.x * 0.5f);
        }

        private void PlaceItem()
        {
            var itemInhand = PlayerInventory.Instance.ItemInHand;
            if (itemInhand == InventoryItem.Empty) return;

            var position = _previewObject.Transform.position;
            var rotation = _previewObject.Transform.rotation;
            OriginalFieldItems.Instance.Instantiate(itemInhand.ID, position, rotation);
        }
    }
}
