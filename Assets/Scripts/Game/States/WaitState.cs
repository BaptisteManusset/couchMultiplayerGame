using System;

namespace Game
{
    [Serializable]
    public class WaitState : TimedState
    {
        private GameStateMachine stateMachine;

        internal override void PrepareState()
        {
            stateMachine = owner as GameStateMachine;
            base.PrepareState();
            CountDown.SetDuration(5);

            GameManager.Instance.Party = new Party();

            Player.OnPlayerConnect += OnPlayerConnect;
            Player.OnPlayerDisconnect += OnPlayerDisconnect;
        }

        private void OnPlayerDisconnect(Player a_player)
        {
            if (GameManager.Instance.Party.Players.Count < 2) CountDown.paused = true;
        }

        private void OnPlayerConnect(Player a_player)
        {
            if (GameManager.Instance.Party.Players.Count >= 2)
            {
                CountDown.started = true;
                CountDown.paused = false;
            }
        }

        public override void UpdateState()
        {
            if (GameManager.Instance.Party.Players.Count == 0) return;

            if (CountDown.progress <= 0)
            {
                owner.ChangeState(new PlayState());
            }

            base.UpdateState();
        }
    }
}