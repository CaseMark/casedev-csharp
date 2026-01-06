using System;
using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1RetrieveExecutionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveExecutionParams { ID = "exec_abc123def456" };

        string expectedID = "exec_abc123def456";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        V1RetrieveExecutionParams parameters = new() { ID = "exec_abc123def456" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/templates/v1/executions/exec_abc123def456"),
            url
        );
    }
}
