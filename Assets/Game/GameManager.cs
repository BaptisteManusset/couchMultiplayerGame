using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        public GameStateMachine StateMachine;


        public Dictionary<Player, PlayerUiElement> PlayerToUi = new();


        private void Awake()
        {
            StateMachine = GetComponent<GameStateMachine>();
        }

        private void FixedUpdate()
        {
            if (PlayerToUi.Count(x => x.Key.State.Statue == PlayerStateMachine.StateEnum.Alive) == 1) { }
        }
    }
}