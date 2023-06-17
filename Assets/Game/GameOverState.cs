using UnityEngine;

namespace Game
{
    public class GameOverState : BaseState
    {
        public override void PrepareState()
        {
            base.PrepareState();
            Debug.Log("Game over");
        }
    }
}