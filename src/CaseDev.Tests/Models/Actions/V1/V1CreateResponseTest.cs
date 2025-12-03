using System.Text.Json;
using CaseDev.Models.Actions.V1;

namespace CaseDev.Tests.Models.Actions.V1;

public class V1CreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CreatedBy = "createdBy",
            Definition = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            UpdatedAt = "updatedAt",
            Version = 0,
            WebhookEndpointID = "webhookEndpointId",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedCreatedBy = "createdBy";
        JsonElement expectedDefinition = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedOrganizationID = "organizationId";
        string expectedUpdatedAt = "updatedAt";
        double expectedVersion = 0;
        string expectedWebhookEndpointID = "webhookEndpointId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.True(
            model.Definition.HasValue
                && JsonElement.DeepEquals(expectedDefinition, model.Definition.Value)
        );
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedWebhookEndpointID, model.WebhookEndpointID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CreatedBy = "createdBy",
            Definition = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            UpdatedAt = "updatedAt",
            Version = 0,
            WebhookEndpointID = "webhookEndpointId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CreatedBy = "createdBy",
            Definition = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            UpdatedAt = "updatedAt",
            Version = 0,
            WebhookEndpointID = "webhookEndpointId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedCreatedBy = "createdBy";
        JsonElement expectedDefinition = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedOrganizationID = "organizationId";
        string expectedUpdatedAt = "updatedAt";
        double expectedVersion = 0;
        string expectedWebhookEndpointID = "webhookEndpointId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.True(
            deserialized.Definition.HasValue
                && JsonElement.DeepEquals(expectedDefinition, deserialized.Definition.Value)
        );
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedWebhookEndpointID, deserialized.WebhookEndpointID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CreatedBy = "createdBy",
            Definition = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            UpdatedAt = "updatedAt",
            Version = 0,
            WebhookEndpointID = "webhookEndpointId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("createdBy"));
        Assert.Null(model.Definition);
        Assert.False(model.RawData.ContainsKey("definition"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
        Assert.Null(model.WebhookEndpointID);
        Assert.False(model.RawData.ContainsKey("webhookEndpointId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1CreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            Definition = null,
            Description = null,
            IsActive = null,
            Name = null,
            OrganizationID = null,
            UpdatedAt = null,
            Version = null,
            WebhookEndpointID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("createdBy"));
        Assert.Null(model.Definition);
        Assert.False(model.RawData.ContainsKey("definition"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
        Assert.Null(model.WebhookEndpointID);
        Assert.False(model.RawData.ContainsKey("webhookEndpointId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            Definition = null,
            Description = null,
            IsActive = null,
            Name = null,
            OrganizationID = null,
            UpdatedAt = null,
            Version = null,
            WebhookEndpointID = null,
        };

        model.Validate();
    }
}
