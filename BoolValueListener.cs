using UnityEngine;
using UnityEngine.Events;
using ValueObjects;

namespace ValueListeners
{
    public class BoolValueListener : MonoBehaviour
    {
        public UnityEvent onValueFalse;
        public UnityEvent onValueTrue;

        [SerializeField] private bool shouldListenerRespondToRuntimeChanges;
        [SerializeField] private BoolValue boolValue;


        public void Evaluate()
        {
            if (boolValue.Value)
                onValueTrue.Invoke();
            else
                onValueFalse.Invoke();
        }

        private void OnEnable()
        {
            if (shouldListenerRespondToRuntimeChanges)
                boolValue.onValueChanged += Evaluate;
        }

        private void OnDisable()
        {
            boolValue.onValueChanged -= Evaluate;
        }
    }
}