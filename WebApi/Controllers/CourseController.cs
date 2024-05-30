using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Interfaces;
using Infrastructure.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }


        [HttpPost]
        public async Task<ActionResult<CourseEntity>> CreateCourse([FromBody] CourseCreateRequest courseCreateRequest)
        {
            var course = await _courseService.CreateCourse(courseCreateRequest);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseUpdateRequest courseUpdateRequest)
        {
            if (id != courseUpdateRequest.Id)
            {
                return BadRequest("Course ID mismatch");
            }

            var updatedCourse = await _courseService.UpdateCourse(courseUpdateRequest);
            if (updatedCourse == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _courseService.DeleteCourse(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

