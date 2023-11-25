using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecJobsAPI.Entities;

namespace TecJobsAPI.DTO
{
    public record UpdateCompanyDTO
    {
        public string Name { get; init; }

        public string AboutUs { get; init; }

        public UpdateCompanyDTO(string name, string aboutUs)
        {
            Name = name;
            AboutUs = aboutUs;
        }
    }
}