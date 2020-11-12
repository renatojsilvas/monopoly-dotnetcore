using System;
using System.Collections.Generic;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player(0);    
            RealState r = new RealState(100, 10);            
            Board b = new Board(new List<Player>() { p }, new List<RealState>() { r, r, r });

            //Act
            RealState rfinal = b.Move(p, 1);
            
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);
            rfinal = b.Move(p, 1);

            
        }
    }
}
