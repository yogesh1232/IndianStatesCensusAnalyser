using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;

        // declared types of exception
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }
      
        // parameterized constructor
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.type = exceptionType;
        }
    }
}
