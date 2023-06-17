using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class Party
    {
        public static Action<Player> PlayerJoin;
        public static Action<Player> PlayerLeave;

        static Party() { }

        public List<Player> Players = new();
        public List<Player> Winners = new();

        public void RequestAddPlayer(Player a_player)
        {
            if (Players.Contains(a_player)) return;
            Players.Add(a_player);
            PlayerJoin?.Invoke(a_player);
        }
    }
}