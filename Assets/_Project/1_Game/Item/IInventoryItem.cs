using UnityEngine;

namespace MB
{
    public interface IInventoryItem
    {
        ItemID ID { get; }
        string Name { get; }

        ItemCount Count { get; }

        Sprite Thumbnail { get; }
    }
}