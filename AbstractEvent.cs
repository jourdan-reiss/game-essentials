using System;
using UnityEngine;

namespace Runtime.EventObjects
{
    public abstract class AbstractEvent<T> : ScriptableObject
    {
        public Action<T> @event;

        public abstract void InvokeEvent(T parameter);
    }
}