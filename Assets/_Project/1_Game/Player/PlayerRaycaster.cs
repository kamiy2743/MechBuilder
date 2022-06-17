using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlayerRaycaster : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private Transform _mainCamera;
        [SerializeField] private float _maxDistance;

        private Dictionary<RaycasterState, IRaycasterStateProcessor> _processores = new Dictionary<RaycasterState, IRaycasterStateProcessor>();
        private IRaycasterStateProcessor _currentProcessor;

        public void StaticAwake()
        {
            _processores[RaycasterState.PlaceItem] = new ItemPlacer();
            SetState(default);
        }

        private void SetState(RaycasterState state)
        {
            _currentProcessor = _processores[state];
        }

        void Update()
        {
            var start = _mainCamera.position;
            var direction = _mainCamera.TransformDirection(Vector3.forward);
            var layerMask = _currentProcessor.LayerMask;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(start, direction, out RaycastHit hit, _maxDistance, layerMask))
            {
                Debug.DrawRay(start, direction * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(start, direction * _maxDistance, Color.yellow);
                return;
            }

            _currentProcessor.Hit(hit);
        }
    }
}
