using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class BoardTests
    {
        [TestInitialize]
        public void Initialize()
        {
            
        }

        [TestMethod]
        public void Board_Should_ImplementIBoardInterface()
        {
            var type = typeof(Board);
            var isAssignable = typeof(IBoard).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Board class does not implement IBoard interface!");
        }

        [TestMethod]
        public void Constructor_Should_CreateValidBoard_WhenParametersAreValid()
        {
            // Arrange
            string validName = new string('a', 5);

            // Act
            Board sut = new Board(validName);

            // Assert
            Assert.AreEqual(validName, sut.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsNullOrEmpty()
        {
            // Arrange
            string wrongName = "";

            // Act & Assert
            Board sut = new Board(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            Board sut = new Board(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 11);

            // Act & Assert
            Board sut = new Board(wrongName);
        }

        [TestMethod]
        public void Tasks_Should_ReturnsNewList()
        {
            // Arrange
            string validName = new string('a', 5);
            IBoard sutBoard = new Board(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            // Act
            sutBoard.AddTask(feedback);

            // Assert
            Assert.AreNotSame(sutBoard.Tasks, sutBoard.Tasks);
        }

        [TestMethod]
        public void EventLog_Should_ReturnsNewList()
        {
            // Arrange & Act
            IBoard sutBoard = new Board("TestBoard");

            // Assert
            Assert.AreNotSame(sutBoard.EventLog, sutBoard.EventLog);
        }
    }
}
