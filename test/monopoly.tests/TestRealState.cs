using NUnit.Framework;
using monopoly;

namespace monopoly.tests
{
    public class TestRealState
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void TestInit()
        {
            //Arrange
            RealState r = new RealState(50, 5);

            //Act

            //Assert
            Assert.AreEqual(50, r.Price);
            Assert.AreEqual(5, r.Rent);
            Assert.IsNull(r.Owner);
        }

        [Test]
        public void TestNotHasOwner()
        {
            //Arrange
            RealState r = new RealState(50, 5);

            //Act

            //Assert
            Assert.IsFalse(r.HasOwner());
        }

        [Test]
        public void TestHasOwner()
        {
            //Arrange
            Player p = new Player(0);
            RealState r = new RealState(50, 5, owner: p);

            //Act

            //Assert
            Assert.IsTrue(r.HasOwner());
            Assert.AreEqual(p, r.Owner);
        }

        [Test]
        public void TestHasOwnedBy()
        {
            //Arrange
            Player p1 = new Player(0);
            Player p2 = new Player(0);
            RealState r = new RealState(50, 5, owner: p1);

            //Act

            //Assert
            Assert.IsTrue(r.OwnerIs(p1));
            Assert.IsFalse(r.OwnerIs(p2));
        }

        [Test]
        public void TestForeclose()
        {
            //Arrange
            Player p = new Player(0);
            RealState r = new RealState(50, 5, owner: p);

            //Act
            r.Foreclose();

            //Assert
            Assert.IsFalse(r.HasOwner());
        }

        [Test]
        public void TestSell()
        {
            //Arrange
            Player p = new Player(100);
            RealState r = new RealState(50, 5);

            //Act
            r.SellTo(p);

            //Assert
            Assert.IsTrue(r.HasOwner());
            Assert.IsTrue(r.OwnerIs(p));
            Assert.AreEqual(50, p.Balance);
        }

        [Test]
        public void TestSellError()
        {
            //Arrange
            Player p1 = new Player(100);
            Player p2 = new Player(100);
            RealState r = new RealState(50, 5, owner: p1);

            //Act
            

            //Assert
            Assert.Throws<RealState.SellException>(() => r.SellTo(p2));
        }

        public void TestRent()
        {
            //Arrange
            Player p1 = new Player(5);
            Player p2 = new Player(0);
            RealState r = new RealState(50, 5, owner: p2);

            //Act
            r.RentTo(p1);

            //Assert
            Assert.AreEqual(0, p1.Balance);
            Assert.AreEqual(5, p2.Balance);
        }

        public void TestRentIsOwner()
        {
            //Arrange
            Player p1 = new Player(5);
            RealState r = new RealState(50, 5, owner: p1);

            //Act
            r.RentTo(p1);

            //Assert
            Assert.AreEqual(5, p1.Balance);
        }

        public void TestDealSell()
        {
            //Arrange
            Player p1 = new Player(100);
            RealState r = new RealState(50, 5);

            //Act
            r.Deal(p1);

            //Assert
            Assert.IsTrue(r.OwnerIs(p1));
            Assert.AreEqual(50, p1.Balance);
        }

        public void TestDealRent()
        {
            //Arrange
            Player p1 = new Player(100);
            Player p2 = new Player(0);
            RealState r = new RealState(50, 5, owner: p2);

            //Act
            r.Deal(p1);

            //Assert
            Assert.AreEqual(95, p1.Balance);
            Assert.AreEqual(5, p2.Balance);
        }
    }
}