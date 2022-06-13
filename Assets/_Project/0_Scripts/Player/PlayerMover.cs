using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlayerMover : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private float _moveSpeed;

        private Rigidbody _rigidbody;

        public void StaticAwake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            var moveVector = InputProvider.Intance.MoveVector();
            _rigidbody.AddForce(moveVector * _moveSpeed);
        }
    }
}
