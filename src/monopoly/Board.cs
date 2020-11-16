using System.Collections.Generic;

namespace monopoly
{
    public class Board
    {
        public Dictionary<Player, int> PlayersPositions = new Dictionary<Player, int>();        

        public Players activePlayers;
        public List<RealState> Properties { get; }
        public int Bonus { get; }

        public int Size
        {
            get
            {
                return this.Properties.Count;
            }
        }  

        public Board(Players players, List<RealState> properties, int bonus = 100)
        {
            this.activePlayers = players;
            foreach (var p in this.activePlayers)
            {
                PlayersPositions.Add(p, -1);
            }
            this.Properties = properties;
            this.Bonus = bonus;
        }

        public RealState Move(Player player, int positions)
        {
            int currentPosition = this.PlayersPositions[player];
            int newLap = (currentPosition + positions) / this.Size;
            int newPos = (currentPosition + positions) % this.Size;
            this.PlayersPositions[player] = newPos;

            if (newLap > 0)
                player.Receive(this.Bonus);

            return this.Properties[newPos];
        }

        public void Remove(Player player)
        {
            foreach (var p in this.Properties)
            {
                if(p.OwnerIs(player))
                {
                    p.Foreclose();
                }
            }

            this.activePlayers.Remove(player);
        }

        public void Turn(Player player, int positions)
        {
            RealState r = Move(player, positions);
            
            try
            {
                r.Deal(player);
            }
            catch (Player.AbortInvestmentException)
            {                
                
            }
            catch (Player.NotEnoughMoneyException)
            {

            }
            catch (Player.OutOfMoneyException)
            {
                Remove(player);
            }            
        }
    }
}