using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using University.Admin.Controllers;
using University.Admin.Entities;
using University.API.Services;
using Xunit;

namespace University.API.Tests
{
    public class StudentAPITests
    {
        private StudentsController _controller = new StudentsController(new StudentAPI(DataContextHelper.GetMockDb(nameof(StudentAPITests))));


        [Fact]
        public void Can_Get_Student_With_Id_1()
        {
            //Arrange
            var studentId = 1;

            //Act
            var result = _controller.GetStudent(studentId);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var studentResult = Assert.IsType<Student>(objectResult.Value);
            Assert.Equal(studentId, studentResult.Id);
        }

        [Fact]
        public void WillReturn_AllStudents_OnPageZero_WithPageSizeTen()
        {
            //Arrange
            int page = 0;
            int pageSize = 10;
            var expectedStudentIds = new List<int>() { 1, 10, 100, 11, 12, 13, 14, 15, 16, 17 };

            //Act
            var result = _controller.GetStudents(page, pageSize);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var studentsResult = Assert.IsType<List<Student>>(objectResult.Value);
            var studentIdsResult = studentsResult.Select(student => student.Id);
            Assert.Equal(expectedStudentIds, studentIdsResult);
        }

        [Fact]
        public void WillReturn_AllStudents_WhenPageNumberIsNull()
        {
            //Arrange
            int? page = null;
            int? pageSize = 10;

            //Act
            var result = _controller.GetStudents(page, pageSize);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var studentsResult = Assert.IsType<List<Student>>(objectResult.Value);
            Assert.Equal(100, studentsResult.Count());
        }


        [Fact]
        public void WillReturn_AllStudents_WithCourseId_2()
        {
            //Arrange
            var courseId = 2;

            //Act
            var result = _controller.GetStudentsInCourse(courseId);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var studentsResult = Assert.IsType<List<Student>>(objectResult.Value);
            Assert.True(studentsResult.All(student => student.Courses.Any(course => course.Id == courseId)));
        }

        [Fact]
        public void WillReturnAllStudents_WithLastName_Student_2()
        {
            //Arrange
            var lastName = "Student 2";

            //Act
            var result = _controller.GetStudents(lastName);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var studentsResult = Assert.IsType<List<Student>>(objectResult.Value);
            Assert.True(studentsResult.All(student => student.LastName.Equals(lastName)));
        }
    }
}