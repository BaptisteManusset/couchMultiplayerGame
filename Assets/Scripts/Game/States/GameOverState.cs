using UnityEngine;

namespace Game
{
    public class GameOverState : BaseState
    {
        internal override void PrepareState()
        {
            base.PrepareState();
            Debug.Log("Game over");
            Time.timeScale = 0.1f;
        }
    }
}