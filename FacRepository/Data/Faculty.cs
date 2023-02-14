using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Faculty
    {
        public Faculty()
        {
            CoursesTaughts = new HashSet<CoursesTaught>();
            Degrees = new HashSet<Degree>();
            Publications = new HashSet<Publication>();
            WorkHistories = new HashSet<WorkHistory>();
        }

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

        public virtual Department? Dept { get; set; }
        public virtual Designation? Designation { get; set; }
        public virtual ICollection<CoursesTaught> CoursesTaughts { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<WorkHistory> WorkHistories { get; set; }
    }
}
