using System;

namespace Fmi.Tests.Core.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = null)
            : base(message)
        { }
    }
}
