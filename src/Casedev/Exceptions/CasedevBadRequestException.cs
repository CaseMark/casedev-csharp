using System.Net.Http;

namespace Casedev.Exceptions;

public class CasedevBadRequestException : Casedev4xxException
{
    public CasedevBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
