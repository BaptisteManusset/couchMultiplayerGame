using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class WaitState : TimedState
    {
        private GameStateMachine stateMachine;
        public override void PrepareState()
        {
            stateMachine = owner as GameStateMachine;
            base.PrepareState();
            CountDown.SetDurationAndStart(5);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (CountDown.progress <= 0)
            {
                owner.ChangeState(new PlayState());
            }
            else
            {
                Debug.Log(Mathf.Round(CountDown.progress));
            }
        }
    }
}