using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.DTO
{
    public record UserRegisterDTO
    {
        public string Name { get; init; }
        public string Email { get; init; }

        public string Password { get; init; }
        public string ConfirmPassword { get; init; }
    }
}