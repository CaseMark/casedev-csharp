using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V1.Execute;

namespace Casedev.Tests.Models.Agent.V1.Execute;

public class ExecuteCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Guidance = "guidance",
            Instructions = "instructions",
            Model = "model",
            ObjectIds = ["string"],
            Sandbox = new() { Cpu = 0, MemoryMiB = 0 },
            VaultIds = ["string"],
        };

        string expectedPrompt = "prompt";
        List<string> expectedDisabledTools = ["string"];
        List<string> expectedEnabledTools = ["string"];
        string expectedGuidance = "guidance";
        string expectedInstructions = "instructions";
        string expectedModel = "model";
        List<string> expectedObjectIds = ["string"];
        Sandbox expectedSandbox = new() { Cpu = 0, MemoryMiB = 0 };
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedPrompt, parameters.Prompt);
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
        Assert.Equal(expectedGuidance, parameters.Guidance);
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.NotNull(parameters.ObjectIds);
        Assert.Equal(expectedObjectIds.Count, parameters.ObjectIds.Count);
        for (int i = 0; i < expectedObjectIds.Count; i++)
        {
            Assert.Equal(expectedObjectIds[i], parameters.ObjectIds[i]);
        }
        Assert.Equal(expectedSandbox, parameters.Sandbox);
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
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Guidance = "guidance",
            ObjectIds = ["string"],
            Sandbox = new() { Cpu = 0, MemoryMiB = 0 },
            VaultIds = ["string"],
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Guidance = "guidance",
            ObjectIds = ["string"],
            Sandbox = new() { Cpu = 0, MemoryMiB = 0 },
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Instructions = null,
            Model = null,
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            Instructions = "instructions",
            Model = "model",
        };

        Assert.Null(parameters.DisabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("disabledTools"));
        Assert.Null(parameters.EnabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("enabledTools"));
        Assert.Null(parameters.Guidance);
        Assert.False(parameters.RawBodyData.ContainsKey("guidance"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.Sandbox);
        Assert.False(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            Instructions = "instructions",
            Model = "model",

            DisabledTools = null,
            EnabledTools = null,
            Guidance = null,
            ObjectIds = null,
            Sandbox = null,
            VaultIds = null,
        };

        Assert.Null(parameters.DisabledTools);
        Assert.True(parameters.RawBodyData.ContainsKey("disabledTools"));
        Assert.Null(parameters.EnabledTools);
        Assert.True(parameters.RawBodyData.ContainsKey("enabledTools"));
        Assert.Null(parameters.Guidance);
        Assert.True(parameters.RawBodyData.ContainsKey("guidance"));
        Assert.Null(parameters.ObjectIds);
        Assert.True(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.Sandbox);
        Assert.True(parameters.RawBodyData.ContainsKey("sandbox"));
        Assert.Null(parameters.VaultIds);
        Assert.True(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void Url_Works()
    {
        ExecuteCreateParams parameters = new() { Prompt = "prompt" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v1/execute"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecuteCreateParams
        {
            Prompt = "prompt",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            Guidance = "guidance",
            Instructions = "instructions",
            Model = "model",
            ObjectIds = ["string"],
            Sandbox = new() { Cpu = 0, MemoryMiB = 0 },
            VaultIds = ["string"],
        };

        ExecuteCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SandboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sandbox { Cpu = 0, MemoryMiB = 0 };

        long expectedCpu = 0;
        long expectedMemoryMiB = 0;

        Assert.Equal(expectedCpu, model.Cpu);
        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Sandbox { Cpu = 0, MemoryMiB = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sandbox>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sandbox { Cpu = 0, MemoryMiB = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sandbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCpu = 0;
        long expectedMemoryMiB = 0;

        Assert.Equal(expectedCpu, deserialized.Cpu);
        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Sandbox { Cpu = 0, MemoryMiB = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sandbox { };

        Assert.Null(model.Cpu);
        Assert.False(model.RawData.ContainsKey("cpu"));
        Assert.Null(model.MemoryMiB);
        Assert.False(model.RawData.ContainsKey("memoryMiB"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sandbox { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sandbox
        {
            // Null should be interpreted as omitted for these properties
            Cpu = null,
            MemoryMiB = null,
        };

        Assert.Null(model.Cpu);
        Assert.False(model.RawData.ContainsKey("cpu"));
        Assert.Null(model.MemoryMiB);
        Assert.False(model.RawData.ContainsKey("memoryMiB"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sandbox
        {
            // Null should be interpreted as omitted for these properties
            Cpu = null,
            MemoryMiB = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Sandbox { Cpu = 0, MemoryMiB = 0 };

        Sandbox copied = new(model);

        Assert.Equal(model, copied);
    }
}
