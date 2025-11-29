using System.Net.Http;

namespace CaseDev.Exceptions;

public class CasedevBadRequestException : Casedev4xxException
{
    public CasedevBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
