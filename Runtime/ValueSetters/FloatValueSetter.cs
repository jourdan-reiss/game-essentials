using Runtime.ValueObjects;
using UnityEngine;

namespace Runtime.ValueSetters
{
    public class FloatValueSetter : MonoBehaviour
    {
        [SerializeField] private FloatValue floatValue;

        public void SetValue(float newValue)
        {
            floatValue.Value = newValue;
        }
    }
}