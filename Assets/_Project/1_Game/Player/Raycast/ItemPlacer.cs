using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MB
{
    public partial class ItemPlacer : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        private ItemID _lastItemID = ItemID.EmptyID;
        private PreviewObject _previewObject = new PreviewObject();

        public void Hit(RaycastHit hit)
        {
            var other = hit.collider.GetComponent<IFieldItem>();
            Preview(hit, other);
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

            // TODO InputActionに追加
            if (Keyboard.current.leftCtrlKey.isPressed)
            {
                point = other.Collider.CalcNearestSnapPoint(hitPoint);
            }
            else
            {
                point = hitPoint;
            }

            return point + normal * (originalItemInhand.Collider.Size.x * 0.5f);
        }
    }
}
