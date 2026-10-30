using CourseRegistration.Model;
using CourseRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistration.Tests
{
    public class EnrollmentServiceTests
    {
        private EnrollmentService CreateService()
        {
            var course = new Course
            {
                CourseId = 1,
                CourseName = "C# Programming",
                Capacity = 3
            };

            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "A", HasCompletedPrerequisite = true },
                new Student { StudentId = 2, StudentName = "B", HasCompletedPrerequisite = true },
                new Student { StudentId = 3, StudentName = "C", HasCompletedPrerequisite = true },
                new Student { StudentId = 4, StudentName = "D", HasCompletedPrerequisite = true },
                new Student { StudentId = 5, StudentName = "E", HasCompletedPrerequisite = false }
            };

            return new EnrollmentService(course, students);
        }

        [Fact]
        public void EnrollStudent_WhenSeatAvailable_ShouldEnrollSuccessfully()
        {
            // Arrange
            var service = CreateService();

            // Act
            var result = service.EnrollStudent(1);

            // Assert
            Assert.Equal("Student enrolled successfully.", result);
            Assert.Single(service.Enrollments);
        }
    }
}
