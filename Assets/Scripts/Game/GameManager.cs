using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        private GameStateMachine stateMachine;
        public GameStateMachine StateMachine => Tools.Get(ref stateMachine, GetComponent<GameStateMachine>());
        public Dictionary<Player, PlayerUiElement> PlayerToUi = new();

        public Party Party;

        private void FixedUpdate()
        {
            if (PlayerToUi.Count(x => x.Key.State.Statue == PlayerStateMachine.StateEnum.Alive) == 1) { }
        }


        public override void Awake()
        {
            base.Awake();

            Player.OnPlayerConnect += OnPlayerConnect;
        }

        private void OnPlayerConnect(Player a_player)
        {
            Party.RequestAddPlayer(a_player);
        }
    }
}