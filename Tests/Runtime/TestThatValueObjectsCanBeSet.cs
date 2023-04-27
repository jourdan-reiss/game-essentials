using NUnit.Framework;
using Runtime.ValueObjects;
using UnityEngine;

public class TestThatValueObjectsCanBeSet
{
    [Test]
    public void TestThatBoolValueCanBeSetSimplePasses()
    {
        // Arrange
        var boolValue = ScriptableObject.CreateInstance<BoolValue>();
        // default value is false for boolean 
        var initialValue = boolValue.Value;

        // Act
        boolValue.Value = true;

        // Assert
        Assert.AreNotEqual(initialValue, boolValue.Value);
    }

    [Test]
    public void TestThatFloatValueCanBeSetSimplePasses()
    {
        // Arrange
        var floatValue = ScriptableObject.CreateInstance<FloatValue>();
        var initialValue = floatValue.Value;
        const float addition = 5;

        // Act
        floatValue.Value += addition;
        
        // Assert
        Assert.AreEqual(initialValue + addition, floatValue.Value);
    }
}