using System.Collections.Generic;
using System;
using System.Linq;

namespace monopoly
{
    public class Simulation
    {
        private Random r;

        public Simulation()
        {
            r = new Random();            
        }

        public void Exercise()
        {
            Game g = GameFactory();
            Player winner = g.Run();
        }

        private Game GameFactory()
        {
            return new Game(GeneratePlayers(300), GenerateProperties(20), new Dice());
        }

        private List<Player> GeneratePlayers(int initialBalance)
        {
            List<Player> players = Player.FromStrategies(initialBalance);
            return Shuffle(players);
        }

        private List<Player> Shuffle(List<Player> players)
        {
            return players.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private List<RealState> GenerateProperties(int howMany, int mean = 5, int deviation = 1, int priceScale = 20, int rentScale = 10)
        {
            List<RealState> properties = new List<RealState>();
            for (int i = 0; i < howMany; i++)
            {
                double distribution = Gaussian(mean, deviation, r);
                properties.Add(new RealState((int)(distribution * priceScale), (int)(distribution * rentScale)));
            }
            return properties;
        }

        private double Gaussian(double mean, double deviation, System.Random rand=null, int factor = 1)
        {
            rand = rand ?? new Random();
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                        Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean +  deviation * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal * factor;
        }
    }
}