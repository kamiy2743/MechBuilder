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
            if (_lastItemID != other.ID)
            {
                _lastItemID = other.ID;
                _previewObject.CopyMeshAndMaterial(other);
            }

            var normal = hit.normal;
            var point = hit.point;
            var otherRotation = hit.collider.transform.rotation;

            _previewObject.SetVisible(true);
            _previewObject.Transform.position = point + normal * (other.Collider.Size.x * other.Collider.Size.x);
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

            public void CopyMeshAndMaterial(IFieldItem other)
            {
                Transform.localScale = other.Apperance.Scale;
                _mf.mesh = other.Apperance.MeshFilter.mesh;
                _mr.material = other.Apperance.MeshRenderer.material;
            }
        }
    }
}
