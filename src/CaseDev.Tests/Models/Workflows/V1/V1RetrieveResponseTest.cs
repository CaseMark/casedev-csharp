using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1RetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1RetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            DeploymentURL = "deploymentUrl",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Name = "name",
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedDeployedAt = "deployedAt";
        string expectedDeploymentURL = "deploymentUrl";
        string expectedDescription = "description";
        List<JsonElement> expectedEdges = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedName = "name";
        List<JsonElement> expectedNodes = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedTriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTriggerType = "triggerType";
        string expectedUpdatedAt = "updatedAt";
        string expectedVisibility = "visibility";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeployedAt, model.DeployedAt);
        Assert.Equal(expectedDeploymentURL, model.DeploymentURL);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEdges.Count, model.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEdges[i], model.Edges[i]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedNodes[i], model.Nodes[i]));
        }
        Assert.True(
            model.TriggerConfig.HasValue
                && JsonElement.DeepEquals(expectedTriggerConfig, model.TriggerConfig.Value)
        );
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVisibility, model.Visibility);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1RetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            DeploymentURL = "deploymentUrl",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Name = "name",
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1RetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            DeploymentURL = "deploymentUrl",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Name = "name",
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedDeployedAt = "deployedAt";
        string expectedDeploymentURL = "deploymentUrl";
        string expectedDescription = "description";
        List<JsonElement> expectedEdges = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedName = "name";
        List<JsonElement> expectedNodes = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedTriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTriggerType = "triggerType";
        string expectedUpdatedAt = "updatedAt";
        string expectedVisibility = "visibility";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeployedAt, deserialized.DeployedAt);
        Assert.Equal(expectedDeploymentURL, deserialized.DeploymentURL);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEdges.Count, deserialized.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEdges[i], deserialized.Edges[i]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedNodes[i], deserialized.Nodes[i]));
        }
        Assert.True(
            deserialized.TriggerConfig.HasValue
                && JsonElement.DeepEquals(expectedTriggerConfig, deserialized.TriggerConfig.Value)
        );
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVisibility, deserialized.Visibility);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1RetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            DeploymentURL = "deploymentUrl",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Name = "name",
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1RetrieveResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeployedAt);
        Assert.False(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.DeploymentURL);
        Assert.False(model.RawData.ContainsKey("deploymentUrl"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Edges);
        Assert.False(model.RawData.ContainsKey("edges"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Nodes);
        Assert.False(model.RawData.ContainsKey("nodes"));
        Assert.Null(model.TriggerConfig);
        Assert.False(model.RawData.ContainsKey("triggerConfig"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Visibility);
        Assert.False(model.RawData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1RetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1RetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeployedAt = null,
            DeploymentURL = null,
            Description = null,
            Edges = null,
            Name = null,
            Nodes = null,
            TriggerConfig = null,
            TriggerType = null,
            UpdatedAt = null,
            Visibility = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeployedAt);
        Assert.False(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.DeploymentURL);
        Assert.False(model.RawData.ContainsKey("deploymentUrl"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Edges);
        Assert.False(model.RawData.ContainsKey("edges"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Nodes);
        Assert.False(model.RawData.ContainsKey("nodes"));
        Assert.Null(model.TriggerConfig);
        Assert.False(model.RawData.ContainsKey("triggerConfig"));
        Assert.Null(model.TriggerType);
        Assert.False(model.RawData.ContainsKey("triggerType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Visibility);
        Assert.False(model.RawData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1RetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeployedAt = null,
            DeploymentURL = null,
            Description = null,
            Edges = null,
            Name = null,
            Nodes = null,
            TriggerConfig = null,
            TriggerType = null,
            UpdatedAt = null,
            Visibility = null,
        };

        model.Validate();
    }
}
