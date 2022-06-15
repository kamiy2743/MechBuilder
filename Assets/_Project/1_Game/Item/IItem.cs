using UnityEngine;

namespace MB
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }

        ItemCollider Collider { get; }
        Mesh Mesh { get; }
        Material Material { get; }

        void Initialize(int itemID, string name);
    }
}