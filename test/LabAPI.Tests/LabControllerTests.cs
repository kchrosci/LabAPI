using System;
using System.Collections.Generic;
using Xunit;
using LabAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoMapper;
using LabAPI.Models;
using LabAPI.Data;
using LabAPI.Profiles;
using LabAPI.Dtos;

namespace LabAPI.Tests
{
    public class LabControllerTests : IDisposable
    {
        Mock<ILabAPIRepo> mockRepo;
        StudentProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public LabControllerTests()
        {
            mockRepo = new Mock<ILabAPIRepo>();
            realProfile = new StudentProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetStudentItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            var student = new LabController(mockRepo.Object,mapper);
        }


         [Fact]
        public void GetStudentItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo.Setup(repo => 
                repo.GetAllStudents()).Returns(GetStudents(0));

            var student = new LabController(mockRepo.Object,mapper);

            //Act
            var result = student.GetAllStudents();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetAllStudents_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllStudents()).Returns(GetStudents(1));
            var controller = new LabController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllStudents();
            //Assert
            var okResult = result.Result as OkObjectResult;
            var students = okResult.Value as List<StudentReadDto>;
            Assert.Single(students);
        }

        [Fact]
        public void GetAllStudents_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllStudents()).Returns(GetStudents(1));
            
            var controller = new LabController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllStudents();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
          
        [Fact]
        public void GetAllStudents_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllStudents()).Returns(GetStudents(1));
            
            var controller = new LabController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllStudents();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<StudentReadDto>>>(result);

        }

        [Fact]
        public void GetStudentByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetStudentById(0)).Returns(()=>null);
            
            var controller = new LabController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetStudentById(1);
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }

        
        [Fact]
        public void GetStudentByID_Returns200OK_WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetStudentById(1)).Returns( new Student 
                {
                    Index = 121111, 
                    Grade = 5, 
                    Score= 100, 
                    Name = "Jas", 
                    Surrname = "Abacki", 
                    Description = "Great!" 
                });
            
            var controller = new LabController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetStudentById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void GetStudentByID_ReturnsCorreectType_WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetStudentById(1)).Returns( new Student 
                {
                    Index = 121111, 
                    Grade = 5, 
                    Score= 100, 
                    Name = "Jas", 
                    Surrname = "Abacki", 
                    Description = "Great!" 
                });
            
            var controller = new LabController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetStudentById(1);
            //Assert
             Assert.IsType<ActionResult<StudentReadDto>>(result);
        }

       
        private List<Student> GetStudents(int num)
        {
            var students = new List<Student>();
               if(num>0)
                {
                    students.Add(new Student
                    {
                        Index = 121111, 
                        Grade = 5, 
                        Score= 100, 
                        Name = "Jas", 
                        Surrname = "Abacki", 
                        Description = "Great!" 
                    });
                }
            return students;
        }
        
    }
}