using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov.Exceptions
{
    public class NoNextStateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoNextStateException"/> class with a specified error message and a reference to the inner exception that is the cause of the exception.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="innerException"></param>
        public NoNextStateException(string msg = null, Exception innerException = null) : base(msg, innerException)
        {

        }
    }
}
