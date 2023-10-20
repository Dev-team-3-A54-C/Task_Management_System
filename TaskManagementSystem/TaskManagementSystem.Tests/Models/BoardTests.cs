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

        string validName;
        Board sutBoard;
        string validTitle;
        string validDescription;
        Feedback feedback;

        [TestInitialize]
        public void Initialize()
        {
            validName = new string('a', 5);
            validTitle = new string('a', 10);
            validDescription = new string('a', 10);
            feedback = new Feedback(1, validTitle, validDescription, 1);
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
            // Act
            sutBoard = new Board(validName);

            // Assert
            Assert.AreEqual(validName, sutBoard.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsNullOrEmpty()
        {
            // Arrange
            string wrongName = "";

            // Act & Assert
            sutBoard = new Board(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            sutBoard = new Board(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 11);

            // Act & Assert
            sutBoard = new Board(wrongName);
        }

        [TestMethod]
        public void Tasks_Should_ReturnsNewList()
        {
            // Arrange
            sutBoard = new Board(validName);

            // Act
            sutBoard.AddTask(feedback);

            // Assert
            Assert.AreNotSame(sutBoard.Tasks, sutBoard.Tasks);
        }

        [TestMethod]
        public void EventLog_Should_ReturnsNewList()
        {
            // Arrange & Act
            sutBoard = new Board("TestBoard");

            // Assert
            Assert.AreNotSame(sutBoard.EventLog, sutBoard.EventLog);
        }

        [TestMethod]
        public void AddTask_Should_AddTask_WhenParameterIsValid()
        {
            // Arrange
            sutBoard = new Board(validName);
            int expectedCount = 1;

            // Act
            sutBoard.AddTask(feedback);

            // Assert
            Assert.AreEqual(expectedCount, sutBoard.Tasks.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateItemException))]
        public void AddTask_Should_Throw_WhenTaskIsInTheCollection()
        {
            // Arrange
            sutBoard = new Board(validName);
            sutBoard.AddTask(feedback);

            // Act & Assert
            sutBoard.AddTask(feedback);
        }

        [TestMethod]
        public void RemoveTask_Should_RemoveTask_WhenParameterIsValid()
        {
            // Arrange
            sutBoard = new Board(validName);
            sutBoard.AddTask(feedback);
            bool expectedResult = false;

            // Act
            sutBoard.RemoveTask(feedback);

            // Assert
            bool isInList = sutBoard.Tasks.Contains(feedback);
            Assert.AreEqual(expectedResult, isInList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTask_Should_Throw_WhenTaskIsNotInTheCollection()
        {
            // Arrange
            sutBoard = new Board(validName);

            // Act & Assert
            sutBoard.RemoveTask(feedback);
        }
    }
}
