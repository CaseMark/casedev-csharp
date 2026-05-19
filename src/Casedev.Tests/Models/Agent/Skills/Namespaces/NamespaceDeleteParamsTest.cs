using System;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Models.Agent.Skills.Namespaces;

public class NamespaceDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamespaceDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamespaceDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/skills/namespaces/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamespaceDeleteParams { ID = "id" };

        NamespaceDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
