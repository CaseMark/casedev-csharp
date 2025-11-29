using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevUnexpectedStatusCodeException : CasedevApiException
{
    public CasedevUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
