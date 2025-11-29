using System;
using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevIOException : CasedevException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public CasedevIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
