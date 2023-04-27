using Editor.Attributes;
using Runtime.ValueObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.ValueListeners
{
    public class FloatValueListener : MonoBehaviour
    {
        public UnityEvent onValueChanged;
        public UnityEvent onValueEqualToTarget;
        public UnityEvent onValueGreaterThanTarget;
        public UnityEvent onValueGreaterThanOrEqualToTarget;
        public UnityEvent onValueLessThanTarget;
        public UnityEvent onValueLessThanOrEqualToTarget;

        [SerializeField] private FloatListenerType floatListenerType;
        [SerializeField] private FloatValue floatValue;
        [SerializeField] private bool shouldListenerRespondToRuntimeChanges;

        [SerializeField] private bool shouldShowTargetField;
        [SerializeField] [DrawIf("shouldShowTargetField", true, ComparisonType.EqualTo)]
        private float target;
        
        private float cachedFloatValue;

        public void Evaluate()
        {
            switch (floatListenerType)
            {
                case FloatListenerType.CheckIfLessThanTarget:
                    if (floatValue.Value < target)
                        onValueLessThanTarget.Invoke();
                    break;
                case FloatListenerType.CheckIfLessThanOrEqualToTarget:
                    if (floatValue.Value <= target)
                        onValueLessThanOrEqualToTarget.Invoke();
                    break;
                case FloatListenerType.CheckIfGreaterThanTarget:
                    if (floatValue.Value > target)
                        onValueGreaterThanTarget.Invoke();
                    break;
                case FloatListenerType.CheckIfGreaterThanOrEqualToTarget:
                    if (floatValue.Value >= target)
                        onValueGreaterThanOrEqualToTarget.Invoke();
                    break;
                case FloatListenerType.CheckIfEqualToTarget:
                    if (floatValue.Value.Equals(target))
                        onValueEqualToTarget.Invoke();
                    break;
                case FloatListenerType.CheckIfValueChanged:
                    if (!cachedFloatValue.Equals(floatValue.Value))
                        onValueChanged.Invoke();

                    cachedFloatValue = floatValue.Value;
                    break;
            }
        }

        private void OnEnable()
        {
            if (shouldListenerRespondToRuntimeChanges)
                floatValue.onValueChanged += Evaluate;
        }

        private void OnDisable()
        {
            floatValue.onValueChanged -= Evaluate;
        }
    }

    public enum FloatListenerType
    {
        CheckIfLessThanTarget = 0,
        CheckIfLessThanOrEqualToTarget = 1,
        CheckIfGreaterThanTarget = 2,
        CheckIfGreaterThanOrEqualToTarget = 3,
        CheckIfEqualToTarget = 4,
        CheckIfValueChanged = 5
    }
}