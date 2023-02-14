using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Degree
    {
        public short DegreeId { get; set; }
        public short? FacultyId { get; set; }
        public string? Degree1 { get; set; }
        public string? Specialization { get; set; }
        public DateTime? DegreeYear { get; set; }
        public string? Grade { get; set; }

        public virtual Faculty? Faculty { get; set; }
    }
}
