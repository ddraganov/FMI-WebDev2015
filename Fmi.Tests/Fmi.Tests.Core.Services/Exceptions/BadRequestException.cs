using System;

namespace Fmi.Tests.Core.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = null)
            : base(message)
        { }
    }
}
