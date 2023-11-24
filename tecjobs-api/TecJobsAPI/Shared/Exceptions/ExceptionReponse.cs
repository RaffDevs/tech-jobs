using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.Exceptions
{
    public class ExceptionReponse : Exception
    {
        public Boolean IsInternalError { get; set; }
        public ExceptionReponse(string message, bool internalError) : base(message)
        {
            IsInternalError = internalError;
        }
    }
}