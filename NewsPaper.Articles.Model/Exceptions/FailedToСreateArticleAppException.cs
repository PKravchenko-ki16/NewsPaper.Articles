using System;
using System.Runtime.Serialization;

namespace NewsPaper.Articles.Models.Exceptions
{
    public class FailedToCreateArticleAppException : ApplicationException
    {
        public short CodeException => 0012;

        public FailedToCreateArticleAppException()
            : base(Base.Exceptions.FailedToCreateArticleException)
        {
        }

        public FailedToCreateArticleAppException(string message) : base(message) { }

        public FailedToCreateArticleAppException(string message, Exception inner) : base(message, inner) { }

        protected FailedToCreateArticleAppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}