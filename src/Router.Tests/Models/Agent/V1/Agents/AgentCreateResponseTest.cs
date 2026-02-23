using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Agent.V1.Agents;

namespace Router.Tests.Models.Agent.V1.Agents;

public class AgentCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<string> expectedDisabledTools = ["string"];
        List<string> expectedEnabledTools = ["string"];
        string expectedInstructions = "instructions";
        string expectedModel = "model";
        string expectedName = "name";
        JsonElement expectedSandbox = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.DisabledTools);
        Assert.Equal(expectedDisabledTools.Count, model.DisabledTools.Count);
        for (int i = 0; i < expectedDisabledTools.Count; i++)
        {
            Assert.Equal(expectedDisabledTools[i], model.DisabledTools[i]);
        }
        Assert.NotNull(model.EnabledTools);
        Assert.Equal(expectedEnabledTools.Count, model.EnabledTools.Count);
        for (int i = 0; i < expectedEnabledTools.Count; i++)
        {
            Assert.Equal(expectedEnabledTools[i], model.EnabledTools[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Sandbox);
        Assert.True(JsonElement.DeepEquals(expectedSandbox, model.Sandbox.Value));
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
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<string> expectedDisabledTools = ["string"];
        List<string> expectedEnabledTools = ["string"];
        string expectedInstructions = "instructions";
        string expectedModel = "model";
        string expectedName = "name";
        JsonElement expectedSandbox = JsonSerializer.Deserialize<JsonElement>("{}");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.DisabledTools);
        Assert.Equal(expectedDisabledTools.Count, deserialized.DisabledTools.Count);
        for (int i = 0; i < expectedDisabledTools.Count; i++)
        {
            Assert.Equal(expectedDisabledTools[i], deserialized.DisabledTools[i]);
        }
        Assert.NotNull(deserialized.EnabledTools);
        Assert.Equal(expectedEnabledTools.Count, deserialized.EnabledTools.Count);
        for (int i = 0; i < expectedEnabledTools.Count; i++)
        {
            Assert.Equal(expectedEnabledTools[i], deserialized.EnabledTools[i]);
        }
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Sandbox);
        Assert.True(JsonElement.DeepEquals(expectedSandbox, deserialized.Sandbox.Value));
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
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentCreateResponse
        {
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
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
        var model = new AgentCreateResponse
        {
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentCreateResponse
        {
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Instructions = null,
            Model = null,
            Name = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
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
        var model = new AgentCreateResponse
        {
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Instructions = null,
            Model = null,
            Name = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisabledTools);
        Assert.False(model.RawData.ContainsKey("disabledTools"));
        Assert.Null(model.EnabledTools);
        Assert.False(model.RawData.ContainsKey("enabledTools"));
        Assert.Null(model.Sandbox);
        Assert.False(model.RawData.ContainsKey("sandbox"));
        Assert.Null(model.VaultIds);
        Assert.False(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            DisabledTools = null,
            EnabledTools = null,
            Sandbox = null,
            VaultIds = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisabledTools);
        Assert.True(model.RawData.ContainsKey("disabledTools"));
        Assert.Null(model.EnabledTools);
        Assert.True(model.RawData.ContainsKey("enabledTools"));
        Assert.Null(model.Sandbox);
        Assert.True(model.RawData.ContainsKey("sandbox"));
        Assert.Null(model.VaultIds);
        Assert.True(model.RawData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            DisabledTools = null,
            EnabledTools = null,
            Sandbox = null,
            VaultIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultIds = ["string"],
        };

        AgentCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
