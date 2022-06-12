using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MB.Extension
{
    public static class EventTriggerExt
    {
        public static void AddListener(this EventTrigger eventTrigger, EventTriggerType eventTriggerType, UnityAction call)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventTriggerType;
            entry.callback.AddListener((eventDate) => call.Invoke());
            eventTrigger.triggers.Add(entry);
        }
    }
}