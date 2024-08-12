using WebAPI_new.Model;

namespace Repository_Example.Repository.Interfaces
{
    public interface IStudent
    {
        List<Student> getAllStudents();
        Student getStudentById(int id);

    }
}
