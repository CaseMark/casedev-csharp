using System.Net.Http;

namespace Casedev.Exceptions;

public class Casedev4xxException : CasedevApiException
{
    public Casedev4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
