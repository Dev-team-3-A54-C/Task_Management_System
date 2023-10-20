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
        string validName;
        ITeam sutTeam;

        [TestInitialize]
        public void Initialize()
        {
            validName = new string('a', 5);
        }

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
            // Act
            sutTeam = new Team(validName);

            // Assert
            Assert.AreEqual(validName, sutTeam.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsNullOrEmpty()
        {
            // Arrange
            string wrongName = "";

            // Act & Assert
            sutTeam = new Team(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            sutTeam = new Team(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 16);

            // Act & Assert
            sutTeam = new Team(wrongName);
        }

        [TestMethod]
        public void Members_Should_ReturnANewList()
        {
            // Arrange
            sutTeam = new Team(validName);
            IMember member = new Member(validName);

            // Act
            sutTeam.AddMember(member);

            // Assert
            Assert.AreNotSame(sutTeam.Members, sutTeam.Members);
        }

        [TestMethod]
        public void Boards_Should_ReturANewList()
        {
            // Arrange
            sutTeam = new Team(validName);
            IBoard board = new Board(validName);

            // Act
            sutTeam.AddBoard(board);

            // Assert
            Assert.AreNotSame(sutTeam.Boards, sutTeam.Boards);
        }

        [TestMethod]
        public void EventLog_Should_ReturnANewList()
        {
            // Arrange
            sutTeam = new Team(validName);
            // Act & Assert
            Assert.AreNotSame(sutTeam.EventLog, sutTeam.EventLog);
        }

        [TestMethod]
        public void AddMember_Should_AddMemberToCollection_WhenParametersAreValid()
        {
            // Arrange
            sutTeam = new Team(validName);
            IMember member = new Member(validName);
            int expectedCount = 1;

            // Act
            sutTeam.AddMember(member);

            // Assert
            Assert.AreEqual(expectedCount, sutTeam.Members.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateItemException))]
        public void AddMember_Should_Throw_WhenMemberIsAlreadyInCollection()
        {
            // Arrange
            sutTeam = new Team(validName);
            IMember member = new Member(validName);
            sutTeam.AddMember(member);

            // Act & Assert
            sutTeam.AddMember(member);
        }

        [TestMethod]
        public void AddBoard_Should_AddBoardToCollection_WhenParametersAreValid()
        {
            // Arrange
            sutTeam = new Team(validName);
            IBoard board = new Board(validName);
            int expectedCount = 1;

            // Act
            sutTeam.AddBoard(board);

            // Assert
            Assert.AreEqual(expectedCount, sutTeam.Boards.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateItemException))]
        public void AddBoard_Should_Throw_WhenBoardIsAlreadyInCollection()
        {
            // Arrange
            sutTeam = new Team(validName);
            IBoard board = new Board(validName);
            sutTeam.AddBoard(board);

            // Act & Assert
            sutTeam.AddBoard(board);
        }
    }
}
