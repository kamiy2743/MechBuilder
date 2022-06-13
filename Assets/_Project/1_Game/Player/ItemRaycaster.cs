using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemRaycaster : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private float _maxDistance;

        private Transform _camera;
        private int _layerMask;

        public void StaticAwake()
        {
            _camera = Camera.main.transform;
            _layerMask = 1 << LayerMask.NameToLayer("Item");
        }

        void Update()
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(_camera.position, _camera.TransformDirection(Vector3.forward), out RaycastHit hit, _maxDistance, _layerMask))
            {
                Debug.DrawRay(_camera.position, _camera.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(_camera.position, _camera.TransformDirection(Vector3.forward) * _maxDistance, Color.yellow);
            }
        }
    }
}
