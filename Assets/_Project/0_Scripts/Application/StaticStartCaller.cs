using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MB
{
    public class StaticStartCaller
    {
        public static void Call()
        {
            foreach (var go in GetAllGameObjects.InActiveScene())
            {
                var staticStarts = go.GetComponents<IStaticStart>();
                foreach (var item in staticStarts)
                {
                    item.StaticStart();
                }
            }
        }
    }
}
