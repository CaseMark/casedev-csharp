using System.Net.Http;

namespace Router.Exceptions;

public class CasedevUnauthorizedException : Casedev4xxException
{
    public CasedevUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
