using Battleship.Domain;
using Battleship.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class BoardTests
    {
        Board board;

        [TestInitialize]
        public void Setup()
        {
            board = new Board();
        }

        [TestMethod]
        public void Ship_Cannot_Be_Placed_If_there_IsIntersection()
        {
            Assert.Fail();//Todo
        }

        [TestMethod]
        public void Id_Gets_Set_By_Constructor()
        {
            Assert.Fail();//Todo
        }


        [TestMethod]
        public void If_Board_Found__There_Is_a_Ship__We_Return_Hit()
        {
            Assert.Fail();//Todo
        }

    }
}
