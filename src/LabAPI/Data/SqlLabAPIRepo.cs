using System.Collections.Generic;
using LabAPI.Models;
using System.Linq;

namespace LabAPI.Data{
    public class SqlLabAPIRepo : ILabAPIRepo
    {
        private readonly StudentContext _context;

        public SqlLabAPIRepo(StudentContext context){
            _context=context;
        }

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
           return _context.StudentItems.ToList();
        }

        public Student GetStudentById(int id)
        {
           return _context.StudentItems.FirstOrDefault(p => p.Id == id);
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