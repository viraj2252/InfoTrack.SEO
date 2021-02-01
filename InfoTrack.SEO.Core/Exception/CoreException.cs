using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.Core.Exception
{
    public class CoreException : System.Exception
    {
        internal CoreException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal CoreException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
