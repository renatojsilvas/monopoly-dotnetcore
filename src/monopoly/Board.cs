using System.Diagnostics.Contracts;
using System.Security;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Collections.Specialized;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace monopoly
{
    public class Board
    {
        public Dictionary<Player, int> Players = new Dictionary<Player, int>();        

        public List<Player> players;
        public List<RealState> Properties { get; }
        public int Bonus { get; }

        public int Size
        {
            get
            {
                return this.Properties.Count;
            }
        }

        public Board(List<Player> players, List<RealState> properties, int bonus = 100)
        {
            this.players = players;
            this.players.ForEach(p => Players.Add(p, -1));               
            this.Properties = properties;
            this.Bonus = bonus;
        }

        public RealState Move(Player player, int positions)
        {
            int currentPosition = this.Players[player];
            int newLap = (currentPosition + positions) / this.Size;
            int newPos = (currentPosition + positions) % this.Size;
            this.Players[player] = newPos;

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

            this.Players.Remove(player);
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