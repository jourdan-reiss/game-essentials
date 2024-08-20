using System;

namespace Interfaces
{
    public interface IState
    {
        event Action<IState> onNewStateRequested;
        void OnEnter();
        void OnExit();
    }
}