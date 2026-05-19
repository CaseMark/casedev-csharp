using System;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Models.Agent.Skills.Namespaces;

public class NamespacePullParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamespacePullParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamespacePullParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/skills/namespaces/id/pull"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamespacePullParams { ID = "id" };

        NamespacePullParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
