using System.Net.Http;

namespace Router.Exceptions;

public class CasedevBadRequestException : Casedev4xxException
{
    public CasedevBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
