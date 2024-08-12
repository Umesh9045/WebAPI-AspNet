using Microsoft.AspNetCore.Mvc;
using Repository_Example.Repository.Interfaces;
using WebAPI_new;
using WebAPI_new.Model;

namespace Repository_Example.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext context;

        public StudentRepository()
        {
        }

        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Student> getAllStudents()
        {
                //Console.WriteLine(context.Students_new.ToList());
                List<Student> result = context.Students_new.ToList();
                return result;
            
        }

        public Student getStudentById(int id)
        {
            Student result = context.Students_new.Find(id);
            return result;
        }
    }
}
