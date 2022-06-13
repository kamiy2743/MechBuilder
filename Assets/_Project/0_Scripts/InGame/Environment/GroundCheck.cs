using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class GroundCheck : MonoBehaviour
    {
        public bool Triggered { get; private set; } = false;

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<GroundTag>())
            {
                Triggered = true;
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<GroundTag>())
            {
                Triggered = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<GroundTag>())
            {
                Triggered = false;
            }
        }
    }
}
