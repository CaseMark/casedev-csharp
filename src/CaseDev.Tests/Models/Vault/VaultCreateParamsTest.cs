using System;
using System.Text.Json;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",
            Description = "Repository for all client contract reviews and analysis",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "containsPHI": true,
                  "hipaaCompliant": true
                }
                """
            ),
        };

        string expectedName = "Contract Review Archive";
        string expectedDescription = "Repository for all client contract reviews and analysis";
        bool expectedEnableGraph = true;
        bool expectedEnableIndexing = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "containsPHI": true,
              "hipaaCompliant": true
            }
            """
        );

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnableGraph, parameters.EnableGraph);
        Assert.Equal(expectedEnableIndexing, parameters.EnableIndexing);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultCreateParams { Name = "Contract Review Archive" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.EnableIndexing);
        Assert.False(parameters.RawBodyData.ContainsKey("enableIndexing"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",

            // Null should be interpreted as omitted for these properties
            Description = null,
            EnableGraph = null,
            EnableIndexing = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.EnableIndexing);
        Assert.False(parameters.RawBodyData.ContainsKey("enableIndexing"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultCreateParams parameters = new() { Name = "Contract Review Archive" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",
            Description = "Repository for all client contract reviews and analysis",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "containsPHI": true,
                  "hipaaCompliant": true
                }
                """
            ),
        };

        VaultCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
