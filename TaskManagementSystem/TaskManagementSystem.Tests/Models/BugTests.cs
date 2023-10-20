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
    public class BugTests
    {
        const int id = 1;
        readonly string title = new string('a', 15);
        readonly string shortTitle = new string('a', 9);
        readonly string longTitle = new string('a', 51);
        readonly string description = new string('a', 150);
        readonly string shortDescription = new string('a', 9);
        readonly string longDescription = new string('a', 501);
        readonly IList<string> stepsToReproduce = new List<string>();
        readonly PriorityType priority = PriorityType.Medium;
        readonly SeverityType severity = SeverityType.Minor;

        [TestMethod]
        public void Constructor_Should_Create_Instance_When_Input_Is_Valid()
        {           
            //Act
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);

            //Assert
            Assert.IsNotNull(testBug);
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Title_Is_TooShort()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Bug(id,shortTitle,description, stepsToReproduce,priority, severity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Title_Is_Toolong()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Bug(id, longTitle, description, stepsToReproduce, priority, severity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Description_Is_TooShort()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Bug(id, title, shortDescription, stepsToReproduce, priority, severity));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_Description_Is_TooLong()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Bug(id, title, longDescription, stepsToReproduce, priority, severity));
        }

        [TestMethod]
        public void Check_Member_AddComment_Should_Add_Given_Comment_To_Comments()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            Comment comment = new Comment(new string('a', 15), new string('a',10));

            //Act
            testBug.AddComment(comment);

            //Assect
            Assert.AreEqual(1, testBug.Comments.Count);
        }

        [TestMethod]
        public void Check_Member_EventLog_Should_Be_Created_When_Instance_Is_Created()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);


            //Act & Assect
            Assert.AreEqual(1, testBug.EventLog.Count);
        }

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Change_Status_To_Fixed()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);

            //Act
            testBug.AdvanceStatus();

            //Assert
            Assert.AreEqual(BugStatusType.Fixed, testBug.Status);
        }

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Throw_When_Status_Can_Not_Be_Advanced()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            testBug.AdvanceStatus();


            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => testBug.AdvanceStatus());
        }

        [TestMethod]
        public void Check_Member_ReverseStatus_Should_Change_Status_To_Active()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            testBug.AdvanceStatus();

            //Act
            testBug.ReverseStatus();

            //Assert
            Assert.AreEqual(BugStatusType.Active, testBug.Status);
        }

        [TestMethod]
        public void Check_Member_ReverseStatus_Should_Throw_When_Status_Can_Not_Be_Advanced()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>( () => testBug.ReverseStatus());
        }

        [TestMethod]
        public void Check_Member_SetPriority_Should_Change_Priority_To_Low()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);

            //Act
            testBug.SetPriority(PriorityType.Low);

            //Assert
            Assert.AreEqual(PriorityType.Low, testBug.Priority);
        }

        [TestMethod]
        public void Check_Member_SetPriority_Should_Throw_Exception_When_Priority_Is_Same_As_Old()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            testBug.SetPriority(PriorityType.Low);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => testBug.SetPriority(PriorityType.Low));
        }

        [TestMethod]
        public void Check_Member_SetSeverity_Should_Change_Severity_To_Critical()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);

            //Act
            testBug.SetSeverity(SeverityType.Critical);

            //Assert
            Assert.AreEqual(SeverityType.Critical, testBug.Severity);
        }

        [TestMethod]
        public void Check_Member_SetSeverity_Should_Throw_Exception_When_Severity_Is_Same_As_Old()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            testBug.SetSeverity(SeverityType.Critical);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => testBug.SetSeverity(SeverityType.Critical));
        }

        [TestMethod]
        public void Check_Member_AssignMember_Should_Set_Given_Member_Assignee()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            string memberName = new string('a', 10);
            //Act
            testBug.AssignMember(new Member(memberName));

            //Assert
            Assert.AreEqual(testBug.Assignee.Name, memberName);
        }

        [TestMethod]
        public void Check_Member_UnassignMember_Should_Set_Current_Assignee_As_Null()
        {
            //Arrange
            Bug testBug = new Bug(id, title, description, stepsToReproduce, priority, severity);
            string memberName = new string('a', 10);
            testBug.AssignMember(new Member(memberName));

            //Act
            testBug.UnassignMember();

            //Assert
            Assert.IsNull(testBug.Assignee);
        }
    }
}
