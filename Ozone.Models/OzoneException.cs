using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ozone.Models
{
    public class OzoneException : Exception
    {
        public OzoneException()
            : base()
        {

        }

        public OzoneException(string message)
            : base(message)
        {
        }

        public OzoneException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected OzoneException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
