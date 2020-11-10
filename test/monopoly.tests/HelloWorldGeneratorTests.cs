using NUnit.Framework;
using monopoly;

namespace monopoly.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestShow()
        {
            //Assert
            HelloWorldGenerator generator = new HelloWorldGenerator();

            //Act
            string result = generator.Show("Renato");

            //Assert
            Assert.AreEqual("Hello World, Renato!", result);
        }
    }
}