using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IFieldItem
    {
        public ItemID ID { get; private set; }

        public GameObject GameObject => this.gameObject;
        public ItemCollider Collider { get; private set; }

        public Mesh Mesh => _mf.mesh;
        public Material Material => _mr.material;

        private MeshFilter _mf;
        private MeshRenderer _mr;

        public void Initialize(ItemID itemID)
        {
            ID = itemID;

            Collider = GetComponent<ItemCollider>();

            _mf = this.gameObject.GetComponentInSelfOrChildren<MeshFilter>("meshfilter not found");
            _mr = this.gameObject.GetComponentInSelfOrChildren<MeshRenderer>("meshrenderer not found");
        }
    }
}
