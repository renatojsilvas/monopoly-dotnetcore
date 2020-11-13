using System;
using System.Collections.Generic;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
           Player p1 = new Player(100);
            Player p2 = new Player(100);
            RealState r = new RealState(100, 10);
            Game g = new Game(new List<Player>(){ p1, p2 }, 
                              new List<RealState>(){ r },
                              null);

            g.Run(998);    
        }
    }
}
