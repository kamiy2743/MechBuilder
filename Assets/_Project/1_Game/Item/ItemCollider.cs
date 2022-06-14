using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemCollider : MonoBehaviour
    {
        public IItem Parent => _parent;
        private IItem _parent;

        private BoxCollider _collider;

        void Awake()
        {
            _parent = GetComponentInParent<IItem>();
            _collider = GetComponent<BoxCollider>();
        }
    }
}
