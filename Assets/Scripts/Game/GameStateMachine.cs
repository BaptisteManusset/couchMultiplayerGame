using UnityEngine;

namespace Game
{
    public class GameStateMachine : StateMachine
    {
        [SerializeField] private BaseState NextState;

        private void Start()
        {
            StartStateMachine();
        }

        public void StartStateMachine()
        {
            ChangeState(NextState);
        }
    }
}