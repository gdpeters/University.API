using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using University.Admin.Entities;
using University.API.Controllers;
using University.API.Services;
using Xunit;

namespace University.API.Tests
{
    public class CoursesAPITests
    {
        private CoursesController _controller = new CoursesController(new CourseAPI(DataContextHelper.GetMockDb(nameof(CoursesAPITests))));

        [Fact]
        public void Can_Get_Course_With_Id_1()
        {
            //Arrange
            var courseId = 1;

            //Act
            var result = _controller.GetCourse(courseId);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var courseResult = Assert.IsType<Course>(objectResult.Value);
            Assert.Equal(courseId, courseResult.Id);
        }

        [Fact]
        public void WillReturn_AllCourses_OnPageZero_WithPageSizeOne()
        {
            //Arrange
            int? page = 0;
            int? pageSize = 1;

            //Act
            var result = _controller.GetCourses(page, pageSize);

            //Assert
            var expectedCourseId = 1;
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var coursesResult = Assert.IsType<List<Course>>(objectResult.Value);
            Assert.Equal(expectedCourseId, coursesResult.SingleOrDefault().Id);
        }

        [Fact]
        public void WillReturn_AllCourses_WhenPageNumberIsNull()
        {
            //Arrange
            int? page = null;
            int? pageSize = 1;

            //Act
            var result = _controller.GetCourses(page, pageSize);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var coursesResult = Assert.IsType<List<Course>>(objectResult.Value);
            Assert.Equal(3, coursesResult.Count);
        }

        [Fact]
        public void WillReturnCourse_WithName_AdvancedBasketweaving()
        {
            //Arrange
            var courseName = "Advanced Basketweaving";

            //Act
            var result = _controller.GetCourse(courseName);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var coursesResult = Assert.IsType<Course>(objectResult.Value);
            Assert.Equal(courseName, coursesResult.Name);
        }
    }
}