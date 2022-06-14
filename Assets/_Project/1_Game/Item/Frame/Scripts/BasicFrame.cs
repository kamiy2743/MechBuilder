using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IItem, IRaycastReceiver
    {
        public string Name { get; private set; } = "BasicFrame";

        private ItemRaycastReceiver _placeableItemRaycastReceiver = new ItemRaycastReceiver();

        public void Hit(RaycastHit hit)
        {
            _placeableItemRaycastReceiver.Hit(hit);
        }
    }
}
