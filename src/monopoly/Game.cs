using System.Collections.Generic;
using System.Linq;

namespace monopoly
{
    public class Game
    {
        private Players players;
        private List<RealState> properties;
        private readonly IDice dice;

        public Board Board { get; }

        public Player Leader
        {
            get
            {
                return players.OrderByDescending(p => p.Balance)
                              .First();
            }
        }

        public Game(Players players, List<RealState> properties, IDice dice = null)
        {
            this.dice = dice;
            this.properties = properties;
            this.players = players;
            this.Board = new Board(players, properties);
        }

        public Player Run(int turns = 0)
        {
            while (players.NumberOfActivePlayers > 1 && turns < 1000)
            {
                foreach (var p in players)
                {
                    this.Board.Turn(p, dice.Roll());
                }
                turns++;
            }
            return this.Leader;
        }
    }
}