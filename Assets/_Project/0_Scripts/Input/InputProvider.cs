using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InputProvider
    {
        private static InputActions _actions;
        private static InputActions Actions => _actions ??= SetUpActions();

        private static InputActions SetUpActions()
        {
            _actions = new InputActions();
            _actions.Enable();
            return _actions;
        }

        public static Vector3 MoveVector()
        {
            var v2 = Actions.Player.Move.ReadValue<Vector2>();
            return new Vector3(v2.x, 0, v2.y);
        }
    }
}
