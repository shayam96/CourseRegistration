using CourseRegistration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("enroll/{studentId}")]
        public IActionResult Enroll(int studentId)
        {
            var result = _enrollmentService.EnrollStudent(studentId);

            if (result == "Student enrolled successfully.")
                return Ok(result);

            if (result == "Course is full. Student added to waitlist.")
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("drop/{studentId}")]
        public IActionResult Drop(int studentId)
        {
            var result = _enrollmentService.DropStudent(studentId);

            if (result == "Student dropped successfully.")
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                EnrolledStudents = _enrollmentService.Enrollments,
                WaitlistedStudents = _enrollmentService.Waitlist
            });
        }
    }
}
