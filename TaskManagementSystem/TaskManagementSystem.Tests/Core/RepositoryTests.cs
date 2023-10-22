using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.Core
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository repository;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void CreateTeam_Should_AddNewTeamToCollection()
        {
            //Act
            repository.CreateTeam("Tigrite");

            //Assert
            Assert.AreEqual(1, repository.Teams.Count);
        }
        [TestMethod]
        public void GetTeam_Should_ThrowException_When_TeamNotFound()
        {
            //Assert
            Assert.ThrowsException<InvalidTeamException>(() => repository.GetTeam("NewTeam"));
        }
        [TestMethod]
        public void GetTeam_Should_ReturnTeamWithGivenName()
        {
            //Arrange
            string name = "NewTeam";
            repository.CreateTeam(name);
            //Act
            ITeam sut = repository.GetTeam(name);
            //Assert
            Assert.AreEqual(sut.Name, name);
        }
        [TestMethod]
        public void TeamExists_Should_ReturnTrue_WhenThereIsSuchTeam()
        {
            //Arrange
            string name = new string('a', 10);
            repository.CreateTeam(name);
            //Act & Assert
            Assert.IsTrue(repository.TeamExists(name));
        }
        [TestMethod]
        public void TeamExists_Should_ReturnFalse_WhenThereIsNoSuchTeam()
        {
            //Act & Assert
            Assert.IsFalse(repository.TeamExists("WrongTeamName"));
        }
        [TestMethod]
        public void CreateComment_Should_ReturnNewComment()
        {
            string message = "Nice work!", author = "Tony1293";
            //Act
            IComment sut = repository.CreateComment(message, author);
            //Assert
            Assert.AreEqual(sut.Message, message);
            Assert.AreEqual(sut.Author, author);
        }
        [TestMethod]
        public void CreateBug_Should_AddNewBugToCollection()
        {
            //Act
            repository.CreateBug("Problem2Title", "Cannot function",
                PriorityType.Medium, SeverityType.Minor, new List<string> { "first", "second" });
            //Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        public void CreateStory_Should_AddNewStoryToCollection()
        {
            repository.CreateStory("StoryTitle", "StoryDescription", SizeType.Small, PriorityType.High);
            //Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        public void CreateFeedback_Should_AddNewFeedbackToCollection()
        {
            repository.CreateFeedback("FeedbackTitle", "FeedbackDescription", 3);
            //Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        public void GetBug_Should_ThrowException_When_BugDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidBugException>(() => repository.GetBug("invalidTitle"));
        }
        [TestMethod]
        public void GetBug_Should_ReturnBug_WhenBugExists()
        {
            //Arrange
            string title = "ValidTitle";
            repository.CreateBug(title, new string('a', 15), PriorityType.Low, SeverityType.Minor, new List<string>());
            //Act
            IBug sut = repository.GetBug(title);
            //Assert
            Assert.AreEqual(sut.Title, title);
        }
        [TestMethod]
        public void GetStory_Should_ThrowException_When_StoryDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidStoryException>(() => repository.GetStory("invalidTitle"));
        }
        [TestMethod]
        public void GetStory_Should_ReturnStory_WhenStoryExists()
        {
            //Arrange
            string title = "ValidTitle";
            repository.CreateStory(title, new string('a', 15), SizeType.Small, PriorityType.Low);
            //Act
            IStory sut = repository.GetStory(title);
            //Assert
            Assert.AreEqual(sut.Title, title);
        }
        [TestMethod]
        public void GetFeedback_Should_ThrowException_When_FeedbackDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidFeedbackException>(() => repository.GetFeedback("invalidTitle"));
        }
        [TestMethod]
        public void GetFeedback_Should_ReturnFeedback_WhenFeedbackExists()
        {
            //Arrange
            string title = "ValidTitle";
            repository.CreateFeedback(title, new string('a', 15), 1);
            //Act
            IFeedback sut = repository.GetFeedback(title);
            //Assert
            Assert.AreEqual(sut.Title, title);
        }
        [TestMethod]
        public void GetTask_Should_ThrowException_When_TaskDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidTaskException>(() => repository.GetTask("invalidTitle"));
        }
        [TestMethod]
        public void GetTask_Should_ReturnTask_WhenTaskExists()
        {
            //Arrange
            string title = "ValidTitle";
            repository.CreateFeedback(title, new string('a', 15), 1);
            //Act
            ITask sut = repository.GetTask(title);
            //Assert
            Assert.AreEqual(sut.Title, title);
        }
        [TestMethod]
        public void CreateMember_Should_AddNewMemberToCollection()
        {
            //Act
            repository.CreateMember("GoshkoKolev");
            //Assert
            Assert.AreEqual(1, repository.Members.Count);
        }
        [TestMethod]
        public void GetMember_Should_ThrowException_When_MemberDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidMemberException>(() => repository.GetMember("Ivelin"));
        }
        [TestMethod]
        public void GetMember_Should_ReturnMember_WhenMemberExists()
        {
            //Arrange
            string name = "NewMember";
            repository.CreateMember(name);
            //Act
            IMember sut = repository.GetMember(name);
            //Assert
            Assert.AreEqual(sut.Name, name);
        }
        [TestMethod]
        public void CreateBoard_Should_AddBoardToCollection()
        {
            //Act
            repository.CreateBoard("NewBoard");
            //Assert
            Assert.AreEqual(1, repository.Boards.Count);
        }
        [TestMethod]
        public void GetBoard_Should_ThrowException_When_BoardDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidBoardException>(() => repository.GetBoard("InvalidBoard"));
        }
        [TestMethod]
        public void GetBoard_Should_ReturnBoard_WhenBoardExists()
        {
            //Arrange
            string name = "ValidName";
            repository.CreateBoard(name);
            //Act
            IBoard sut = repository.GetBoard(name);
            //Assert
            Assert.AreEqual(sut.Name, name);
        }
        [TestMethod]
        public void UpdateBugPriority_Should_ChangePriority_IfNewPriorityIsDifferentThanCurrentOne()
        {
            IBug sut = repository.CreateBug("ValidTitle", new string('a', 15), PriorityType.Low, SeverityType.Minor, new List<string>());
            //Act
            repository.UpdateBugPriority(sut, PriorityType.Medium);
            //Act & Assert
            Assert.IsTrue(sut.Priority == PriorityType.Medium);
        }
        [TestMethod]
        public void UpdateBugPriority_Should_ReturnBugWithNewPriority_IfNewPriorityIsDifferentThanCurrentOne()
        {
            //Arrange
            IBug sut = repository.CreateBug
                ("ValidTitle", new string('a', 15), PriorityType.Low, SeverityType.Minor, new List<string>());
            IBug updatedSut = repository.UpdateBugPriority(sut, PriorityType.Medium);
            //Act & Assert
            Assert.AreEqual(updatedSut.Priority, PriorityType.Medium);
        }
        [TestMethod]
        public void UpdateStoryPriority_Should_ReturnStoryWithNewPriority_IfNewPriorityIsDifferentThanCurrentOne()
        {
            //Arrange
            IStory sut = repository.CreateStory
                ("ValidTitle", new string('a', 15), SizeType.Small, PriorityType.Low);
            IStory updatedSut = repository.UpdateStoryPriority(sut, PriorityType.Medium);
            //Act & Assert
            Assert.AreEqual(updatedSut.Priority, PriorityType.Medium);
        }
        [TestMethod]
        public void UpdateStoryPriority_Should_ChangePriority_IfNewPriorityIsDifferentThanCurrentOne()
        {
            IStory sut = repository.CreateStory("ValidTitle", new string('a', 15), SizeType.Small, PriorityType.Low);
            //Act
            repository.UpdateStoryPriority(sut, PriorityType.Medium);
            //Act & Assert
            Assert.IsTrue(sut.Priority == PriorityType.Medium);
        }
        [TestMethod]
        public void UpdateFeedbackRating_Should_ReturnFeedback_IfRatingIsNotNegative()
        {
            //Arrange
            IFeedback sut = repository.CreateFeedback
                ("ValidTitle", new string('a', 15), 5);
            IFeedback updatedSut = repository.UpdateFeedbackRating(sut, 4);
            //Act & Assert
            Assert.AreEqual(updatedSut.Rating, 4);
        }
        [TestMethod]
        public void UpdateBugSeverity_Should_ChangeSeverity_IfValid()
        {
            //Arrange
            IBug sut = repository.CreateBug
                ("ValidTitle", new string('a', 15), PriorityType.Low, SeverityType.Minor, new List<string>());
            //Act
            IBug updatedSut = repository.UpdateBugSeverity(sut, SeverityType.Critical);
            //Assert
            Assert.AreEqual(updatedSut.Severity, SeverityType.Critical);
        }
        [TestMethod]
        public void UpdateStorySize_Should_ChangeSize_IfValid()
        {
            //Arrange
            IStory sut = repository.CreateStory("StoryTitle", "StoryDescription", SizeType.Small, PriorityType.High);
            //Act
            sut.SetSize(SizeType.Medium);
            //Assert
            Assert.AreEqual(sut.Size, SizeType.Medium);
        }
        [TestMethod]
        public void UpdateBugStatus_Should_ChangeStatus_IfValid()
        {
            //Arrange
            IBug sut = repository.CreateBug
                ("ValidTitle", new string('a', 15), PriorityType.Low, SeverityType.Minor, new List<string>());
            //Act
            repository.UpdateBugStatus(sut, BugStatusType.Fixed);
            //Assert
            Assert.AreEqual(sut.Status, BugStatusType.Fixed);
        }
        [TestMethod]
        public void UpdateFeedbackStatus_Should_ChangeStatus_IfValid()
        {
            //Arrange
            IFeedback sut = repository.CreateFeedback
                ("ValidTitle", new string('a', 15), 1);
            //Act
            repository.UpdateFeedbackStatus(sut, FeedbackStatusType.Scheduled);
            //Assert
            Assert.AreEqual(sut.Status, FeedbackStatusType.Scheduled);
        }
        [TestMethod]
        public void UpdateStoryStatus_Should_ChangeStatus_IfValid()
        {
            //Arrange
            IStory sut = repository.CreateStory
                ("ValidTitle", new string('a', 15), SizeType.Small, PriorityType.High);
            //Act
            repository.UpdateStoryStatus(sut, StoryStatusType.InProgress);
            //Assert
            Assert.AreEqual(sut.Status, StoryStatusType.InProgress);
        }

    }
}
