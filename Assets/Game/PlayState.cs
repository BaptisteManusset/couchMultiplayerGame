namespace Game
{
    public class PlayState : TimedState
    {
        public override void PrepareState()
        {
            base.PrepareState();
            CountDown.SetDurationAndStart(5);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (CountDown.finish) owner.ChangeState(new GameOverState());
        }
    }
}