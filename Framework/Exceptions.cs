using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Framework
{
    public class Exceptions
    {
        public class DataEmptyException : Exception
        {
            public DataEmptyException()
            {
            }

            public DataEmptyException(string message) : base(message)
            {
            }

            public DataEmptyException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}
