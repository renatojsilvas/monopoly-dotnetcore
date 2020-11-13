using NUnit.Framework;
using monopoly;

namespace monopoly.tests
{
    public class TestDice
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRoll()
        {
            //Arrange
            Dice dice = new Dice();

            //Act
            int result = dice.Roll();

            //Assert
            Assert.That(result >=1 && result <= 6);
        }
    }
}