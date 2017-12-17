using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Filesystem.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException()
        {
        }

        public InvalidConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
