using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevUnauthorizedException : Casedev4xxException
{
    public CasedevUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
