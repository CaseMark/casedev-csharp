using System;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Models.Agent.Skills.Namespaces;

public class NamespaceRotateTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamespaceRotateTokenParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamespaceRotateTokenParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/agent/skills/namespaces/id/rotate-token"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamespaceRotateTokenParams { ID = "id" };

        NamespaceRotateTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
