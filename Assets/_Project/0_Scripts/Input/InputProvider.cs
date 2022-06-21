using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InputProvider : IInputProvider
    {
        public static InputProvider Intance => _intance;
        private static InputProvider _intance = new InputProvider();

        private IInputProvider _input = new InputSystemProvider();

        public Vector3 MoveVector()
        {
            return _input.MoveVector();
        }

        public bool Jump()
        {
            return _input.Jump();
        }

        public bool PlaceItem()
        {
            return _input.PlaceItem();
        }

        public bool EnableSnap()
        {
            return _input.EnableSnap();
        }

        public bool Interact()
        {
            return _input.Interact();
        }
    }
}
