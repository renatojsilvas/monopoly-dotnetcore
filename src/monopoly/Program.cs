using System;
using System.Collections.Generic;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation s = new Simulation(10000);
            Console.WriteLine(s.Run());
        }
    }
}
