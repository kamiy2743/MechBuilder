using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class BasicFrame : MonoBehaviour, IItem
    {
        public int ID { get; private set; } = 5;
        public string Name { get; private set; } = "BasicFrame";
    }
}
