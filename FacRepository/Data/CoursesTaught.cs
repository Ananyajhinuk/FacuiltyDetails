using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class CoursesTaught
    {
        public short CourseId { get; set; }
        public short FacultyId { get; set; }
        public short SubjectId { get; set; }
        public DateTime? FirstDateTaught { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Faculty Faculty { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
