using System.Net.Http;

namespace Router.Exceptions;

public class CasedevNotFoundException : Casedev4xxException
{
    public CasedevNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
