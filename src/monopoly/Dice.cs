using System;

namespace monopoly
{
    public class Dice : IDice
    {
        public int Roll()
        {
            return new Random().Next(1, 7);
        }
    }
}