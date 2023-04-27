using System;
using Runtime.EventObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.EventListeners
{
    public class GenericEventListener : MonoBehaviour
    {
        public UnityEvent eventResponse;
        
        [SerializeField] private GenericEvent genericEvent;

        public void InvokeEventResponse()
        {
            eventResponse.Invoke();
        }
        
        private void OnDisable()
        {
            if (genericEvent == null)
                return;
            
            
            genericEvent.UnregisterListener(this);
        }

        private void OnEnable()
        {
            if (genericEvent == null)
                return;
            
            
            genericEvent.RegisterListener(this);
        }
    }
}