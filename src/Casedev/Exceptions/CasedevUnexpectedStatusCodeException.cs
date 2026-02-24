using System.Net.Http;

namespace Casedev.Exceptions;

public class CasedevUnexpectedStatusCodeException : CasedevApiException
{
    public CasedevUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
