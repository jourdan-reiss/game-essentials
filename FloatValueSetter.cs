using UnityEngine;
using ValueObjects;

namespace ValueSetters
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