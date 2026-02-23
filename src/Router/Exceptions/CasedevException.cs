using System;
using System.Net.Http;

namespace Router.Exceptions;

public class CasedevException : Exception
{
    public CasedevException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected CasedevException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
