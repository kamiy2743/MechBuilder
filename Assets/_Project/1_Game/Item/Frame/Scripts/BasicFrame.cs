using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IFrame
    {
        public string Name { get; private set; } = "BasicFrame";

        private PlaceableItemRaycastReceiver _placeableItemRaycastReceiver = new PlaceableItemRaycastReceiver();

        public void Hit(RaycastHit hit)
        {
            _placeableItemRaycastReceiver.Hit(hit);
        }
    }
}
