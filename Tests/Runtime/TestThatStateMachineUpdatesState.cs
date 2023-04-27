using System.Collections;
using System.Reflection;
using NUnit.Framework;
using Runtime.StateMachine;
using Runtime.StateMachine.ExampleStates;
using UnityEngine;
using UnityEngine.TestTools;

public class TestThatStateMachineUpdatesState
{
    [UnityTest]
    public IEnumerator TestThatStateMachinePerformsUpdateOnStateWithEnumeratorPasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var sm = gameObject.AddComponent<StateMachine>();
        
        
        // Act
        var testStateWithUpdate = new TestStateWithUpdate();
        sm.StartStateMachine(testStateWithUpdate);
        
        yield return null;
        
        var type = testStateWithUpdate.GetType();
        var info = type.GetField("ticks", BindingFlags.Instance | BindingFlags.NonPublic);

        var valueAfterFirstFrame = (float)info.GetValue(testStateWithUpdate);

        yield return null;

        var valueAfterSecondFrame = (float)info.GetValue(testStateWithUpdate);
        
        // Assert
        Assert.AreNotEqual(valueAfterFirstFrame, valueAfterSecondFrame);
    }
    
    [UnityTest]
    public IEnumerator TestThatStateMachinePerformsFixedUpdateOnStateWithEnumeratorPasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var sm = gameObject.AddComponent<StateMachine>();
        
        
        // Act
        var testStateWithUpdate = new TestStateWithFixedUpdate();
        sm.StartStateMachine(testStateWithUpdate);
        
        yield return null;
        
        var type = testStateWithUpdate.GetType();
        var info = type.GetField("ticks", BindingFlags.Instance | BindingFlags.NonPublic);

        var valueAfterFirstFrame = (float)info.GetValue(testStateWithUpdate);

        yield return null;

        var valueAfterSecondFrame = (float)info.GetValue(testStateWithUpdate);
        
        // Assert
        Assert.AreNotEqual(valueAfterFirstFrame, valueAfterSecondFrame);
    }
    
    [UnityTest]
    public IEnumerator TestThatStateMachinePerformsLateUpdateOnStateWithEnumeratorPasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var sm = gameObject.AddComponent<StateMachine>();
        
        
        // Act
        var testStateWithUpdate = new TestStateWithLateUpdate();
        sm.StartStateMachine(testStateWithUpdate);
        
        yield return null;
        
        var type = testStateWithUpdate.GetType();
        var info = type.GetField("ticks", BindingFlags.Instance | BindingFlags.NonPublic);

        var valueAfterFirstFrame = (float)info.GetValue(testStateWithUpdate);

        yield return null;

        var valueAfterSecondFrame = (float)info.GetValue(testStateWithUpdate);
        
        // Assert
        Assert.AreNotEqual(valueAfterFirstFrame, valueAfterSecondFrame);
    }
}
