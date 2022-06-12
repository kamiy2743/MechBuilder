using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        void Start()
        {
            StaticAwakeCaller.Call();
            StaticStartCaller.Call();
        }
    }
}
