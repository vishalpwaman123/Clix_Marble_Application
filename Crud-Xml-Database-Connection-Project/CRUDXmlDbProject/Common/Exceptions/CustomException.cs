using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDXmlDbProject.Common.Exceptions
{
    public class CustomException : Exception
    {

        public enum ExceptionType
        {
            
        }

        public ExceptionType type;

        public CustomException(CustomException.ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
