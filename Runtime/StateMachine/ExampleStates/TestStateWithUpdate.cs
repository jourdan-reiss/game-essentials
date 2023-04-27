using System;
using Runtime.Interfaces;

namespace Runtime.StateMachine.ExampleStates
{
    public class TestStateWithUpdate : IState, IUpdate
    {
        private float ticks;
        
        public event Action<IState> onNewStateRequested;
        
        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
            ticks++;
        }
    }
}