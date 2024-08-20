using System;
using Interfaces;

namespace StateMachine.ExampleStates
{
    public class TestState : IState
    {
        public event Action<IState> onNewStateRequested;
        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void RequestStateChange()
        {
            onNewStateRequested?.Invoke(new TestStateWithUpdate());
        }
    }
}