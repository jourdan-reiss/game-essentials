using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Runtime.EventListeners;
using Runtime.EventObjects;
using UnityEngine;
using UnityEngine.Events;

public class TestThatEventObjectsPerformFunctions
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestThatEventObjectsInvokeEventsWhichListenersRespondToSimplePasses()
    {
        // Arrange
        var genericEvent = ScriptableObject.CreateInstance<GenericEvent>();

        var gameObject = new GameObject();
        var genericEventListener = gameObject.AddComponent<GenericEventListener>();
        genericEventListener.eventResponse = new UnityEvent();
        
        var type = genericEventListener.GetType();
        var genericEventFieldInfo = type.GetField("genericEvent", BindingFlags.Instance | BindingFlags.NonPublic);
        var registerEventMethod = type.GetMethod("OnEnable", BindingFlags.Instance | BindingFlags.NonPublic);
        
        
        genericEventFieldInfo.SetValue(genericEventListener, genericEvent);

        var ticks = 0;
        genericEventListener.eventResponse.AddListener(() => ticks++);
        registerEventMethod.Invoke(genericEventListener, null);
        
        // Act
        genericEvent.InvokeEvent();
        
        
        // Assert
        Assert.AreEqual(1, ticks);
    }
    
    [Test]
    public void TestThatEventListenersSuccessfullyRegistersToEventSimplePasses()
    {
        // Arrange
        var genericEvent = ScriptableObject.CreateInstance<GenericEvent>();

        var gameObject = new GameObject();
        var genericEventListener = gameObject.AddComponent<GenericEventListener>();
        genericEventListener.eventResponse = new UnityEvent();
        
        var genericEventListenerType = genericEventListener.GetType();
        var genericEventFieldInfo = genericEventListenerType.GetField("genericEvent", BindingFlags.Instance | BindingFlags.NonPublic);
        genericEventFieldInfo.SetValue(genericEventListener, genericEvent);
        
        var registerEventMethod = genericEventListenerType.GetMethod("OnEnable", BindingFlags.Instance | BindingFlags.NonPublic);
        genericEventListener.eventResponse.AddListener(() => Debug.Log(""));
        registerEventMethod.Invoke(genericEventListener, null);

        var genericEventType = genericEvent.GetType();
        var eventListenersList = genericEventType.GetField("listeners", BindingFlags.Instance | BindingFlags.NonPublic);


        // Act
        var list = (List<GenericEventListener>) eventListenersList.GetValue(genericEvent);

        // Assert
        Assert.AreEqual(1, list.Count);
    }
    
    [Test]
    public void TestThatEventListenersSuccessfullyUnregistersFromEventSimplePasses()
    {
        // Arrange
        var genericEvent = ScriptableObject.CreateInstance<GenericEvent>();

        var gameObject = new GameObject();
        var genericEventListener = gameObject.AddComponent<GenericEventListener>();
        genericEventListener.eventResponse = new UnityEvent();
        
        var genericEventListenerType = genericEventListener.GetType();
        var genericEventFieldInfo = genericEventListenerType.GetField("genericEvent", BindingFlags.Instance | BindingFlags.NonPublic);
        genericEventFieldInfo.SetValue(genericEventListener, genericEvent);
        
        var registerEventMethod = genericEventListenerType.GetMethod("OnEnable", BindingFlags.Instance | BindingFlags.NonPublic);
        var unregisterEventMethod = genericEventListenerType.GetMethod("OnDisable", BindingFlags.Instance | BindingFlags.NonPublic);
        genericEventListener.eventResponse.AddListener(() => Debug.Log(""));
        registerEventMethod.Invoke(genericEventListener, null);

        var genericEventType = genericEvent.GetType();
        var eventListenersList = genericEventType.GetField("listeners", BindingFlags.Instance | BindingFlags.NonPublic);


        // Act
        var listOfRegisteredListeners = (List<GenericEventListener>) eventListenersList.GetValue(genericEvent);
        var registeredCount = listOfRegisteredListeners.Count;

        unregisterEventMethod.Invoke(genericEventListener, null);
        listOfRegisteredListeners = (List<GenericEventListener>) eventListenersList.GetValue(genericEvent);

        // Assert
        Assert.AreNotEqual(registeredCount, listOfRegisteredListeners.Count);
    }
}
