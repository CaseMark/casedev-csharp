using System;

namespace Router.Exceptions;

public class CasedevInvalidDataException : CasedevException
{
    public CasedevInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
