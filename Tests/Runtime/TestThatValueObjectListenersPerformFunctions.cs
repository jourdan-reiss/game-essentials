using System.Collections;
using System.Reflection;
using NUnit.Framework;
using Runtime.ValueListeners;
using Runtime.ValueObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

public class TestThatValueObjectListenersPerformFunctions
{
    [UnityTest]
    public IEnumerator TestThatBoolValueListenerInvokesOnValueTrueEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var boolValueListener = gameObject.AddComponent<BoolValueListener>();
        boolValueListener.onValueTrue = new UnityEvent();
        
        var boolValue = ScriptableObject.CreateInstance<BoolValue>();

        boolValue.Value = false;

        var type = boolValueListener.GetType();
        var info = type.GetField("boolValue", BindingFlags.Instance | BindingFlags.NonPublic);

        info.SetValue(boolValueListener, boolValue);

        yield return null;

        var ticks = 0;
        boolValueListener.onValueTrue.AddListener(() => ticks++);

        // Act
        boolValue.Value = true;
        boolValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }

    [UnityTest]
    public IEnumerator TestThatBoolValueListenerInvokesOnValueFalseEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var boolValueListener = gameObject.AddComponent<BoolValueListener>();
        boolValueListener.onValueFalse = new UnityEvent();

        var boolValue = ScriptableObject.CreateInstance<BoolValue>();

        var type = boolValueListener.GetType();
        var info = type.GetField("boolValue", BindingFlags.Instance | BindingFlags.NonPublic);

        info.SetValue(boolValueListener, boolValue);

        yield return null;

        var ticks = 0;
        boolValueListener.onValueFalse.AddListener(() => ticks++);

        // Act
        boolValue.Value = false;
        boolValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }
    
    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueChangedEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueChanged = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfValueChanged);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueChanged.AddListener(() => ticks++);

        // Act
        floatValue.Value = 10;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }
    
    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueLessThanTargetEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueLessThanTarget = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);
        var targetFieldInfo = type.GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfLessThanTarget);
        
        const int targetValue = 10;
        targetFieldInfo.SetValue(floatValueListener, targetValue);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueLessThanTarget.AddListener(() => ticks++);

        // Act
        floatValue.Value = 9;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }
    
    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueGreaterThanTargetEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueGreaterThanTarget = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);
        var targetFieldInfo = type.GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfGreaterThanTarget);
        
        const int targetValue = 10;
        targetFieldInfo.SetValue(floatValueListener, targetValue);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueGreaterThanTarget.AddListener(() => ticks++);

        // Act
        floatValue.Value = 11;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }

    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueEqualToTargetEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueEqualToTarget = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);
        var targetFieldInfo = type.GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfEqualToTarget);
        
        const int targetValue = 10;
        targetFieldInfo.SetValue(floatValueListener, targetValue);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueEqualToTarget.AddListener(() => ticks++);

        // Act
        floatValue.Value = 10;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(1, ticks);
    }
    
    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueLessThanOrEqualToTargetEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueLessThanOrEqualToTarget = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);
        var targetFieldInfo = type.GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfLessThanOrEqualToTarget);
        
        const int targetValue = 10;
        targetFieldInfo.SetValue(floatValueListener, targetValue);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueLessThanOrEqualToTarget.AddListener(() => ticks++);

        // Act
        floatValue.Value = 10;
        floatValueListener.Evaluate();

        floatValue.Value = 9;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(2, ticks);
    }
    
    [UnityTest]
    public IEnumerator TestThatFloatValueListenerInvokesOnValueGreaterThanOrEqualToTargetEventOnSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var floatValueListener = gameObject.AddComponent<FloatValueListener>();
        floatValueListener.onValueGreaterThanOrEqualToTarget = new UnityEvent();

        var floatValue = ScriptableObject.CreateInstance<FloatValue>();

        var type = floatValueListener.GetType();
        var floatValueFieldInfo = type.GetField("floatValue", BindingFlags.Instance | BindingFlags.NonPublic);
        var floatListenerTypeFieldInfo = type.GetField("floatListenerType", BindingFlags.Instance | BindingFlags.NonPublic);
        var targetFieldInfo = type.GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

        floatValueFieldInfo.SetValue(floatValueListener, floatValue);
        floatListenerTypeFieldInfo.SetValue(floatValueListener, FloatListenerType.CheckIfGreaterThanOrEqualToTarget);
        
        const int targetValue = 10;
        targetFieldInfo.SetValue(floatValueListener, targetValue);

        yield return null;

        var ticks = 0;
        floatValueListener.onValueGreaterThanOrEqualToTarget.AddListener(() => ticks++);

        // Act
        floatValue.Value = 10;
        floatValueListener.Evaluate();

        floatValue.Value = 11;
        floatValueListener.Evaluate();

        // Assert
        Assert.AreEqual(2, ticks);
    }
}