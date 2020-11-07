using System;
using System.Runtime.Serialization;

namespace NewsPaper.Articles.Models.Exceptions
{
    public class FailedTransferToArchiveAppException : ApplicationException
    {
        public short CodeException => 0013;

        public FailedTransferToArchiveAppException()
            : base(Base.Exceptions.FailedTransferToArchiveException)
        {
        }

        public FailedTransferToArchiveAppException(string message) : base(message) { }

        public FailedTransferToArchiveAppException(string message, Exception inner) : base(message, inner) { }

        protected FailedTransferToArchiveAppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}