using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MB.Extension;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MB
{
    public class UIEvent : MonoBehaviour, IStaticAwake
    {
        private EventTrigger _trigger;

        public static UIEvent Instance => _instance;
        private static UIEvent _instance;

        public void StaticAwake()
        {
            _instance = this;
            _trigger = GetComponent<EventTrigger>();
        }

        public void AddListener(EventTriggerType eventTriggerType, UnityAction call)
        {
            _trigger.AddListener(eventTriggerType, call);
        }
    }
}
