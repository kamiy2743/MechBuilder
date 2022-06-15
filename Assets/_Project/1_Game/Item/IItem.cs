using UnityEngine;

namespace MB
{
    public interface IItem
    {
        ItemID ID { get; }
        string Name { get; }

        ItemCollider Collider { get; }
        Mesh Mesh { get; }
        Material Material { get; }

        void Initialize(ItemID itemID, string name);
    }
}