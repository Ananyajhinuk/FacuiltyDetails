using FacRepository;
using FacRepository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private IDepartmentsRepository departmentsRepository;

        public DepartmentsController(IDepartmentsRepository departmentsRepository)
        {
            this.departmentsRepository = departmentsRepository;
        }


        [HttpPost]
        public IActionResult Post(Department newDepartment )
        {
            departmentsRepository.addDepartments(newDepartment);
            return Ok(newDepartment);
        }
    }
}
