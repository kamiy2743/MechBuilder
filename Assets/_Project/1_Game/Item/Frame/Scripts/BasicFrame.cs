using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IFrame
    {
        public string Name { get; private set; } = "BasicFrame";
    }
}
