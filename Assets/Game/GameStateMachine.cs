namespace Game
{
    public class GameStateMachine : StateMachine
    {
        private void Start()
        {
            ChangeState(new WaitState());
        }
    }
}