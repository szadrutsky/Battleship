using Battleship.Domain;
using Battleship.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FromAfterTo_ThrowsException_Letter() // if api is called with inverted locations - service should normalize directions of ships before creating domain objects
        {
            Assert.Fail();//Todo
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FromAfterTo_ThrowsException_Number() //
        {
            Assert.Fail();//Todo
        }

        [TestMethod]
        public void IsLocationWithin_Cell_InBetween_FromAndTo()
        {
            Ship f4h4ship = new Ship(new MapLocation('F', 4), new MapLocation('h', 4));
            Assert.AreEqual(1, f4h4ship.IsLocationWitin(new MapLocation('G', 4)));
            Assert.AreEqual(0, f4h4ship.IsLocationWitin(new MapLocation('F', 4)));
            Assert.AreEqual(2, f4h4ship.IsLocationWitin(new MapLocation('h', 4)));
        }

        [TestMethod]
        public void IsLocationWithin_OutsideOf_Ship()
        {
            Ship f4h4ship = new Ship(new MapLocation('F', 4), new MapLocation('h', 4));
            Assert.AreEqual(-1, f4h4ship.IsLocationWitin(new MapLocation('i', 4)));
            Assert.AreEqual(-1, f4h4ship.IsLocationWitin(new MapLocation('e', 4)));
        }

        [TestMethod]
        public void IntersectsWith_OtherShip_Intersection_In_TheMiddle_OfBothsShips()
        {
            Ship f4h4ship = new Ship(new MapLocation('F', 4), new MapLocation('h', 4));
            Ship g1g7ship = new Ship(new MapLocation('G', 1), new MapLocation('g', 7));

            Assert.IsTrue(f4h4ship.IntersectsWith(g1g7ship));
            Assert.IsTrue(g1g7ship.IntersectsWith(f4h4ship));
        }
    }
}
