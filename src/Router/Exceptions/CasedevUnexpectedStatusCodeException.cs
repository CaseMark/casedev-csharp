using System.Net.Http;

namespace Router.Exceptions;

public class CasedevUnexpectedStatusCodeException : CasedevApiException
{
    public CasedevUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
