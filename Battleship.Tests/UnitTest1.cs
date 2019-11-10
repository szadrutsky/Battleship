using Battleship.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class StateTrackingServiceTests
    {
        [TestMethod]
        public void Hit_()
        {


        }
    }

    public class ShipTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FromAfterTo_ThrowsException_Letter() // if api is called with inverted locations - service should normalize directions of ships before creating domain objects
        {
            
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FromAfterTo_ThrowsException_Number() //
        {

        }
    }

    [TestClass]
    public class BoardTests
    {
        Board board;

        [TestInitialize]
        public void Setup()
        {
            board = new Board();
            Ship f4h4ship = new Ship(new MapLocation("F", 4), new MapLocation("H", 4));
            board.PlaceShip(f4h4ship);

            Assert.AreEqual(f4h4ship.Hits[1], false);
            board.Fire(new MapLocation("G", 4));
            Assert.AreEqual(f4h4ship.Hits[1], true);
        }

        [TestMethod]
        public void Ship_Is_Returned_When_Location_In_Between_From_And_To()
        {
            
        }

        [TestMethod]
        public void Ship_Is_Returned_When_Location_In_At_From_Location()
        {


        }
        [TestMethod]
        public void Ship_Is_Returned_When_Location_In_At_To_Location()
        {
        }

        [TestMethod]
        public void Ship_Is_Not_Returned_When_Location_In_Before_From_Location()
        {
        }
        [TestMethod]
        public void Ship_Is_Not_Returned_When_Location_In_After_To_Location()
        {
        }

    }
}
