using System;
using Casedev.Models.Agent.V2.Chat.Files;

namespace Casedev.Tests.Models.Agent.V2.Chat.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/v2/chat/id/files"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams { ID = "id" };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
