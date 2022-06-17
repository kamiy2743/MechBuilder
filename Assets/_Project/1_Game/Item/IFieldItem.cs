using UnityEngine;

namespace MB
{
    public interface IFieldItem
    {
        ItemID ID { get; }

        GameObject GameObject { get; }
        ItemCollider Collider { get; }

        ItemApperance Apperance { get; }

        void Initialize(ItemID itemID);
    }
}