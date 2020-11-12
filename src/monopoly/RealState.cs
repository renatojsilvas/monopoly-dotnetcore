using System;
using monopoly;

namespace monopoly
{
    public class RealState
    {
        public class SellException : Exception
        {            
        }

        public int Price { get; }
        public int Rent { get; }
        public Player Owner { get; private set;}

        public RealState(int price, int rent, Player owner = null)
        {
            this.Rent = rent;
            this.Price = price; 
            this.Owner = owner;           
        }

        public bool HasOwner()
        {
            return this.Owner != null;
        }

        public bool OwnerIs(Player player)
        {
            return this.Owner == player;
        }

        public void Foreclose()
        {
            this.Owner = null;
        }

        public void SellTo(Player player)
        {
            if (HasOwner()) throw new SellException();

            player.Invest(this.Price, this.Rent);
            this.Owner = player;
        }

        public void RentTo(Player player)
        {
            if (this.Owner == player) return;

            this.Owner.Receive(player.Pay(this.Rent));
        }

        public void Deal(Player player)
        {
            if (HasOwner())
            {
                RentTo(player);
            }
            else
            {
                SellTo(player);
            }
        }
    }
}