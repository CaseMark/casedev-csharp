using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevRateLimitException : Casedev4xxException
{
    public CasedevRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
