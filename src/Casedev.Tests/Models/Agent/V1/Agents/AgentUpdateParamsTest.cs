using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Models.Agent.V1.Agents;

namespace Casedev.Tests.Models.Agent.V1.Agents;

public class AgentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],
        };

        string expectedID = "id";
        string expectedDescription = "description";
        List<string> expectedDisabledTools = ["string"];
        List<string> expectedEnabledTools = ["string"];
        string expectedInstructions = "instructions";
        string expectedModel = "model";
        string expectedName = "name";
        JsonElement expectedSandbox = JsonSerializer.Deserialize<JsonElement>("{}");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.DisabledTools);
        Assert.Equal(expectedDisabledTools.Count, parameters.DisabledTools.Count);
        for (int i = 0; i < expectedDisabledTools.Count; i++)
        {
            Assert.Equal(expectedDisabledTools[i], parameters.DisabledTools[i]);
        }
        Assert.NotNull(parameters.EnabledTools);
        Assert.Equal(expectedEnabledTools.Count, parameters.EnabledTools.Count);
        for (int i = 0; i < expectedEnabledTools.Count; i++)
        {
            Assert.Equal(expectedEnabledTools[i], parameters.EnabledTools[i]);
        }
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Sandbox);
        Assert.True(JsonElement.DeepEquals(expectedSandbox, parameters.Sandbox.Value));
        Assert.NotNull(parameters.VaultIds);
        Assert.Equal(expectedVaultIds.Count, parameters.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], parameters.VaultIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Description = null,
            Instructions = null,
            Model = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Description = "description",
            Instructions = "instructions",
            Model = "model",
            Name = "name",
        };

        Assert.Null(parameters.DisabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("disabledTools"));
        Assert.Null(parameters.EnabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("enabledTools"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Description = "description",
            Instructions = "instructions",
            Model = "model",
            Name = "name",

            DisabledTools = null,
            EnabledTools = null,
            Sandbox = null,
            VaultIds = null,
        };

        Assert.Null(parameters.DisabledTools);
        Assert.True(parameters.RawBodyData.ContainsKey("disabledTools"));
        Assert.Null(parameters.EnabledTools);
        Assert.True(parameters.RawBodyData.ContainsKey("enabledTools"));
        Assert.Null(parameters.Sandbox);
        Assert.True(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.VaultIds);
        Assert.True(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/agents/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentUpdateParams
        {
            ID = "id",
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Instructions = "instructions",
            Model = "model",
            Name = "name",
            Sandbox = JsonSerializer.Deserialize<JsonElement>("{}"),
            VaultIds = ["string"],
        };

        AgentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
