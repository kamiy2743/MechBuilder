using UnityEngine;

namespace MB
{
    public interface IRaycasterStateProcessor
    {
        int LayerMask { get; }
        void Hit(RaycastHit hit);
    }
}