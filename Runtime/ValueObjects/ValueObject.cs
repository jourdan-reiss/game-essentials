using System;
using Editor.Attributes;
using UnityEngine;

namespace Runtime.ValueObjects
{
    public abstract class ValueObject<T> : ScriptableObject
    {
        public event Action onValueChanged;
        [SerializeField] protected bool valueCanBeEditedInPlayMode;
        
        [SerializeField] protected T value;
        [SerializeField] [CanNotEditInInspector] protected T playModeValue;

        public T Value
        {
            get => playModeValue;
            set
            {
                playModeValue = value;
                
                
                if (valueCanBeEditedInPlayMode)
                    this.value = playModeValue;
                
                
                onValueChanged?.Invoke();
            }
        }

        private void Awake()
        {
            playModeValue = value;
        }
    }
}