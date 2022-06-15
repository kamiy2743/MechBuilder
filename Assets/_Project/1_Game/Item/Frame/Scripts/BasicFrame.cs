using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IItem
    {
        public int ID { get; private set; } = 5;
        public string Name { get; private set; } = "BasicFrame";

        public ItemCollider Collider { get; private set; }
        public Mesh Mesh => _mf.mesh;
        public Material Material => _mr.material;

        private MeshFilter _mf;
        private MeshRenderer _mr;

        void Awake()
        {
            Collider = GetComponent<ItemCollider>();
            _mf = this.gameObject.GetComponentInSelfOrChildren<MeshFilter>("meshfilter not found");
            _mr = this.gameObject.GetComponentInSelfOrChildren<MeshRenderer>("meshrenderer not found");
        }
    }
}
