using System.Net.Http;

namespace Router.Exceptions;

public class CasedevUnprocessableEntityException : Casedev4xxException
{
    public CasedevUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
