using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemCollider : MonoBehaviour
    {
        public Vector3 Size => _collider.size;

        private BoxCollider _collider;

        void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }
    }
}
