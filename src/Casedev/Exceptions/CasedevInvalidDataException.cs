using System;

namespace Casedev.Exceptions;

public class CasedevInvalidDataException : CasedevException
{
    public CasedevInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
