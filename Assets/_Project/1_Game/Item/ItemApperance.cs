using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemApperance : MonoBehaviour
    {
        public Vector3 Scale => transform.localScale;
        public MeshFilter MeshFilter { get; private set; }
        public MeshRenderer MeshRenderer { get; private set; }

        void Awake()
        {
            MeshFilter = GetComponent<MeshFilter>();
            MeshRenderer = GetComponent<MeshRenderer>();
        }
    }
}
