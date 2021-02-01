using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogException(string message, params object[] ex);
    }
}
