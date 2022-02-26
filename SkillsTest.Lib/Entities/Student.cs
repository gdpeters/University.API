using System.Collections.Generic;

namespace University.Admin.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}