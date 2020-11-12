using System;
using System.Collections.Generic;

namespace monopoly
{
    public class Player
    {
        public class OutOfMoneyException : Exception
        {        
        }

        public class NotEnoughMoneyException : Exception
        {        
        }

        public class AbortInvestmentException : Exception
        {        
        }

        public static List<Player> FromStrategies(int initialBalance)
        {
            List<Player> players = new List<Player>()
            {
                new Player(initialBalance),
                new Player(initialBalance, new Cautious()),
                new Player(initialBalance, new Gambler(new RandomChoice())),
                new Player(initialBalance, new Demanding())
            };
            return players;
        }

        public int Balance { private set; get; }
        public Strategy Strategy { get; }       

        public Player(int balance) 
        : this(balance, new Impulsive())
        {            
        }
        public Player(int balance, Strategy strategy)
        {
            this.Strategy = strategy;
            this.Balance = balance;
        }

        public override string ToString()
        {
            return this.Strategy.ToString();
        }
        public int Pay(int amount)
        {
            if(amount > this.Balance)
            {
                throw new OutOfMoneyException();
            }
            this.Balance -= amount;
            return amount;
        }
        public void Receive(int amount)
        {
            this.Balance += amount;
        }

        public int Invest(int price, int rent)
        {
            if (price > this.Balance)
            {
                throw new NotEnoughMoneyException();
            }

            if (!this.Strategy.ShouldBuy(this.Balance, price, rent))
            {
                throw new AbortInvestmentException();
            }

            return this.Pay(price);    
        }       
    }
}