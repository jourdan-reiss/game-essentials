using UnityEngine;
using ValueObjects;

namespace ValueSetters
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