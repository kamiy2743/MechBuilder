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
            _lastItemID = other.ID;

            var normal = hit.normal;
            var point = hit.point;
            var otherRotation = hit.collider.transform.rotation;

            _previewObject.transform.position = point + normal * 0.25f;
            _previewObject.transform.rotation = otherRotation;
        }

        private class PreviewObject
        {
            public Transform transform { get; private set; }

            public PreviewObject()
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MonoBehaviour.Destroy(go.GetComponent<BoxCollider>());

                transform = go.transform;
                transform.localScale = Vector3.one * 0.5f;
            }
        }
    }
}
