using FacRepository;
using FacRepository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICoursesRepository coursesRepository;
        public CoursesController(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }
        [HttpPost]
        public IActionResult PostCourse(Course newcourses )
        {   
            coursesRepository.addCourses(newcourses);
            return Ok(newcourses);
        }
        [HttpDelete]
        public IActionResult Delete(Course delCourses)
        {
            coursesRepository.deleteCourses(delCourses);
            return Ok(delCourses);
        }
        [HttpPut]
        public IActionResult Put(short id, Course udtCourses)
        {
            coursesRepository.updateCourses(id, udtCourses);
            return Ok(udtCourses);
        }
    }

}
