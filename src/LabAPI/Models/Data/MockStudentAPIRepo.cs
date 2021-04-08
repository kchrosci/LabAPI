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
            throw new System.NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new System.NotImplementedException();
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