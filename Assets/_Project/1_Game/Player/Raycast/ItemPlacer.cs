using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemPlacer : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        private int _lastItemID;
        private PreviewObject _previewObject = new PreviewObject();

        public void Hit(RaycastHit hit)
        {
            var collider = hit.collider.GetComponent<ItemCollider>();
            var other = collider.Parent;
            Preview(hit, other);
        }

        private void Preview(RaycastHit hit, IItem other)
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
            _previewObject.Transform.position = point + normal * 0.25f;
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

            public void CopyMeshAndMaterial(IItem other)
            {
                _mf.mesh = other.Mesh;
                _mr.material = other.Material;
            }
        }
    }
}
