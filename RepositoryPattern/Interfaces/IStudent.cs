using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Interfaces
{
    public interface IStudent
    {
        List<Student> GetAll();
        Student GetByStudentID(int StudentID);
        void Insert(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
