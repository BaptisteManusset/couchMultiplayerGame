public static class PlayerHelper
{
    public static void ChangePlayersStatue(PlayerStateMachine.StatueEnum a_statue)
    {
        GameManager.Instance.Party.Players.ForEach(player => player.State.SetStatue(a_statue));
    }
}