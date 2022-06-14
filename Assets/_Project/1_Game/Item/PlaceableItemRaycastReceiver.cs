using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class PlaceableItemRaycastReceiver : IRaycastReceiver
    {
        public void Hit(RaycastHit hit)
        {
            var item = hit.collider.GetComponent<IPlaceableItem>();
            Debug.Log(hit.normal);
        }
    }
}
