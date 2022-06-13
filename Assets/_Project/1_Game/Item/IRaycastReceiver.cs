using UnityEngine;

namespace MB
{
    public interface IRaycastReceiver
    {
        void Hit(RaycastHit hit);
    }
}