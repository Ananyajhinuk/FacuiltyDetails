using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class Publication
    {
        public short PublicationId { get; set; }
        public short? FacultyId { get; set; }
        public string? PublicationTitle { get; set; }
        public string? ArticleName { get; set; }
        public string? PublisherName { get; set; }
        public string? PublicationLocation { get; set; }
        public DateTime? CitationDate { get; set; }

        public virtual Faculty? Faculty { get; set; }
    }
}
