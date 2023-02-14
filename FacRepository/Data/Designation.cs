using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Designation
    {
        public Designation()
        {
            Faculties = new HashSet<Faculty>();
        }

        public short DesignationId { get; set; }
        public string? DesignationName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
