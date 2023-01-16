using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Validation
{
    public class EmptyResponseException:Exception
    {
        public EmptyResponseException()
        {

        }
        public EmptyResponseException(string message) : base(message)
        {

        }
        public EmptyResponseException(string message, string paramName) : base(message)
        {

        }

        public EmptyResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
