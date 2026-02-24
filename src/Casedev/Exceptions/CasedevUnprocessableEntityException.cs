using System.Net.Http;

namespace Casedev.Exceptions;

public class CasedevUnprocessableEntityException : Casedev4xxException
{
    public CasedevUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
