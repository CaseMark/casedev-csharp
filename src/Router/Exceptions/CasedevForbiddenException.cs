using System.Net.Http;

namespace Router.Exceptions;

public class CasedevForbiddenException : Casedev4xxException
{
    public CasedevForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
