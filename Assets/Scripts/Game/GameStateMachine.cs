using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class GameStateMachine : StateMachine
    {
        [FormerlySerializedAs("BaseState")] [SerializeField] private BaseState NextState;

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