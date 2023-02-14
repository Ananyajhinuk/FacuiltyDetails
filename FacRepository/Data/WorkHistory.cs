using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class WorkHistory
    {
        public short WorkHistoryId { get; set; }
        public short? FacultyId { get; set; }
        public string? Organization { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? JobBeginDate { get; set; }
        public DateTime? JobEndDate { get; set; }
        public string? JobResponsibilities { get; set; }
        public string? JobType { get; set; }

        public virtual Faculty? Faculty { get; set; }
    }
}
