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
        Assert.True(JsonElement.DeepEquals(expectedDefinition, model.Definition));
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedWebhookEndpointID, model.WebhookEndpointID);
    }
}
