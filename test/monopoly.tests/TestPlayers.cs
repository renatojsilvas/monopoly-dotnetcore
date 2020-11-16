using NUnit.Framework;
using monopoly;
using Moq;
using System.Collections.Generic;

namespace monopoly.tests
{
    public class Test_Players
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInit()
        {
            //Arrange
            var p = new Player(300);
            var players = new Players(new List<Player>(){ p });

            //Act

            //Assert
            Assert.AreEqual(1, players.NumberOfActivePlayers);
        }     

        [Test]
        public void TestRemove()
        {
            //Arrange
            var p1 = new Player(300);
            var p2 = new Player(300);
            var players = new Players(new List<Player>(){ p1, p2 });

            //Act
            players.Remove(p1);

            //Assert
            Assert.AreEqual(1, players.NumberOfActivePlayers);
        }    

         [Test]
        public void TestEnumerator()
        {
            //Arrange
            List<Player> players = Player.FromStrategies(300);
            var activePlayers = new Players(players);            
            List<Player> result = new List<Player>();

            //Act
            foreach(var p in activePlayers)
            {
                result.Add(p);
            }

            //Assert
            Assert.AreEqual(players[0], result[0]);
            Assert.AreEqual(players[1], result[1]);
            Assert.AreEqual(players[2], result[2]);
            Assert.AreEqual(players[3], result[3]);            
        }       
    }
}