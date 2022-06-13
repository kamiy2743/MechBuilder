using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlayerMover : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpForce;

        private Rigidbody _rigidbody;
        private Transform _camera;

        public void StaticAwake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main.transform;
        }

        void FixedUpdate()
        {
            Move();
            Jump();
        }

        public void Move()
        {
            var moveDirection = MoveDirection();
            if (moveDirection == Vector3.zero) return;

            var currentSpeed = _rigidbody.velocity.magnitude;
            var force = moveDirection * _acceleration * Mathf.Abs(_maxSpeed - currentSpeed);
            _rigidbody.AddForce(force);
        }

        private Vector3 MoveDirection()
        {
            var moveVector = InputProvider.Intance.MoveVector();

            var forward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up);
            var angle = Vector3.SignedAngle(Vector3.forward, forward, Vector3.up);
            var moveRotation = Quaternion.Euler(0, angle, 0);

            return moveRotation * moveVector;
        }

        private void Jump()
        {
            var isPushed = InputProvider.Intance.Jump();
            if (!isPushed) return;

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}