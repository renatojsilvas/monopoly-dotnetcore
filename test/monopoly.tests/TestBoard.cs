using System.Collections.Generic;
using NUnit.Framework;

namespace monopoly.tests
{
    public class TestBoard
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void TestInit()
        {
            //Arrange
            List<Player> players = new List<Player>();
            List<RealState> properties = new List<RealState>();
            Board b = new Board(new Players(players), properties, bonus: 1);

            //Act

            //Assert
            Assert.AreEqual(0, b.PlayersPositions.Count);
            Assert.AreEqual(0, b.Properties.Count);
            Assert.AreEqual(1, b.Bonus);            
        }

        [Test]
        public void TestMove()
        {
            //Arrange
            Player p = new Player(0);    
            RealState r = new RealState(100, 10);            
            Board b = new Board(new Players(new List<Player>() { p } ), new List<RealState>() { r });

            //Act
            RealState rfinal = b.Move(p, 1);
            Assert.AreEqual(r, rfinal);
            rfinal = b.Move(p, 1);
            Assert.AreEqual(r, rfinal);

            //Assert            
            Assert.AreEqual(100, p.Balance);            
        }

        [Test]
        public void TestSize()
        {
            //Arrange            
            RealState r = new RealState(100, 10);            
            Board b = new Board(new Players(new List<Player>()), new List<RealState>() { r });

            //Act            

            //Assert            
            Assert.AreEqual(1, b.Size);            
        }

        [Test]
        public void TestRemove()
        {
            //Arrange            
            Player p = new Player(0);
            Players activePlayers = new Players(new List<Player>() { p });
            RealState r = new RealState(100, 10);           
            Board b = new Board(activePlayers, new List<RealState>() { r });

            //Act            
            b.Remove(p);

            //Assert            
            Assert.AreEqual(0, activePlayers.NumberOfActivePlayers);            
        }

        [Test]
        public void TestTurnSuccess()
        {
            //Arrange            
            Player p = new Player(300);  
            RealState r = new RealState(100, 10);           
            Board b = new Board(new Players(new List<Player>() { p }), new List<RealState>() { r });

            //Act            
            b.Turn(p, 1);

            //Assert            
            Assert.IsTrue(r.OwnerIs(p));            
            Assert.AreEqual(200, p.Balance);            
        }

        [Test]
        public void TestTurnAbortInvestment()
        {
            //Arrange            
            Player p = new Player(300, new Demanding());  
            RealState r = new RealState(100, 50);           
            Board b = new Board(new Players(new List<Player>() { p }), new List<RealState>() { r });

            //Act            
            b.Turn(p, 1);

            //Assert            
            Assert.IsFalse(r.HasOwner());            
            Assert.AreEqual(300, p.Balance);            
        }

        [Test]
        public void TestTurnNotEnoughMoney()
        {
            //Arrange            
            Player p = new Player(0);  
            RealState r = new RealState(100, 50);           
            Board b = new Board(new Players(new List<Player>() { p }), new List<RealState>() { r });

            //Act            
            b.Turn(p, 1);

            //Assert            
            Assert.IsFalse(r.HasOwner());            
            Assert.AreEqual(0, p.Balance);            
        }

        [Test]
        public void TestTurnOutOfMoney()
        {
            //Arrange            
            Player p1 = new Player(200);
            Player p2 = new Player(49);  
            RealState r = new RealState(100, 50, owner: p1);
            Players players = new Players(new List<Player>() { p1, p2 });
            Board b = new Board(players, new List<RealState>() { r });

            //Act            
            b.Turn(p2, 1);

            //Assert            
            Assert.AreEqual(1, players.NumberOfActivePlayers);
        }
    }
}