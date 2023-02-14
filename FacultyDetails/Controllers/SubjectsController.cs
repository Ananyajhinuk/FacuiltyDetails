using FacRepository;
using FacRepository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private ISubjectsRepository subjectsRepository;
        public SubjectsController(ISubjectsRepository subjectsRepository)
        {
            this.subjectsRepository = subjectsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            SubjectsRepository subjectsRepository = new SubjectsRepository();
            var subList = subjectsRepository.GetSubjects();

            return Ok(subList);
        }

        [HttpPost]
        public IActionResult Post(Subject newSubject)
        {
            subjectsRepository.addSubjects(newSubject);
            return Ok(newSubject);
        }
        [HttpDelete]
        public IActionResult Delete(Subject delSubject)
        {
            subjectsRepository.deleteSubjects(delSubject);
            return Ok(delSubject);
        }
        [HttpPut]
        public IActionResult Put(short id, Subject udtSubject)
        {
            subjectsRepository.updateSubjects(id, udtSubject);
            return Ok(udtSubject);
        }
    }
}
