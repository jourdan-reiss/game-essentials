using UnityEngine;

namespace ValueObjects
{
    [CreateAssetMenu(fileName = "New Bool Value", menuName = "Value Objects/Bool Value", order = 0)]
    public class BoolValue : ValueObject<bool>
    {
    }
}