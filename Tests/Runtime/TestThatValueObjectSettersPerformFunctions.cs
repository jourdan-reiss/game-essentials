using System.Reflection;
using NUnit.Framework;
using Runtime.ValueObjects;
using Runtime.ValueSetters;
using UnityEngine;

public class TestThatValueObjectSettersPerformFunctions
{
    [Test]
    public void TestThatBoolValueSetterPerformsSetToFalseFunctionSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var boolValueSetter = gameObject.AddComponent<BoolValueSetter>();
        var boolValue = ScriptableObject.CreateInstance<BoolValue>();

        boolValue.Value = true;
        
        var type = boolValueSetter.GetType();
        var info = type.GetField("boolValue", BindingFlags.Instance | BindingFlags.NonPublic);
        
        info.SetValue(boolValueSetter, boolValue);
        
        // Act
        boolValueSetter.SetToFalse();
        
        // Assert
        Assert.AreEqual(false, boolValue.Value);
    }

    [Test]
    public void TestThatBoolValueSetterPerformsSetToTrueFunctionSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var boolValueSetter = gameObject.AddComponent<BoolValueSetter>();
        var boolValue = ScriptableObject.CreateInstance<BoolValue>();

        boolValue.Value = false;
        
        var type = boolValueSetter.GetType();
        var info = type.GetField("boolValue", BindingFlags.Instance | BindingFlags.NonPublic);
        
        info.SetValue(boolValueSetter, boolValue);
        
        // Act
        boolValueSetter.SetToTrue();
        
        // Assert
        Assert.AreEqual(true, boolValue.Value);
    }
    
    [Test]
    public void TestThatFloatValueSetterPerformsSetValueFunctionSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueSetter = gameObject.AddComponent<FloatValueSetter>();
        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        floatValue.Value = 0f;
        
        var type = floatValueSetter.GetType();
        var info = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        
        info.SetValue(floatValueSetter, floatValue);
        
        // Act
        floatValueSetter.SetValue(10f);
        
        // Assert
        Assert.AreEqual(10f, floatValue.Value);
    }
}
