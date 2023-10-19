using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Team_Should_ImplementITeamInterface()
        {
            var type = typeof(Team);
            var isAssignable = typeof(ITeam).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Team class does not implement ITeam interface!");
        }

        [TestMethod]
        public void Constructor_Should_CreateValidTeam_WhenParametersAreValid()
        {
            // Arrange
            string validName = new string('a', 5);

            // Act
            Team sut = new Team(validName);

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
            Team sut = new Team(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            Team sut = new Team(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 16);

            // Act & Assert
            Team sut = new Team(wrongName);
        }

        [TestMethod]
        public void Members_Should_ReturnsNewList()
        {
            // Arrange
            string validName = new string('a', 5);
            ITeam sutTeam = new Team(validName);

            IMember member = new Member(validName);

            // Act
            sutTeam.AddMember(member);

            // Assert
            Assert.AreNotSame(sutTeam.Members, sutTeam.Members);
        }

        [TestMethod]
        public void Boards_Should_ReturnsNewList()
        {
            // Arrange
            string validName = new string('a', 5);
            ITeam sutTeam = new Team(validName);

            IBoard board = new Board(validName);

            // Act
            sutTeam.AddBoard(board);

            // Assert
            Assert.AreNotSame(sutTeam.Boards, sutTeam.Boards);
        }

        [TestMethod]
        public void EventLog_Should_ReturnsNewList()
        {
            // Arrange
            string validName = new string('a', 5);
            ITeam sutTeam = new Team(validName);

            // Act & Assert
            Assert.AreNotSame(sutTeam.EventLog, sutTeam.EventLog);
        }
    }
}
