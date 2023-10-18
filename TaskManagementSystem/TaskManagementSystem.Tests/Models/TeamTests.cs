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
    }
}
