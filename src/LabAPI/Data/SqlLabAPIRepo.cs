using System.Collections.Generic;
using LabAPI.Models;
using System.Linq;
using System;

namespace LabAPI.Data{
    public class SqlLabAPIRepo : ILabAPIRepo
    {
        private readonly StudentContext _context;

        public SqlLabAPIRepo(StudentContext context){
            _context=context;
        }

        public void CreateStudent(Student stud)
        {
            if(stud==null){
                throw new ArgumentNullException(nameof(stud));
            }
            _context.StudentItems.Add(stud);
        }

        public void DeleteStudent(Student stud)
        {
           if(stud == null){
               throw new ArgumentNullException(nameof(stud));
           }
           _context.StudentItems.Remove(stud);
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student stud)
        {
            
        }
    }
}