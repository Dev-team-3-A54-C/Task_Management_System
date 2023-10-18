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
    public class MemberTests
    {
        [TestMethod]
        public void Member_Should_ImplementIMemberInterface()
        {
            var type = typeof(Member);
            var isAssignable = typeof(IMember).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Member class does not implement IMember interface!");
        }

        [TestMethod]
        public void Constructor_Should_CreateValidMember_WhenParametersAreValid()
        {
            // Arrange
            string validName = new string('a', 5);

            // Act
            Member sut = new Member(validName);

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
            Member sut = new Member(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            Member sut = new Member(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 16);

            // Act & Assert
            Member sut = new Member(wrongName);
        }

        [TestMethod]
        public void Tasks_Should_ReturnsNewList()
        {
            // Arrange
            string validName = new string('a', 5);
            IMember sutMember = new Member(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            // Act
            sutMember.AddTask(feedback);

            // Assert
            Assert.AreNotSame(sutMember.Tasks, sutMember.Tasks);
        }

        [TestMethod]
        public void EventLog_Should_ReturnsNewList()
        {
            // Arrange & Act
            string validName = new string('a', 5);
            IMember sutMember = new Member(validName);

            // Assert
            Assert.AreNotSame(sutMember.EventLog, sutMember.EventLog);
        }
    }
}
