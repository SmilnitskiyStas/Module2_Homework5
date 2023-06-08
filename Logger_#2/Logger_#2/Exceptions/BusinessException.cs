using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger__2.Exceptions
{
    internal class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerExceprion)
            : base(message, innerExceprion)
        {
        }
    }
}
