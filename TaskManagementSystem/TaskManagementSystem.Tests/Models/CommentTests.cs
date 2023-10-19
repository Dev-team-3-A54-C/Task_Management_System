using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void Comment_Should_Implement_IComment_Interface()
        {
            var type = typeof(Comment);
            var isAssignable = typeof(IComment).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Comment class does not implement IComment interface!");
        }

        [TestMethod]
        public void Constructor_Should_Create_Instance_When_Input_Is_Valid()
        {
            //Arrange
            string author = "aaaaaaaaaaaaaa";
            string message = "mmmmmmmmmmmmmmmmmmmmmmmmmm";
            //Act
            Comment testComment = new Comment(message, author);

            //Assert
            Assert.IsNotNull(testComment);
        }

        [TestMethod]
        public void Constructor_Should_Throw_Exception_When_Author_Is_Not_Valid()
        {
            //Arrange
            string shortAuthor = "a";
            string longAuthor = new string('a', 200);
            string message = "mmmmmmmmmmmmmmmmmmmmmmmmmm";

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(message, shortAuthor));
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(message, longAuthor));
        }

        [TestMethod]
        public void Constructor_Should_Throw_Exception_When_Description_Is_Not_Valid()
        {
            //Arrange
            string author = "aaaaaaaaaaaaaaaaaaaa";
            string message = string.Empty;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Comment(message, author));
        }
    }
}
