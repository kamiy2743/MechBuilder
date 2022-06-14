using UnityEngine;

namespace MB
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }

        Mesh Mesh { get; }
        Material Material { get; }
    }
}