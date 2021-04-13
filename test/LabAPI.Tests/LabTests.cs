using System;
using Xunit;
using LabAPI.Models;

namespace LabAPI.Tests
{
    public class LabTests : IDisposable
    {
        Student testStudent;
        public LabTests()
        {
            testStudent = new Student
            {
                Index = 121111, 
                Grade = 5, 
                Score= 100, 
                Name = "Jas", 
                Surrname = "Abacki", 
                Description = "Great!" 
            };
        }
        public void Dispose()
        {
            testStudent = null;
        }

        [Fact]
        public void CanChangeDescription()
        {
            //Arrange

            //Act
            testStudent.Description = "Great job done!";

            //Assert
            Assert.Equal("Great job done!", testStudent.Description);
        }
        [Fact]
        public void CanChangeGrade()
        {
            //Arrange
           
            //Act
            testStudent.Score = 3;

            //Assert
            Assert.Equal(3, testStudent.Score);
        }
        [Fact]
        public void CanChangeScore()
        {
            //Arrange
            
            //Act
            testStudent.Score =50;

            //Assert
            Assert.Equal(50, testStudent.Score);
        }

       
    }
}
