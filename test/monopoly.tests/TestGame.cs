using NUnit.Framework;
using System.Collections.Generic;
using monopoly;
using Moq;

namespace monopoly.tests
{
    public class TestGame
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInit()
        {
            //Arrange
            List<Player> players = Player.FromStrategies(300);
            RealState r = new RealState(100, 10);
            Game g = new Game(new Players(players), new List<RealState>(){ r });

            //Act

            //Assert
            players.ForEach(p => Assert.IsTrue(p.Balance == 300));
            Assert.IsNotNull(g.Board);
        }

        [Test]
        public void TestLeader()
        {
            //Arrange
            List<Player> players = Player.FromStrategies(0);
            RealState r = new RealState(100, 10);
            Game g = new Game(new Players(players), new List<RealState>(){ r });

            //Act
            players[0].Receive(1);
            players[1].Receive(2);
            players[2].Receive(3);

            //Assert
            Assert.AreEqual(players[2], g.Leader);
        }

        public void TestTie()
        {
            //Arrange
            List<Player> players = Player.FromStrategies(0);
            RealState r = new RealState(100, 10);
            Game g = new Game(new Players(players), new List<RealState>(){ r });

            //Act
            players[1].Receive(1);
            players[2].Receive(1);

            //Assert
            Assert.AreEqual(players[1], g.Leader);
        }

        public void TestTieAgain()
        {
            //Arrange
            List<Player> players = Player.FromStrategies(0);
            RealState r = new RealState(100, 10);
            Game g = new Game(new Players(players), new List<RealState>(){ r });

            //Act

            //Assert
            Assert.AreEqual(players[0], g.Leader);
        }

        [Test]
        public void TestRunWinner()
        {
            //Arrange
            Player p1 = new Player(100);
            Player p2 = new Player(0);
            RealState r = new RealState(100, 10);
            var mock = new Mock<IDice>();
            mock.Setup(s => s.Roll()).Returns(1);
            var dice = mock.Object;
            Game g = new Game(new Players(new List<Player>(){ p1, p2 }), 
                              new List<RealState>(){ r },
                              dice);

            //Act
            Player winner = g.Run();

            //Assert
            Assert.AreEqual(p1, winner);
        }

        [Test]
        public void TestRunTie()
        {
            //Arrange
            Player p1 = new Player(100);
            Player p2 = new Player(100);
            RealState r = new RealState(100, 10);
            var mock = new Mock<IDice>();
            mock.Setup(s => s.Roll()).Returns(1);
            var dice = mock.Object;
            Game g = new Game(new Players(new List<Player>(){ p1, p2 }), 
                              new List<RealState>(){ r },
                              dice);

            //Act
            Player winner = g.Run(998);

            //Assert
            Assert.AreEqual(p2, winner);
        }
    }
}