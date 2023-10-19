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
        public void CreateBug_Should_AddNewBugToCollection()
        {
            //Act
            repository.CreateBug("Problem2", "Cannot function",
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
        public void GetStory_Should_ThrowException_When_StoryDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidStoryException>(() => repository.GetStory("invalidTitle"));
        }
        [TestMethod]
        public void GetFeedback_Should_ThrowException_When_FeedbackDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidFeedbackException>(() => repository.GetFeedback("invalidTitle"));
        }
        [TestMethod]
        public void GetTask_Should_ThrowException_When_TaskDoesNotExist()
        {
            //Act & Assert
            Assert.ThrowsException<InvalidTaskException>(() => repository.GetTask("invalidTitle"));
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
        
        //todo
    }
}
