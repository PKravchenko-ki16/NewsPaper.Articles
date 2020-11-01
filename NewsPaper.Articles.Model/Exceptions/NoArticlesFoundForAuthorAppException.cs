using System;
using System.Runtime.Serialization;

namespace NewsPaper.Articles.Models.Exceptions
{
    public class NoArticlesFoundForAuthorAppException : ApplicationException
    {
        public short CodeException => 0011;

        public NoArticlesFoundForAuthorAppException()
            : base(Base.Exceptions.NoArticlesFoundForAuthorException)
        {
        }

        public NoArticlesFoundForAuthorAppException(string message) : base(message) { }

        public NoArticlesFoundForAuthorAppException(string message, Exception inner) : base(message, inner) { }

        protected NoArticlesFoundForAuthorAppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}