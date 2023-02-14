using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Course
    {
        public Course()
        {
            CoursesTaughts = new HashSet<CoursesTaught>();
            Subjects = new HashSet<Subject>();
        }

        public short CourseId { get; set; }
        public string? CourseName { get; set; }
        public short? CourseCredits { get; set; }
        public short? DeptId { get; set; }

        public virtual Department? Dept { get; set; }
        public virtual ICollection<CoursesTaught> CoursesTaughts { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
