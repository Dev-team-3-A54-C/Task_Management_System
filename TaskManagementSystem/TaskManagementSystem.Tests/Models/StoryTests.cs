using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class StoryTests
    {
        [TestMethod]
        public void Constructor_Should_CreateStory_WhenArgsAreValid()
        {
            string title = "StoryTitle";
            Story sut = new Story(1, title, "NewDescription", SizeType.Large, PriorityType.Low);
            Assert.AreEqual(title, sut.Title);
        }
        [TestMethod]
        public void AdvanceStatus_Should_ThrowException_When_StatusIsAlreadyAtLastStage()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            sut.AdvanceStatus();
            sut.AdvanceStatus();

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.AdvanceStatus());
        }
        [TestMethod]
        public void AdvanceStatus_Should_ChangeStatus_When_StatusIsNotAtLastStage()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            //Act
            sut.AdvanceStatus();
            //Assert
            Assert.AreEqual(sut.Status, StoryStatusType.InProgress);
        }
        [TestMethod]
        public void ReverseStatus_Should_ThrowException_When_StatusIsAlreadyAtFirstStage()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.ReverseStatus());
        }
        [TestMethod]
        public void ReverseStatus_Should_ChangeStatus_When_StatusIsNotAtFirstStage()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            sut.AdvanceStatus();
            //Act
            sut.ReverseStatus();
            //Assert
            Assert.AreEqual(sut.Status, StoryStatusType.NotDone);
        }
        [TestMethod]
        public void SetPriority_Should_ThrowException_When_NewPriorityIsSameAsCurrent()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.SetPriority(PriorityType.Low));
        }
        [TestMethod]
        public void SetPriority_Should_ChangePriority_When_NewPriorityIsDifferentThanCurrent()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            //Act
            sut.SetPriority(PriorityType.Medium);
            //Assert
            Assert.IsTrue(sut.Priority == PriorityType.Medium);
        }
        [TestMethod]
        public void SetSize_Should_ChangeSize()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            //Act
            sut.SetSize(SizeType.Small);
            //Assert
            Assert.IsTrue(sut.Size == SizeType.Small);
        }
        [TestMethod]
        public void AssignMember_Should_SetAssignee()
        {
            //Arrange
            string name = "TestMember";
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            //Act
            sut.AssignMember(new Member(name));

            //Assert
            Assert.AreEqual(sut.Assignee.Name, name);
        }

        [TestMethod]
        public void UnassignMember_Should_SetAssigneeToNull()
        {
            //Arrange
            Story sut = new Story(1, "StoryTitle", "NewDescription", SizeType.Large, PriorityType.Low);
            string memberName = new string('a', 10);
            sut.AssignMember(new Member(memberName));

            //Act
            sut.UnassignMember();

            //Assert
            Assert.IsNull(sut.Assignee);
        }
    }
}
