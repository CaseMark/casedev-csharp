using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListResponse
        {
            Limit = 0,
            Offset = 0,
            Total = 0,
            Workflows =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    DeployedAt = "deployedAt",
                    Description = "description",
                    Name = "name",
                    TriggerType = "triggerType",
                    UpdatedAt = "updatedAt",
                    Visibility = "visibility",
                },
            ],
        };

        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotal = 0;
        List<Workflow> expectedWorkflows =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                DeployedAt = "deployedAt",
                Description = "description",
                Name = "name",
                TriggerType = "triggerType",
                UpdatedAt = "updatedAt",
                Visibility = "visibility",
            },
        ];

        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedTotal, model.Total);
        Assert.NotNull(model.Workflows);
        Assert.Equal(expectedWorkflows.Count, model.Workflows.Count);
        for (int i = 0; i < expectedWorkflows.Count; i++)
        {
            Assert.Equal(expectedWorkflows[i], model.Workflows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListResponse
        {
            Limit = 0,
            Offset = 0,
            Total = 0,
            Workflows =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    DeployedAt = "deployedAt",
                    Description = "description",
                    Name = "name",
                    TriggerType = "triggerType",
                    UpdatedAt = "updatedAt",
                    Visibility = "visibility",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListResponse
        {
            Limit = 0,
            Offset = 0,
            Total = 0,
            Workflows =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    DeployedAt = "deployedAt",
                    Description = "description",
                    Name = "name",
                    TriggerType = "triggerType",
                    UpdatedAt = "updatedAt",
                    Visibility = "visibility",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(json);
        Assert.NotNull(deserialized);

        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotal = 0;
        List<Workflow> expectedWorkflows =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                DeployedAt = "deployedAt",
                Description = "description",
                Name = "name",
                TriggerType = "triggerType",
                UpdatedAt = "updatedAt",
                Visibility = "visibility",
            },
        ];

        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.NotNull(deserialized.Workflows);
        Assert.Equal(expectedWorkflows.Count, deserialized.Workflows.Count);
        for (int i = 0; i < expectedWorkflows.Count; i++)
        {
            Assert.Equal(expectedWorkflows[i], deserialized.Workflows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListResponse
        {
            Limit = 0,
            Offset = 0,
            Total = 0,
            Workflows =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    DeployedAt = "deployedAt",
                    Description = "description",
                    Name = "name",
                    TriggerType = "triggerType",
                    UpdatedAt = "updatedAt",
                    Visibility = "visibility",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListResponse { };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Workflows);
        Assert.False(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListResponse
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Total = null,
            Workflows = null,
        };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Workflows);
        Assert.False(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListResponse
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Total = null,
            Workflows = null,
        };

        model.Validate();
    }
}

public class WorkflowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            Description = "description",
            Name = "name",
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedDeployedAt = "deployedAt";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedTriggerType = "triggerType";
        string expectedUpdatedAt = "updatedAt";
        string expectedVisibility = "visibility";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeployedAt, model.DeployedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVisibility, model.Visibility);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            Description = "description",
            Name = "name",
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Workflow>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            Description = "description",
            Name = "name",
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Workflow>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedDeployedAt = "deployedAt";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedTriggerType = "triggerType";
        string expectedUpdatedAt = "updatedAt";
        string expectedVisibility = "visibility";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeployedAt, deserialized.DeployedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVisibility, deserialized.Visibility);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Workflow
        {
            ID = "id",
            CreatedAt = "createdAt",
            DeployedAt = "deployedAt",
            Description = "description",
            Name = "name",
            TriggerType = "triggerType",
            UpdatedAt = "updatedAt",
            Visibility = "visibility",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Workflow { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeployedAt);
        Assert.False(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
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
        var model = new Workflow { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Workflow
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeployedAt = null,
            Description = null,
            Name = null,
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
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
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
        var model = new Workflow
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DeployedAt = null,
            Description = null,
            Name = null,
            TriggerType = null,
            UpdatedAt = null,
            Visibility = null,
        };

        model.Validate();
    }
}
