using System;

namespace Runtime.Interfaces
{
    public interface IState
    {
        event Action<IState> onNewStateRequested;
        void OnEnter();
        void OnExit();
    }
}