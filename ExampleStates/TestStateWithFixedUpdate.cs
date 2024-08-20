using System;
using Interfaces;

namespace StateMachine.ExampleStates
{
    public class TestStateWithFixedUpdate : IState, IFixedUpdate
    {
        private float ticks;
        
        public event Action<IState> onNewStateRequested;
        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void OnFixedUpdate()
        {
            ticks++;
        }
    }
}