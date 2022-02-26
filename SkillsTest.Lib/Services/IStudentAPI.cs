using System.Linq;
using University.Admin.DbContexts;
using University.Admin.Entities;

namespace University.API.Services
{
    public interface IStudentAPI
    {
        Student GetById(int id);
    }

    public class DbStudentAPI : IStudentAPI
    {
        public UniversityContext Db { get; set; }

        public Student GetById(int id)
        {
            return Db.Students.Where(student => student.Id == id).SingleOrDefault();
        }


    }
}
