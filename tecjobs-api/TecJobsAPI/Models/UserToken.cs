using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.Models
{
    public class UserToken
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }

        public string Message { get; set; }
    }
}