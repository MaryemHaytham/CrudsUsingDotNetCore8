using Cruds.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services_Abstraction;

namespace CrudUsingDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;


        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEnrollment()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);

            if (enrollment == null)
            {
                return NotFound("Not Found");
            }

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentViewModel enrollmentViewModel)
        {
            var enrollment = await _enrollmentService.CreateEnrollmentAsync(enrollmentViewModel.StudentId, enrollmentViewModel.CourseId);
            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollmentViewModel.StudentId, courseId = enrollmentViewModel.CourseId }, enrollment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}
