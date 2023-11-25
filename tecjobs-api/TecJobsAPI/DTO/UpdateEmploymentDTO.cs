using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.DTO
{
    public record UpdateEmploymentDTO
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public int QtdPositions { get; init; }
        public string Requirements { get; init; }
        public DateTime PublishedAt { get; init; }
        public int CompanyId { get; init; }
    }
}