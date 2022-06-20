using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public partial class ItemPlacer
    {
        private class PreviewObject
        {
            public Transform Transform { get; private set; }

            private MeshFilter _mf;
            private MeshRenderer _mr;

            public PreviewObject()
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = "PreviewObject";
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
