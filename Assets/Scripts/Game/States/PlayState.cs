﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class PlayState : ParentStateMachineBaseState
    {
 

        public override void UpdateState()
        {
            base.UpdateState();
            // if (CountDown.finish) owner.ChangeState(m_nextState);
        }

        public override void DestroyState()
        {
            base.DestroyState();

            // FindWinners();
        }

        private static void FindWinners()
        {
            List<Player> b = new List<Player>();

            foreach (Player player in GameManager.Instance.Party.Players)
            {
                if (player.State.Statue != PlayerStateMachine.StatueEnum.Alive) continue;
                b.Add(player);
            }

            float max = b.Max(x => x.Health.currentHealth);


            foreach (Player player in b)
            {
                if (Math.Abs(player.Health.currentHealth - max) < .1f) GameManager.Instance.Party.Winners.Add(player);
            }
        }
    }
}