using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class FilterNullException:Exception
    {
        public FilterNullException()
        {

        }
        public FilterNullException(string message) : base(message)
        {

        }
        public FilterNullException(string message, string paramName) : base(message)
        {

        }

        public FilterNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilterNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
