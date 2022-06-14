using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IItem
    {
        public int ID { get; private set; } = 5;
        public string Name { get; private set; } = "BasicFrame";

        public Mesh Mesh => _mr.material;
        public Material Material => _rendererr.material;

        private MeshFilter _mf;
        private MeshRenderer _mr;

        void Awake()
        {
            _mf = Getcom
        }
    }
}
