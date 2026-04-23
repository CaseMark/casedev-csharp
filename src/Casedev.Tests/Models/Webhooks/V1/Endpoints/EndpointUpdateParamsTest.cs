using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            Description = "description",
            EventTypeFilters = ["string"],
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },
            Status = Status.Active,
            UrlValue = "https://example.com",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        List<string> expectedEventTypeFilters = ["string"];
        EndpointUpdateParamsResourceScopes expectedResourceScopes = new()
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };
        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedUrlValue = "https://example.com";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.EventTypeFilters);
        Assert.Equal(expectedEventTypeFilters.Count, parameters.EventTypeFilters.Count);
        for (int i = 0; i < expectedEventTypeFilters.Count; i++)
        {
            Assert.Equal(expectedEventTypeFilters[i], parameters.EventTypeFilters[i]);
        }
        Assert.Equal(expectedResourceScopes, parameters.ResourceScopes);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            Description = "description",
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },
        };

        Assert.Null(parameters.EventTypeFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypeFilters"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            Description = "description",
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },

            // Null should be interpreted as omitted for these properties
            EventTypeFilters = null,
            Status = null,
            UrlValue = null,
        };

        Assert.Null(parameters.EventTypeFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypeFilters"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            EventTypeFilters = ["string"],
            Status = Status.Active,
            UrlValue = "https://example.com",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ResourceScopes);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceScopes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            EventTypeFilters = ["string"],
            Status = Status.Active,
            UrlValue = "https://example.com",

            Description = null,
            ResourceScopes = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ResourceScopes);
        Assert.True(parameters.RawBodyData.ContainsKey("resourceScopes"));
    }

    [Fact]
    public void Url_Works()
    {
        EndpointUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/webhooks/v1/endpoints/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointUpdateParams
        {
            ID = "id",
            Description = "description",
            EventTypeFilters = ["string"],
            ResourceScopes = new() { MatterIds = ["string"], VaultIds = ["string"] },
            Status = Status.Active,
            UrlValue = "https://example.com",
        };

        EndpointUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EndpointUpdateParamsResourceScopesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EndpointUpdateParamsResourceScopes
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

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
        var model = new EndpointUpdateParamsResourceScopes
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EndpointUpdateParamsResourceScopes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EndpointUpdateParamsResourceScopes
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EndpointUpdateParamsResourceScopes>(
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
        var model = new EndpointUpdateParamsResourceScopes
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EndpointUpdateParamsResourceScopes { };

        Assert.Null(model.MatterIds);
        Assert.False(model.RawData.ContainsKey("matterIds"));
        Assert.Null(model.VaultIds);
        Assert.False(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EndpointUpdateParamsResourceScopes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EndpointUpdateParamsResourceScopes
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
        var model = new EndpointUpdateParamsResourceScopes
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
        var model = new EndpointUpdateParamsResourceScopes
        {
            MatterIds = ["string"],
            VaultIds = ["string"],
        };

        EndpointUpdateParamsResourceScopes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
