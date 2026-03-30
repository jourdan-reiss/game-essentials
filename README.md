# Game Essentials

  A custom Unity package for jumpstarting new projects with reusable architecture patterns. Includes a state machine, ScriptableObject-based value objects, and a scene-independent event system.

  **Unity version:** 2021.1+

  ---

  ## Installation

  Open the Unity Package Manager and add via git URL:

  **Window → Package Manager → + → Add package from git URL**

  ```
  https://github.com/jourdan-reiss/game-essentials.git
  ```

  ---

  ## State Machine

  A MonoBehaviour-based state machine driven by an `IState` interface. States manage their own transitions by firing an event — the machine itself stays generic.

  **1. Implement `IState` for each state:**

  ```csharp
  using System;
  using Runtime.Interfaces;

  public class IdleState : IState
  {
      public event Action<IState> onNewStateRequested;

      public void OnEnter()
      {
          // set up idle behaviour
      }

      public void OnExit()
      {
          // clean up
      }

      private void OnPlayerMoved()
      {
          // trigger a transition by raising the event
          onNewStateRequested?.Invoke(new WalkState());
      }
  }
  ```

  **2. Optionally implement update interfaces for per-frame logic:**

  ```csharp
  using Runtime.Interfaces;

  public class WalkState : IState, IUpdate, IFixedUpdate
  {
      public event Action<IState> onNewStateRequested;

      public void OnEnter() { }
      public void OnExit() { }

      public void OnUpdate()
      {
          // called each Update
      }

      public void OnFixedUpdate()
      {
          // called each FixedUpdate
      }
  }
  ```

  **3. Attach `StateMachine` to a GameObject and start it:**

  ```csharp
  public class PlayerController : MonoBehaviour
  {
      [SerializeField] private StateMachine stateMachine;

      private void Start()
      {
          stateMachine.StartStateMachine(new IdleState());
      }
  }
  ```
  ### Extending The State Pattern

  All classes are designed to be extended through inheritance and interface implementation. `IState`, `IUpdate`, `IFixedUpdate`, and `ILateUpdate` are the core interfaces — implement as many as each state needs.

  For further reading on the pattern: [Game Programming Patterns — State](http://gameprogrammingpatterns.com/state.html)
  
  ---

  ## Value Objects

  ScriptableObject assets that hold a single value and notify listeners when it changes. Useful for sharing state across scenes without direct references between components.

  **1. Create a value asset in the Unity Editor:**

  Right-click in the Project window → **Create → Value Objects → Bool Value** (or Float Value)

  **2. Reference and use it in a MonoBehaviour:**

  ```csharp
  public class PlayerHealth : MonoBehaviour
  {
      [SerializeField] private FloatValue health;

      private void OnEnable()
      {
          health.onValueChanged += OnHealthChanged;
      }

      private void OnDisable()
      {
          health.onValueChanged -= OnHealthChanged;
      }

      public void TakeDamage(float amount)
      {
          health.Value -= amount;
      }

      private void OnHealthChanged()
      {
          Debug.Log($"Health is now: {health.Value}");
      }
  }
  ```
  ---

  ## Event Objects

  ScriptableObject assets that act as events. GameObjects register as listeners and respond when the event is invoked — no direct references required, works across scenes.

  **1. Create an event asset:**

  Right-click in the Project window → **Create → Events → Generic Event**

  **2. Invoke it from any MonoBehaviour:**

  ```csharp
  public class Door : MonoBehaviour
  {
      [SerializeField] private GenericEvent onDoorOpened;

      public void Open()
      {
          onDoorOpened.InvokeEvent();
      }
  }
  ```

  **3. For typed events carrying data, extend `AbstractEvent<T>`:**

  ```csharp
  [CreateAssetMenu(menuName = "Events/Int Event")]
  public class IntEvent : AbstractEvent<int>
  {
      public override void InvokeEvent(int parameter)
      {
          @event?.Invoke(parameter);
      }
  }
  ```

  For further reading: [Scriptable Object Architecture — Ryan Hipple (Unite Austin)](https://www.youtube.com/watch?v=raQ3iHhE_Kk)

  ---
