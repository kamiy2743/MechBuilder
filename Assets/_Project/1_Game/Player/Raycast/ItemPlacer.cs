using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            var normal = hit.normal;
            var point = hit.point;
            var otherRotation = hit.collider.transform.rotation;

            var originalItemInhand = OriginalFieldItems.Instance.GetOriginalData(itemInhand.ID);
            _previewObject.SetVisible(true);
            _previewObject.Transform.position = point + normal * (originalItemInhand.Collider.Size.x * other.Collider.Size.x);
            _previewObject.Transform.rotation = otherRotation;
        }
    }
}
