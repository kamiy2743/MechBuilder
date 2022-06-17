using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InventoryItem : IInventoryItem
    {
        public ItemID ID { get; private set; }
        public string Name { get; private set; }

        public ItemCount Count { get; private set; }

        public Sprite Thumbnail { get; private set; }

        public static IInventoryItem Empty => _empty;
        private static IInventoryItem _empty = new InventoryItem(
            itemID: ItemID.EmptyID,
            name: "EmptyItem",
            count: ItemCount.Min,
            thumbnail: default);

        public InventoryItem(ItemID itemID, string name, ItemCount count, Sprite thumbnail)
        {
            ID = itemID;
            Name = name;
            Count = count;
            Thumbnail = thumbnail;
        }
    }
}
