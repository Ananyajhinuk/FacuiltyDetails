using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Subject
    {
        public Subject()
        {
            CoursesTaughts = new HashSet<CoursesTaught>();
            Courses = new HashSet<Course>();
        }

        public short SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<CoursesTaught> CoursesTaughts { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
