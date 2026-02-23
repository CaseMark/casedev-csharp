using System.Net.Http;

namespace Router.Exceptions;

public class CasedevRateLimitException : Casedev4xxException
{
    public CasedevRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
