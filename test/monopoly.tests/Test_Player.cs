using NUnit.Framework;
using monopoly;
using Moq;
using System.Collections.Generic;

namespace monopoly.tests
{
    public class Test_Player
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

            //Act

            //Assert
            Assert.IsNotNull(p);
            Assert.AreEqual(300, p.Balance);
            Assert.IsInstanceOf<Impulsive>(p.Strategy);
        }

        [Test]
        public void TestPay()
        {
            //Arrange
            var p = new Player(10);

            //Act
            int value = p.Pay(10);

            //Assert
            Assert.AreEqual(10, value);
            Assert.AreEqual(0, p.Balance);
        }

        [Test]
        public void TestReceive()
        {
            //Arrange
            var p = new Player(0);

            //Act
            p.Receive(10);

            //Assert
            Assert.AreEqual(10, p.Balance);
        }

        [Test]
        public void TestTransfer()
        {
            //Arrange
            var p1 = new Player(10);
            var p2 = new Player(0);

            //Act
            p2.Receive(p1.Pay(10));

            //Assert
            Assert.AreEqual(0, p1.Balance);
            Assert.AreEqual(10, p2.Balance);
        }

        [Test]
        public void TestOutOfMoney()
        {
            //Arrange
            var p = new Player(0);

            //Act
            
            //Assert
            Assert.Throws<Player.OutOfMoneyException>(() => p.Pay(1));
        }

        [Test]
        public void TestInvestImpulsive()
        {
            //Arrange
            var p = new Player(100);

            //Act
            var value = p.Invest(100, 10);
            
            //Assert
            Assert.AreEqual(100, value);
            Assert.AreEqual(0, p.Balance);
        }

        [Test]
        public void TestInvestWithoutMoney()
        {
            //Arrange
            var p = new Player(10);

            //Act
                        
            //Assert
            Assert.Throws<Player.NotEnoughMoneyException>(() => p.Invest(100, 10));
        }

        [Test]
        public void TestInvestDemanding()
        {
            //Arrange
            var p = new Player(100, new Demanding());

            //Act
            var value = p.Invest(100, 51);
                        
            //Assert
            Assert.AreEqual(100, value);
            Assert.AreEqual(0, p.Balance);
        }

         [Test]
        public void TestInvestDemandingAbort()
        {
            //Arrange
            var p = new Player(100, new Demanding());

            //Act
                        
            //Assert
            Assert.Throws<Player.AbortInvestmentException>(() => p.Invest(100, 50));
        }

        [Test]
        public void TestInvestCautious()
        {
            //Arrange
            var p = new Player(180, new Cautious());

            //Act
            var value = p.Invest(100, 10);
                        
            //Assert
            Assert.AreEqual(100, value);
            Assert.AreEqual(80, p.Balance);
        }

         [Test]
        public void TestInvestCautiousAbort()
        {
            //Arrange
            var p = new Player(100, new Cautious());

            //Act
                        
            //Assert
            Assert.Throws<Player.AbortInvestmentException>(() => p.Invest(100, 10));
        }

        [Test]
        public void TestInvestGambler()
        {
            //Arrange
            var mock = new Mock<IRandomChoice>();
            mock.Setup(s => s.Choice()).Returns(true);
            var randomChoice = mock.Object;
            var p = new Player(100, new Gambler(randomChoice));

            //Act
            var value = p.Invest(100, 10);
                        
            //Assert
            Assert.AreEqual(100, value);
            Assert.AreEqual(0, p.Balance);
        }

        [Test]
        public void TestInvestGamblerAbort()
        {
            //Arrange
            var mock = new Mock<IRandomChoice>();
            mock.Setup(s => s.Choice()).Returns(false);
            var randomChoice = mock.Object;
            var p = new Player(100, new Gambler(randomChoice));

            //Act
                        
            //Assert
            Assert.Throws<Player.AbortInvestmentException>(() => p.Invest(100, 10));
        }

        [Test]
        public void TestStr()
        {
            //Arrange
            var p1 = new Player(100);
            var p2 = new Player(100, new Cautious());
            var p3 = new Player(100, new Gambler(null));
            var p4 = new Player(100, new Demanding());

            //Act
                        
            //Assert
            Assert.AreEqual("Impulsive", p1.ToString());
            Assert.AreEqual("Cautious", p2.ToString());
            Assert.AreEqual("Gambler", p3.ToString());
            Assert.AreEqual("Demanding", p4.ToString());
        }

        [Test]
        public void TestFactory()
        {
            //Arrange
            List<Player> p = Player.FromStrategies(300);
            var p1 = p[0];
            var p2 = p[1];
            var p3 = p[2];
            var p4 = p[3];

            //Act
                        
            //Assert
            Assert.AreEqual(4, p.Count);
            p.ForEach(player => Assert.IsTrue(player.Balance == 300));
            Assert.AreEqual("Impulsive", p1.ToString());
            Assert.AreEqual("Cautious", p2.ToString());
            Assert.AreEqual("Gambler", p3.ToString());
            Assert.AreEqual("Demanding", p4.ToString());
        }
    }
}