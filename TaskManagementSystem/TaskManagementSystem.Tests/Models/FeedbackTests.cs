using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.Models
{
    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Constructor_Should_CreateFeedback_WhenArgsAreValid()
        {
            //Arrange
            string title = "FeedbackTitle";
            //Act
            Feedback sut = new Feedback(1, title, "NewDescription", 5);
            //Assert
            Assert.AreEqual(title, sut.Title);
        }
        [TestMethod]
        public void AdvanceStatus_Should_ThrowException_When_StatusIsAlreadyAtLastStage()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "NewDescription", 5);
            sut.AdvanceStatus();
            sut.AdvanceStatus();
            sut.AdvanceStatus();

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.AdvanceStatus());
        }

        [TestMethod]
        public void AdvanceStatus_Should_ChangeStatus_When_StatusIsNotAtLastStage()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "NewDescription", 5);
            //Act
            sut.AdvanceStatus();
            //Assert
            Assert.AreEqual(sut.Status, FeedbackStatusType.Unscheduled);
        }
        [TestMethod]
        public void ReverseStatus_Should_ThrowException_When_StatusIsAlreadyAtFirstStage()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "NewDescription", 5);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.ReverseStatus());
        }
        [TestMethod]
        public void ReverseStatus_Should_ChangeStatus_When_StatusIsNotAtFirstStage()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "NewDescription", 5);
            sut.AdvanceStatus();
            //Act
            sut.ReverseStatus();
            //Assert
            Assert.AreEqual(sut.Status, FeedbackStatusType.New);
        }
        [TestMethod]
        public void SetRating_Should_ThrowException_When_RatingIsNegative()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "FeedbackDescription", 4);
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => sut.SetRating(-1));
        }
        [TestMethod]
        public void SetRating_Should_ChangeRating_When_RatingIsValid()
        {
            //Arrange
            Feedback sut = new Feedback(1, "FeedbackTitle", "FeedbackDescription", 4);
            //Act
            sut.SetRating(1);
            //Assert
            Assert.IsTrue(sut.Rating == 1);
        }
    }
}
