using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InputProvider
    {
        public static InputProvider Intance => _intance;
        private static InputProvider _intance = new InputProvider();

        private IInputProvider _input = new InputSystemProvider();

        public Vector3 MoveVector()
        {
            return _input.MoveVector();
        }
    }
}
