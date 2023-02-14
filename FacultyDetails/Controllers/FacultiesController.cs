using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacRepository;
using FacRepository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FacultyDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private IFacultiesRepository facultiesRepository;
        private ProjectContext _context;
        private IConfiguration _configuration;

        public FacultiesController( IFacultiesRepository facultiesRepository,IConfiguration configuration, ProjectContext context) {
            this.facultiesRepository = facultiesRepository;
            _context = context;
            _configuration = configuration;
        }

        [Authorize(Roles = "Administrator,Faculty")]
        [HttpGet]
        public IActionResult Get()
        {
            FacultiesRepository facultiesRepository = new FacultiesRepository();
            var facList = facultiesRepository.GetFaculties();

            return Ok(facList);
        }

        [Authorize(Roles = "Administrator,Faculty")]
        [HttpPost]
        public IActionResult Post(Faculty newFaculty)
        {
            facultiesRepository.addFaculty(newFaculty);
            return Ok(newFaculty);
        }
        [Authorize(Roles = "Administrator,Faculty")]
        [HttpDelete]
        public IActionResult Delete(Faculty delFaculty)
        {
            facultiesRepository.deleteFaculty(delFaculty);
            return Ok(delFaculty);
        }
        [Authorize(Roles = "Administrator,Faculty")]
        [HttpPut]
        public IActionResult Put(short id,Faculty udtFaculty)
        {
            facultiesRepository.updateFaculty(id,udtFaculty);
            return Ok(udtFaculty);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/Login2")]
        public async Task<IActionResult> getFaculty(UserFaculty _userData)
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
                        new Claim("FacultyId", user.UserId.ToString()),
                        new Claim("FacultyName", user.UserName),

                        new Claim(ClaimTypes.Role, "Faculty")

                    };
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
        private async Task<UserFaculty> GetAdmin(string name, string password)
        {
            return await _context.UserFaculties.FirstOrDefaultAsync(u => u.UserName == name && u.Password == password);
        }

    }

}

