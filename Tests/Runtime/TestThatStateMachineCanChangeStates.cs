using System.Reflection;
using NUnit.Framework;
using Runtime.StateMachine;
using Runtime.StateMachine.ExampleStates;
using UnityEngine;

public class TestThatStateMachineCanChangeStates
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestThatStateMachineCanChangeStatesSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var sm = gameObject.AddComponent<StateMachine>();

        // Act
        var firstState = new TestState();
        sm.StartStateMachine(firstState);
        
        firstState.RequestStateChange();
        
        var type = sm.GetType();
        var info = type.GetField("currentState", BindingFlags.Instance | BindingFlags.NonPublic);

        var value = info.GetValue(sm);

        
        // Assert
        Assert.IsInstanceOf<TestStateWithUpdate>(value);
    }
}
