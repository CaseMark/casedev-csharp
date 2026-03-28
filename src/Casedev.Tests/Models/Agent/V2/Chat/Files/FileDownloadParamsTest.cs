using System;
using Casedev.Models.Agent.V2.Chat.Files;

namespace Casedev.Tests.Models.Agent.V2.Chat.Files;

public class FileDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDownloadParams { ID = "id", FilePath = "filePath" };

        string expectedID = "id";
        string expectedFilePath = "filePath";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFilePath, parameters.FilePath);
    }

    [Fact]
    public void Url_Works()
    {
        FileDownloadParams parameters = new() { ID = "id", FilePath = "filePath" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v2/chat/id/files/filePath"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDownloadParams { ID = "id", FilePath = "filePath" };

        FileDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
