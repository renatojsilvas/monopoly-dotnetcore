using System;

namespace monopoly
{
    public class RandomChoice : IRandomChoice
    {
        public bool Choice()
        {
            return new Random().NextDouble() >= 0.5;
        }
    }
}