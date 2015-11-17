using System;

namespace Fmi.Tests.Core.Handlers.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = null)
            : base(message)
        { }
    }
}
