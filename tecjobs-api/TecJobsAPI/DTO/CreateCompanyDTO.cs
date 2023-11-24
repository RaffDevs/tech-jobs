using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.DTO
{
    public record CreateCompanyDTO
    {
        public string Name { get; init; }
        public string AboutUs { get; init; }

        public CreateCompanyDTO(string name, string aboutUs)
        {
            Name = name;
            AboutUs = aboutUs;
        }
    }
}