using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlacableItemPlacer : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        public void Hit(RaycastHit hit)
        {
            Debug.Log(hit.normal);
        }
    }
}
