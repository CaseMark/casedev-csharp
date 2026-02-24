using System.Net.Http;

namespace Casedev.Exceptions;

public class CasedevUnauthorizedException : Casedev4xxException
{
    public CasedevUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
