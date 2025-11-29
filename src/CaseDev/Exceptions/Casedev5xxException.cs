using System.Net.Http;

namespace CaseDev.Exceptions;

public class Casedev5xxException : CasedevApiException
{
    public Casedev5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
