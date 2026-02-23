using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Agent.V1.Agents;

namespace Router.Tests.Models.Agent.V1.Agents;

public class AgentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentListResponse
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsActive = true,
                    Model = "model",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        List<AgentListResponseAgent> expectedAgents =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                IsActive = true,
                Model = "model",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VaultIds = ["string"],
            },
        ];

        Assert.NotNull(model.Agents);
        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentListResponse
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsActive = true,
                    Model = "model",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentListResponse
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsActive = true,
                    Model = "model",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentListResponseAgent> expectedAgents =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                IsActive = true,
                Model = "model",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VaultIds = ["string"],
            },
        ];

        Assert.NotNull(deserialized.Agents);
        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentListResponse
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsActive = true,
                    Model = "model",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentListResponse { };

        Assert.Null(model.Agents);
        Assert.False(model.RawData.ContainsKey("agents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Agents = null,
        };

        Assert.Null(model.Agents);
        Assert.False(model.RawData.ContainsKey("agents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Agents = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentListResponse
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    IsActive = true,
                    Model = "model",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        AgentListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentListResponseAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedIsActive = true;
        string expectedModel = "model";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
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
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListResponseAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListResponseAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedIsActive = true;
        string expectedModel = "model";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
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
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentListResponseAgent
        {
            Description = "description",
            VaultIds = ["string"],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentListResponseAgent
        {
            Description = "description",
            VaultIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentListResponseAgent
        {
            Description = "description",
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsActive = null,
            Model = null,
            Name = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentListResponseAgent
        {
            Description = "description",
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsActive = null,
            Model = null,
            Name = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.VaultIds);
        Assert.False(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            VaultIds = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.VaultIds);
        Assert.True(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            VaultIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentListResponseAgent
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            IsActive = true,
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        AgentListResponseAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}
