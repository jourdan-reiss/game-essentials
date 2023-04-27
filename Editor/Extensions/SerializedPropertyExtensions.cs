using UnityEditor;
using Utilities;

namespace Editor.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static T GetValue<T>(this SerializedProperty property)
        {
            return property.serializedObject.targetObject.GetNestedObject<T>(property.propertyPath);
        }
    }
}