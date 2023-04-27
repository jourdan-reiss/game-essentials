using UnityEngine;

namespace Runtime.ValueObjects
{
    [CreateAssetMenu(fileName = "New Bool Value", menuName = "Value Objects/Bool Value", order = 0)]
    public class BoolValue : ValueObject<bool>
    {
    }
}