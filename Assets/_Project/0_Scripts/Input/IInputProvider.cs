using UnityEngine;

namespace MB
{
    public interface IInputProvider
    {
        Vector3 MoveVector();
        bool Jump();

        bool PlaceItem();
        bool EnableSnap();
    }
}