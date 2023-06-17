public class TimedState : BaseState
{
    public CountDown CountDown = new();

    internal override void PrepareState()
    {
        base.PrepareState();
        CountDown = new CountDown();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CountDown.Update();
    }
}