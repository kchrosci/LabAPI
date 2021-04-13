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

namespace LabAPI.Tests
{
    public class LabControllerTests
    {
        [Fact]
        public void GetStudentItems_ReturnsZeroItems_WhenDBIsEmpty(){
            //Arrange
            var mockRepo = new Mock<ILabAPIRepo>();

            mockRepo.Setup(repo => 
                repo.GetAllStudents()).Returns(GetStudents(0));

            var realProfile = new StudentProfile();
            var configuration = new MapperConfiguration(cfg => 
                cfg.AddProfile(realProfile));

            IMapper mapper = new Mapper(configuration);
            var student = new LabController(mockRepo.Object,mapper);

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