using RepositoryPattern.Data;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public class StudentRepositories : IStudent
    {
        private StudentContext _context;

        public StudentRepositories(StudentContext context)
        {
            _context = context;
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetByStudentID(int StudentID)
        {
            return _context.Students.Where(x => x.StudentID == StudentID).FirstOrDefault();
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
