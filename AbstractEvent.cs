using System;
using UnityEngine;

namespace EventObjects
{
    public abstract class AbstractEvent<T> : ScriptableObject
    {
        public Action<T> @event;

        public abstract void InvokeEvent(T parameter);
    }
}