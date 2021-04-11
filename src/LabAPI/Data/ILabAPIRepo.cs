using System.Collections.Generic;
using LabAPI.Models;

namespace LabAPI.Data
{
    public interface ILabAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student stud);
        void UpdateStudent(Student stud);
        void DeleteStudent(Student stud);
    }
}