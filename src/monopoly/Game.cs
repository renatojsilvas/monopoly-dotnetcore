using System.Collections.Generic;
using System.Linq;

namespace monopoly
{
    public class Game
    {
        private List<Player> players;
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

        public Game(List<Player> players, List<RealState> properties, IDice dice = null)
        {
            this.dice = dice;
            this.properties = properties;
            this.players = players;
            this.Board = new Board(players, properties);
        }

        public Player Run(int turns = 0)
        {
            for (int i = turns; i < 1000; i++)
            {
                foreach (var p in this.players)
                {
                    if (this.Board.InGame(p))
                    {
                        this.Board.Turn(p, dice.Roll());
                        if (this.Board.NumberOfActivePlayers == 1)
                            return this.Leader;
                    }                    
                }                
            }            
            return this.Leader;            
        }
    }
}