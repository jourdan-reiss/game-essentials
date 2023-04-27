using Runtime.ValueObjects;
using UnityEngine;

namespace Runtime.ValueSetters
{
    public class BoolValueSetter : MonoBehaviour
    {
        [SerializeField] private BoolValue boolValue;

        public void SetToTrue()
        {
            boolValue.Value = true;
        }

        public void SetToFalse()
        {
            boolValue.Value = false;
        }
    }
}