using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class CoreUnit : MonoBehaviour, IFieldItem, IInteractable
    {
        public ItemID ID { get; private set; }

        public GameObject GameObject => this.gameObject;
        public ItemCollider Collider { get; private set; }

        public ItemApperance Apperance { get; private set; }

        public void Initialize(ItemID itemID)
        {
            ID = itemID;

            Collider = GetComponent<ItemCollider>();

            Apperance = this.gameObject.GetComponentInSelfOrChildren<ItemApperance>();
        }

        public void Interact()
        {
            Debug.Log("interact");
        }
    }
}