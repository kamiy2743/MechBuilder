using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MB.Extension;

namespace MB
{
    public class StaticAwakeCaller
    {
        public static void Call()
        {
            foreach (var go in GetAllGameObjects.InActiveScene())
            {
                var staticAwakes = go.GetComponents<IStaticAwake>();
                foreach (var item in staticAwakes)
                {
                    item.StaticAwake();
                }
            }
        }
    }
}
