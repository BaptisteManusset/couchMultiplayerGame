using System;
using System.Collections.Generic;

namespace Game
{
    public static class Party
    {
        public static Action<Player> PlayerJoin;
        public static Action<Player> PlayerLeave;

        static Party() { }

        public static List<Player> Players = new();
        public static List<Player> Winners = new();

        public static void RequestAddPlayer(Player a_player)
        {
            if (Players.Contains(a_player)) return;
            Players.Add(a_player);
            PlayerJoin?.Invoke(a_player);
        }
    }
}