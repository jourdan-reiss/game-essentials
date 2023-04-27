using Editor.Attributes;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] [CanNotEditInInspector]
        private string currentStateName;
        private IState currentState;

        public void StartStateMachine(IState firstState)
        {
            SetUpNewState(firstState);
        }

        private void CleanLastState()
        {
            currentState.onNewStateRequested -= EnterNewState;
            currentState.OnExit();

            currentState = null;
        }

        private void EnterNewState(IState newState)
        {
            CleanLastState();

            SetUpNewState(newState);
        }

        private void FixedUpdate()
        {
            if (currentState is IFixedUpdate canPerformFixedUpdate)
                canPerformFixedUpdate.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            if (currentState is ILateUpdate canPerformLateUpdate)
                canPerformLateUpdate.OnLateUpdate();
        }

        private void OnDestroy()
        {
            CleanLastState();
        }

        private void SetUpNewState(IState newState)
        {
            currentState = newState;

            currentState.onNewStateRequested += EnterNewState;
            currentState.OnEnter();
        }

        private void Update()
        {
            if (currentState is IUpdate canPerformUpdate)
                canPerformUpdate.OnUpdate();
        }
    }
}