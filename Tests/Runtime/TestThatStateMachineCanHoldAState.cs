using System.Reflection;
using NUnit.Framework;
using Runtime.Interfaces;
using Runtime.StateMachine;
using Runtime.StateMachine.ExampleStates;
using UnityEngine;

public class TestThatStateMachineCanHoldAState
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestThatStateMachineCanHoldAStateSimplePasses()
    {
        // Arrange
        var gameObject = new GameObject();
        var sm = gameObject.AddComponent<StateMachine>();
        
        // Act
        sm.StartStateMachine(new TestState());

        var type = sm.GetType();
        var info = type.GetField("currentState", BindingFlags.Instance | BindingFlags.NonPublic);

        var value = info.GetValue(sm);

        var heldState = value as IState;
        
        // Assert
        Assert.IsNotNull(heldState);
    }
}
