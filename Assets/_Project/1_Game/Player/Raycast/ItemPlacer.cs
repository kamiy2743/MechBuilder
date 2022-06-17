using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemPlacer : IRaycasterStateProcessor
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

        private class PreviewObject
        {
            public Transform Transform { get; private set; }

            private MeshFilter _mf;
            private MeshRenderer _mr;

            public PreviewObject()
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MonoBehaviour.Destroy(go.GetComponent<BoxCollider>());

                Transform = go.transform;
                _mf = go.GetComponent<MeshFilter>();
                _mr = go.GetComponent<MeshRenderer>();

                SetVisible(false);
            }

            public void SetVisible(bool value)
            {
                _mr.enabled = value;
            }

            public void CopyMeshAndMaterial(ItemID itemID)
            {
                var originalItem = OriginalFieldItems.Instance.GetOriginalData(itemID);

                Transform.localScale = originalItem.Apperance.Scale;
                _mf.mesh = originalItem.Apperance.MeshFilter.mesh;
                _mr.material = originalItem.Apperance.MeshRenderer.material;
            }
        }
    }
}
