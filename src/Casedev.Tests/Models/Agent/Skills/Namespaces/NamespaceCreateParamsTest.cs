using System;
using System.Text.Json;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Models.Agent.Skills.Namespaces;

public class NamespaceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamespaceCreateParams
        {
            NamespaceID = "namespaceId",
            Description = "description",
            Label = "label",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedNamespaceID = "namespaceId";
        string expectedDescription = "description";
        string expectedLabel = "label";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedNamespaceID, parameters.NamespaceID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedLabel, parameters.Label);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NamespaceCreateParams { NamespaceID = "namespaceId" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new NamespaceCreateParams
        {
            NamespaceID = "namespaceId",

            Description = null,
            Label = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Label);
        Assert.True(parameters.RawBodyData.ContainsKey("label"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        NamespaceCreateParams parameters = new() { NamespaceID = "namespaceId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/agent/skills/namespaces"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamespaceCreateParams
        {
            NamespaceID = "namespaceId",
            Description = "description",
            Label = "label",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        NamespaceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
