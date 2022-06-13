using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InputSystemProvider : IInputProvider
    {
        private InputActions _actions;

        public InputSystemProvider()
        {
            _actions = new InputActions();
            _actions.Enable();
        }

        public Vector3 MoveVector()
        {
            var moveVectorV2 = _actions.Player.Move.ReadValue<Vector2>();
            return new Vector3(moveVectorV2.x, 0, moveVectorV2.y);
        }

        public bool Jump()
        {
            return _actions.Player.Jump.ReadValue<float>() > 0;
        }
    }
}
