using System;
using System.Collections.Generic;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation s = new Simulation(100);
            Console.WriteLine(s.Run());
        }
    }
}
