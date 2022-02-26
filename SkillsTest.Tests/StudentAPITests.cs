using University.API.Services;
using Xunit;

namespace University.API.Tests
{
    public class StudentAPITests
    {
        private DbStudentAPI api = new DbStudentAPI(DataContextHelper.GetMockDb(nameof(StudentAPITests)));

        [Fact]
        public void Can_Get_Student_With_Id_1()
        {
            var student = api.GetStudent(1);

            Assert.NotNull(student);
        }
    }
}