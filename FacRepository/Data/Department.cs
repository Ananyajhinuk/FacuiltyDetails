using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Faculties = new HashSet<Faculty>();
        }

        public short DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
