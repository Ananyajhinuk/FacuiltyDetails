using FacRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacRepository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FacultyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private IAdministratorRepository administratorRepository;
        private ProjectContext _context;
        private IConfiguration _configuration;
        public AdministratorsController(IAdministratorRepository administratoRepository, ProjectContext context, IConfiguration configuration)
        {
            this.administratorRepository = administratoRepository;
            _context = context;
            _configuration = configuration;
        }




        //public FacultiesController(IFacultiesRepository facultiesRepository)
        //{
        //    this.facultiesRepository = facultiesRepository;
        //}


        //Faculties
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add-faculty")]
        public IActionResult Post(Faculty newFaculty)
        {
            administratorRepository.addFaculty(newFaculty);
            return Ok(newFaculty);
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete-faculty")]
        public IActionResult Delete(Faculty delFaculty)
        {
            administratorRepository.deleteFaculty(delFaculty);
            return Ok(delFaculty);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("update-faculty")]
        public IActionResult Put(short id, Faculty udtFaculty)
        {
            administratorRepository.updateFaculty(id, udtFaculty);
            return Ok(udtFaculty);
        }

        //Courses
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add-course")]
        public IActionResult PostCourse(Course newcourses)
        {
            administratorRepository.addCourses(newcourses);
            return Ok(newcourses);
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete-course")]
        public IActionResult Delete(Course delCourses)
        {
            administratorRepository.deleteCourses(delCourses);
            return Ok(delCourses);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("update-course")]
        public IActionResult Put(short id, Course udtCourses)
        {
            administratorRepository.updateCourses(id, udtCourses);
            return Ok(udtCourses);
        }


        //Subjects
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("get-subject")]
        public IActionResult Get()
        {
            SubjectsRepository subjectsRepository = new SubjectsRepository();
            var subList = subjectsRepository.GetSubjects();

            return Ok(subList);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add-subject")]
        public IActionResult Post(Subject newSubject)
        {
            administratorRepository.addSubjects(newSubject);
            return Ok(newSubject);
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete-subject")]
        public IActionResult Delete(Subject delSubject)
        {
            administratorRepository.deleteSubjects(delSubject);
            return Ok(delSubject);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("delete-subject")]
        public IActionResult Put(short id, Subject udtSubject)
        {
            administratorRepository.updateSubjects(id, udtSubject);
            return Ok(udtSubject);
        }
        //Department
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add-department")]
        public IActionResult Post(Department newDepartment)
        {
            administratorRepository.addDepartments(newDepartment);
            return Ok(newDepartment);
        }


        // JWT
        [AllowAnonymous]
        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Post(UserAdministrator _userData)
        {
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                var user = await GetAdmin(_userData.UserName, _userData.Password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AdminId", user.UserId.ToString()),
                        new Claim("AdminName", user.UserName),

                        new Claim(ClaimTypes.Role, "Administrator")

                    };
                    //AuthenticatedId = user.CustomerId;
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private async Task<UserAdministrator> GetAdmin(string name, string password)
        {
            return await _context.UserAdministrators.FirstOrDefaultAsync(u => u.UserName == name && u.Password == password);
        }

    }
}
