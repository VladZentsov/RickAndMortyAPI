using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class EntityNorFoundException:Exception
    {
        public EntityNorFoundException()
        {

        }
        public EntityNorFoundException(string message) : base(message)
        {

        }
        public EntityNorFoundException(string message, string paramName) : base(message)
        {

        }

        public EntityNorFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNorFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
