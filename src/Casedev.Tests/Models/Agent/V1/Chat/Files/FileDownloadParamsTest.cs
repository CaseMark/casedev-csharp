using System;
using Casedev.Models.Agent.V1.Chat.Files;

namespace Casedev.Tests.Models.Agent.V1.Chat.Files;

public class FileDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDownloadParams { ID = "id", Path = "path" };

        string expectedID = "id";
        string expectedPath = "path";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPath, parameters.Path);
    }

    [Fact]
    public void Url_Works()
    {
        FileDownloadParams parameters = new() { ID = "id", Path = "path" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/chat/id/files/path"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDownloadParams { ID = "id", Path = "path" };

        FileDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
