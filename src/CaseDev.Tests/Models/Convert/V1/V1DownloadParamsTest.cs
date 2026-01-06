using System;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1DownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DownloadParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        V1DownloadParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/download/id"), url);
    }
}
