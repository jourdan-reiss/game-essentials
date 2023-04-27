using System.Collections.Generic;
using Runtime.EventListeners;
using UnityEngine;

namespace Runtime.EventObjects
{
    [CreateAssetMenu(fileName = "New Generic Event", menuName = "Events/Generic Event", order = 0)]
    public class GenericEvent : ScriptableObject
    {
        private readonly List<GenericEventListener> listeners = new();

        public void InvokeEvent()
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].InvokeEventResponse();
            }
        }

        public void RegisterListener(GenericEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GenericEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}