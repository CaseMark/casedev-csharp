using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevNotFoundException : Casedev4xxException
{
    public CasedevNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
