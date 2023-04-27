using System;
using UnityEngine;

namespace Runtime.EventObjects
{
    public abstract class AbstractEvent<T> : ScriptableObject
    {
        public Action<T> @event;

        protected abstract void InvokeEvent(T parameter);
    }
}