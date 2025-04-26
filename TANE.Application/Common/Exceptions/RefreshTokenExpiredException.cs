using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Common.Exceptions
{
    public class RefreshTokenExpiredException : Exception
    {
        public RefreshTokenExpiredException()
        {

        }

        public RefreshTokenExpiredException(string message)
            : base(message)
        {

        }

        public RefreshTokenExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
