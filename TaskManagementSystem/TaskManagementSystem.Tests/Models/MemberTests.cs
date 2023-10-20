using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models;
using System.IO;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class MemberTests
    {
        string validName;
        IMember sutMember;

        [TestInitialize]
        public void Initialize()
        {
            validName = new string('a', 5);
        }

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
            // Act
            sutMember = new Member(validName);

            // Assert
            Assert.AreEqual(validName, sutMember.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsNullOrEmpty()
        {
            // Arrange
            string wrongName = "";

            // Act & Assert
            sutMember = new Member(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string wrongName = new string('a', 4);

            // Act & Assert
            sutMember = new Member(wrongName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string wrongName = new string('a', 16);

            // Act & Assert
            sutMember = new Member(wrongName);
        }

        [TestMethod]
        public void Tasks_Should_ReturnsNewList()
        {
            // Arrange
            sutMember = new Member(validName);

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
            sutMember = new Member(validName);

            // Assert
            Assert.AreNotSame(sutMember.EventLog, sutMember.EventLog);
        }

        [TestMethod]
        public void AddMember_Should_AddTaskToCollection_WhenParametersAreValid()
        {
            // Arrange
            sutMember = new Member(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            int expectedCount = 1;

            // Act
            sutMember.AddTask(feedback);

            // Assert
            Assert.AreEqual(expectedCount, sutMember.Tasks.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateItemException))]
        public void AddMember_Should_Throw_WhenTaskIsAlreadyInCollection()
        {
            // Arrange
            sutMember = new Member(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            sutMember.AddTask(feedback);

            // Act & Assert
            sutMember.AddTask(feedback);
        }

        [TestMethod]
        public void RemoveTask_Should_RemoveTaskToCollection_WhenParametersAreValid()
        {
            // Arrange
            sutMember = new Member(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            int expectedCount = 0;
            sutMember.AddTask(feedback);

            // Act
            sutMember.RemoveTask(feedback);

            // Assert
            Assert.AreEqual(expectedCount, sutMember.Tasks.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTask_Should_Throw_WhenTaskIsAlreadyInCollection()
        {
            // Arrange
            sutMember = new Member(validName);

            string validTitle = new string('a', 10);
            string validDescription = new string('a', 10);
            Feedback feedback = new Feedback(1, validTitle, validDescription, 1);

            sutMember.AddTask(feedback);
            sutMember.RemoveTask(feedback);

            // Act & Assert
            sutMember.RemoveTask(feedback);
        }
    }
}
