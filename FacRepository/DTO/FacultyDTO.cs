using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacRepository.Data;
using FacRepository.DTO;

namespace FacRepository.DTO
{
    public class FacultyDTO
    {

        public short FacultyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Pincode { get; set; }
        public int? MobileNo { get; set; }
        public DateTime? HireDate { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public short? DeptId { get; set; }
        public short? DesignationId { get; set; }


    }
}
    

