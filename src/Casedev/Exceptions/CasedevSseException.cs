using System;

namespace Casedev.Exceptions;

public class CasedevSseException : CasedevException
{
    public CasedevSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
