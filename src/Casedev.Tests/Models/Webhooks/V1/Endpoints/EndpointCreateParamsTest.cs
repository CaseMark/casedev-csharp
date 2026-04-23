using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointCreateParams
        {
            EventTypeFilters = ["string"],
            UrlValue = "https://example.com",
            Description = "description",
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },
        };

        List<string> expectedEventTypeFilters = ["string"];
        string expectedUrlValue = "https://example.com";
        string expectedDescription = "description";
        ResourceScopes expectedResourceScopes = new()
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

        Assert.Equal(expectedEventTypeFilters.Count, parameters.EventTypeFilters.Count);
        for (int i = 0; i < expectedEventTypeFilters.Count; i++)
        {
            Assert.Equal(expectedEventTypeFilters[i], parameters.EventTypeFilters[i]);
        }
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedResourceScopes, parameters.ResourceScopes);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointCreateParams
        {
            EventTypeFilters = ["string"],
            UrlValue = "https://example.com",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ResourceScopes);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceScopes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EndpointCreateParams
        {
            EventTypeFilters = ["string"],
            UrlValue = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Description = null,
            ResourceScopes = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ResourceScopes);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceScopes"));
    }

    [Fact]
    public void Url_Works()
    {
        EndpointCreateParams parameters = new()
        {
            EventTypeFilters = ["string"],
            UrlValue = "https://example.com",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/webhooks/v1/endpoints"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointCreateParams
        {
            EventTypeFilters = ["string"],
            UrlValue = "https://example.com",
            Description = "description",
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },
        };

        EndpointCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ResourceScopesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResourceScopes { MatterIds = ["string"], VaultIds = ["string"] };

        List<string> expectedMatterIds = ["string"];
        List<string> expectedVaultIds = ["string"];

        Assert.NotNull(model.MatterIds);
        Assert.Equal(expectedMatterIds.Count, model.MatterIds.Count);
        for (int i = 0; i < expectedMatterIds.Count; i++)
        {
            Assert.Equal(expectedMatterIds[i], model.MatterIds[i]);
        }
        Assert.NotNull(model.VaultIds);
        Assert.Equal(expectedVaultIds.Count, model.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], model.VaultIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResourceScopes { MatterIds = ["string"], VaultIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceScopes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResourceScopes { MatterIds = ["string"], VaultIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceScopes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedMatterIds = ["string"];
        List<string> expectedVaultIds = ["string"];

        Assert.NotNull(deserialized.MatterIds);
        Assert.Equal(expectedMatterIds.Count, deserialized.MatterIds.Count);
        for (int i = 0; i < expectedMatterIds.Count; i++)
        {
            Assert.Equal(expectedMatterIds[i], deserialized.MatterIds[i]);
        }
        Assert.NotNull(deserialized.VaultIds);
        Assert.Equal(expectedVaultIds.Count, deserialized.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], deserialized.VaultIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResourceScopes { MatterIds = ["string"], VaultIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResourceScopes { };

        Assert.Null(model.MatterIds);
        Assert.False(model.RawData.ContainsKey("matterIds"));
        Assert.Null(model.VaultIds);
        Assert.False(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResourceScopes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResourceScopes
        {
            // Null should be interpreted as omitted for these properties
            MatterIds = null,
            VaultIds = null,
        };

        Assert.Null(model.MatterIds);
        Assert.False(model.RawData.ContainsKey("matterIds"));
        Assert.Null(model.VaultIds);
        Assert.False(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResourceScopes
        {
            // Null should be interpreted as omitted for these properties
            MatterIds = null,
            VaultIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResourceScopes { MatterIds = ["string"], VaultIds = ["string"] };

        ResourceScopes copied = new(model);

        Assert.Equal(model, copied);
    }
}
