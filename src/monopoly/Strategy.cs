using System;

namespace monopoly
{
    public abstract class Strategy
    {
        public abstract bool ShouldBuy(int balance, int price, int rent);

        public override abstract string ToString();
    }

    public class Impulsive : Strategy
    {
        public override bool ShouldBuy(int balance, int price, int rent)
        {
            return true;
        }

        public override string ToString()
        {
            return "Impulsive";
        }
    }

    public class Demanding : Strategy
    {
        public override bool ShouldBuy(int balance, int price, int rent)
        {
            return (rent > 50);
        }

        public override string ToString()
        {
            return "Demanding";
        }
    }

    public class Gambler : Strategy
    {
        private readonly IRandomChoice randomChoice;
        public Gambler(IRandomChoice randomChoice)
        {
            this.randomChoice = randomChoice;
        }
        public override bool ShouldBuy(int balance, int price, int rent)
        {
            return randomChoice.Choice();
        }

        public override string ToString()
        {
            return "Gambler";
        }
    }

    public class Cautious : Strategy
    {
        public override bool ShouldBuy(int balance, int price, int rent)
        {
            return (balance - price >= 80);
        }

        public override string ToString()
        {
            return "Cautious";
        }
    }
}