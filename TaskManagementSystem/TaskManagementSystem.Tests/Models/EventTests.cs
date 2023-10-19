using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Comment_Should_Implement_IComment_Interface()
        {
            var type = typeof(Event);
            var isAssignable = typeof(IEvent).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Event class does not implement IEvent interface!");
        }

        [TestMethod]
        public void Constructor_Should_Create_Instance_When_Input_Is_Valid()
        {
            //Arrange
            string description = "aaaaaaaaaaaaaa";
            //Act
            Event testEvent = new Event(description);

            //Assert
            Assert.IsNotNull(testEvent);
        }

        [TestMethod]
        public void Constructor_Should_Throw_Exception_When_Description_Is_Null()
        {
            //Arrange
            string description = null;

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Event(description));
        }
    }
}
