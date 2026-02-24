using System.Net.Http;

namespace Casedev.Exceptions;

public class CasedevForbiddenException : Casedev4xxException
{
    public CasedevForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
