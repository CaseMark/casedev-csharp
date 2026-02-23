using System;
using Router.Models.Agent.V1.Agents;

namespace Router.Tests.Models.Agent.V1.Agents;

public class AgentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AgentRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/agents/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentRetrieveParams { ID = "id" };

        AgentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
