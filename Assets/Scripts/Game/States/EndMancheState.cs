public class EndMancheState : BaseState
{
    internal override void PrepareState()
    {
        base.PrepareState();

        Invoke(nameof(Change), 1);
    }

    private void Change()
    {
        ((SubStateMachine)owner).EndStateMachine();
    }
}