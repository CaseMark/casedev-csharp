using System.Net.Http;

namespace Casedev.Exceptions;

public class Casedev5xxException : CasedevApiException
{
    public Casedev5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
