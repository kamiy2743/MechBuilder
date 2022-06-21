using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlayerRaycaster : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private Transform _mainCamera;
        [SerializeField] private float _maxDistance;

        private Dictionary<RaycasterState, IRaycasterStateProcessor> _processors = new Dictionary<RaycasterState, IRaycasterStateProcessor>();
        private List<IRaycasterStateProcessor> _currentProcessors = new List<IRaycasterStateProcessor>();

        public void StaticAwake()
        {
            _processors[RaycasterState.PlaceItem] = new PlaceItemProcessor();
            _processors[RaycasterState.InteractItem] = new InteractItemProcessor();
            AddStates(
                RaycasterState.PlaceItem,
                RaycasterState.InteractItem);
        }

        private void AddStates(params RaycasterState[] states)
        {
            foreach (var state in states)
            {
                var processor = _processors[state];
                _currentProcessors.Add(processor);
            }
        }

        private void RemoveStates(params RaycasterState[] states)
        {
            foreach (var state in states)
            {
                var processor = _processors[state];
                _currentProcessors.Remove(processor);
            }
        }

        void Update()
        {
            var start = _mainCamera.position;
            var direction = _mainCamera.TransformDirection(Vector3.forward);

            foreach (var processor in _currentProcessors)
            {
                var layerMask = processor.LayerMask;

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

                processor.Hit(hit);
            }
        }
    }
}
