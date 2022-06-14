using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemRaycastReceiver : IRaycastReceiver
    {
        public void Hit(RaycastHit hit)
        {
            Debug.Log(hit.normal);
        }
    }
}
