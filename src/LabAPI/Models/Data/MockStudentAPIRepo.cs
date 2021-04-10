using System.Collections.Generic;
using LabAPI.Models;

namespace LabAPI.Data
{
    public class MockStudentAPIRepo : IStudentAPIRepo
    {
        public void CreateStudent(Student stud)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(Student stud)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = new List<Student>
            {
                new Student{
                    Id = 0, 
                    Index = 111111, 
                    Grade = 5, 
                    Score= 100, 
                    Name = "Jas", 
                    Surrname = "Abacki", 
                    Description = "smth" 
                },
                 new Student{
                    Id = 1, 
                    Index = 211111, 
                    Grade = 2, 
                    Score= 40, 
                    Name = "Patryk", 
                    Surrname = "Babacki", 
                    Description = "smth worse" 
                }
            };
            return students;
        }

        public Student GetStudentById(int id)
        {
            return new Student{
                    Id = 1, 
                    Index = 211111, 
                    Grade = 2, 
                    Score= 40, 
                    Name = "Patryk", 
                    Surrname = "Babacki", 
                    Description = "smth worse" 
                };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStudent(Student stud)
        {
            throw new System.NotImplementedException();
        }
    }
}