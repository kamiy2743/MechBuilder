using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public static class GameObjectExt
    {
        public static T GetComponentInSelfOrChildren<T>(this GameObject self, string errorMessage = default)
        {
            if (self.TryGetComponent(out T component))
            {
                return component;
            }

            component = self.GetComponentInChildren<T>();

            if (component == null && errorMessage != default)
            {
                Debug.LogError(errorMessage);
            }

            return component;
        }
    }
}
