using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public ItemCollider Collider { get; private set; }
        public Mesh Mesh => _mf.mesh;
        public Material Material => _mr.material;

        private MeshFilter _mf;
        private MeshRenderer _mr;

        public void Initialize(int itemID, string name)
        {
            ID = itemID;
            Name = name;

            Collider = GetComponent<ItemCollider>();
            _mf = this.gameObject.GetComponentInSelfOrChildren<MeshFilter>("meshfilter not found");
            _mr = this.gameObject.GetComponentInSelfOrChildren<MeshRenderer>("meshrenderer not found");
        }
    }
}
