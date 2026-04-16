using System;
using Casedev.Models.Matters.V1.AgentTypes;

namespace Casedev.Tests.Models.Matters.V1.AgentTypes;

public class AgentTypeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentTypeListParams { Active = true };

        bool expectedActive = true;

        Assert.Equal(expectedActive, parameters.Active);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentTypeListParams { };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentTypeListParams
        {
            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentTypeListParams parameters = new() { Active = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/matters/v1/agent-types?active=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentTypeListParams { Active = true };

        AgentTypeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
