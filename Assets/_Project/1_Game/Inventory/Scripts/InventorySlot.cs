using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private CustomText _itemIDText;
        [SerializeField] private CustomText _itemCountText;

        public void SetItemID(ItemID itemID)
        {
            _itemIDText.SetText("ID: " + itemID.ToString());
        }

        public void SetItemCount(ItemCount itemCount)
        {
            _itemCountText.SetText("Count: " + itemCount.ToString());
        }
    }
}
