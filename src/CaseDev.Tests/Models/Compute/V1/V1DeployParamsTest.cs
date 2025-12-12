using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Task)]
    [InlineData(Type.Service)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Task)]
    [InlineData(Type.Service)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
        {
            AddPython = "addPython",
            AllowNetwork = true,
            Cmd = ["string"],
            Concurrency = 0,
            CPUCount = 0,
            CronSchedule = "cronSchedule",
            Dependencies = ["string"],
            Entrypoint = ["string"],
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            GPUCount = 0,
            GPUType = GPUType.CPU,
            IsWebService = true,
            MemoryMB = 0,
            PipInstall = ["string"],
            Port = 0,
            PythonVersion = "pythonVersion",
            Retries = 0,
            SecretGroups = ["string"],
            TimeoutSeconds = 0,
            UseUv = true,
            WarmInstances = 0,
            Workdir = "workdir",
        };

        string expectedAddPython = "addPython";
        bool expectedAllowNetwork = true;
        List<string> expectedCmd = ["string"];
        long expectedConcurrency = 0;
        long expectedCPUCount = 0;
        string expectedCronSchedule = "cronSchedule";
        List<string> expectedDependencies = ["string"];
        List<string> expectedEntrypoint = ["string"];
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        long expectedGPUCount = 0;
        ApiEnum<string, GPUType> expectedGPUType = GPUType.CPU;
        bool expectedIsWebService = true;
        long expectedMemoryMB = 0;
        List<string> expectedPipInstall = ["string"];
        long expectedPort = 0;
        string expectedPythonVersion = "pythonVersion";
        long expectedRetries = 0;
        List<string> expectedSecretGroups = ["string"];
        long expectedTimeoutSeconds = 0;
        bool expectedUseUv = true;
        long expectedWarmInstances = 0;
        string expectedWorkdir = "workdir";

        Assert.Equal(expectedAddPython, model.AddPython);
        Assert.Equal(expectedAllowNetwork, model.AllowNetwork);
        Assert.NotNull(model.Cmd);
        Assert.Equal(expectedCmd.Count, model.Cmd.Count);
        for (int i = 0; i < expectedCmd.Count; i++)
        {
            Assert.Equal(expectedCmd[i], model.Cmd[i]);
        }
        Assert.Equal(expectedConcurrency, model.Concurrency);
        Assert.Equal(expectedCPUCount, model.CPUCount);
        Assert.Equal(expectedCronSchedule, model.CronSchedule);
        Assert.NotNull(model.Dependencies);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], model.Dependencies[i]);
        }
        Assert.NotNull(model.Entrypoint);
        Assert.Equal(expectedEntrypoint.Count, model.Entrypoint.Count);
        for (int i = 0; i < expectedEntrypoint.Count; i++)
        {
            Assert.Equal(expectedEntrypoint[i], model.Entrypoint[i]);
        }
        Assert.Equal(expectedEnv.Count, model.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(model.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Env[item.Key]);
        }
        Assert.Equal(expectedGPUCount, model.GPUCount);
        Assert.Equal(expectedGPUType, model.GPUType);
        Assert.Equal(expectedIsWebService, model.IsWebService);
        Assert.Equal(expectedMemoryMB, model.MemoryMB);
        Assert.NotNull(model.PipInstall);
        Assert.Equal(expectedPipInstall.Count, model.PipInstall.Count);
        for (int i = 0; i < expectedPipInstall.Count; i++)
        {
            Assert.Equal(expectedPipInstall[i], model.PipInstall[i]);
        }
        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedPythonVersion, model.PythonVersion);
        Assert.Equal(expectedRetries, model.Retries);
        Assert.NotNull(model.SecretGroups);
        Assert.Equal(expectedSecretGroups.Count, model.SecretGroups.Count);
        for (int i = 0; i < expectedSecretGroups.Count; i++)
        {
            Assert.Equal(expectedSecretGroups[i], model.SecretGroups[i]);
        }
        Assert.Equal(expectedTimeoutSeconds, model.TimeoutSeconds);
        Assert.Equal(expectedUseUv, model.UseUv);
        Assert.Equal(expectedWarmInstances, model.WarmInstances);
        Assert.Equal(expectedWorkdir, model.Workdir);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Config
        {
            AddPython = "addPython",
            AllowNetwork = true,
            Cmd = ["string"],
            Concurrency = 0,
            CPUCount = 0,
            CronSchedule = "cronSchedule",
            Dependencies = ["string"],
            Entrypoint = ["string"],
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            GPUCount = 0,
            GPUType = GPUType.CPU,
            IsWebService = true,
            MemoryMB = 0,
            PipInstall = ["string"],
            Port = 0,
            PythonVersion = "pythonVersion",
            Retries = 0,
            SecretGroups = ["string"],
            TimeoutSeconds = 0,
            UseUv = true,
            WarmInstances = 0,
            Workdir = "workdir",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Config>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Config
        {
            AddPython = "addPython",
            AllowNetwork = true,
            Cmd = ["string"],
            Concurrency = 0,
            CPUCount = 0,
            CronSchedule = "cronSchedule",
            Dependencies = ["string"],
            Entrypoint = ["string"],
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            GPUCount = 0,
            GPUType = GPUType.CPU,
            IsWebService = true,
            MemoryMB = 0,
            PipInstall = ["string"],
            Port = 0,
            PythonVersion = "pythonVersion",
            Retries = 0,
            SecretGroups = ["string"],
            TimeoutSeconds = 0,
            UseUv = true,
            WarmInstances = 0,
            Workdir = "workdir",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Config>(json);
        Assert.NotNull(deserialized);

        string expectedAddPython = "addPython";
        bool expectedAllowNetwork = true;
        List<string> expectedCmd = ["string"];
        long expectedConcurrency = 0;
        long expectedCPUCount = 0;
        string expectedCronSchedule = "cronSchedule";
        List<string> expectedDependencies = ["string"];
        List<string> expectedEntrypoint = ["string"];
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        long expectedGPUCount = 0;
        ApiEnum<string, GPUType> expectedGPUType = GPUType.CPU;
        bool expectedIsWebService = true;
        long expectedMemoryMB = 0;
        List<string> expectedPipInstall = ["string"];
        long expectedPort = 0;
        string expectedPythonVersion = "pythonVersion";
        long expectedRetries = 0;
        List<string> expectedSecretGroups = ["string"];
        long expectedTimeoutSeconds = 0;
        bool expectedUseUv = true;
        long expectedWarmInstances = 0;
        string expectedWorkdir = "workdir";

        Assert.Equal(expectedAddPython, deserialized.AddPython);
        Assert.Equal(expectedAllowNetwork, deserialized.AllowNetwork);
        Assert.NotNull(deserialized.Cmd);
        Assert.Equal(expectedCmd.Count, deserialized.Cmd.Count);
        for (int i = 0; i < expectedCmd.Count; i++)
        {
            Assert.Equal(expectedCmd[i], deserialized.Cmd[i]);
        }
        Assert.Equal(expectedConcurrency, deserialized.Concurrency);
        Assert.Equal(expectedCPUCount, deserialized.CPUCount);
        Assert.Equal(expectedCronSchedule, deserialized.CronSchedule);
        Assert.NotNull(deserialized.Dependencies);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], deserialized.Dependencies[i]);
        }
        Assert.NotNull(deserialized.Entrypoint);
        Assert.Equal(expectedEntrypoint.Count, deserialized.Entrypoint.Count);
        for (int i = 0; i < expectedEntrypoint.Count; i++)
        {
            Assert.Equal(expectedEntrypoint[i], deserialized.Entrypoint[i]);
        }
        Assert.Equal(expectedEnv.Count, deserialized.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(deserialized.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Env[item.Key]);
        }
        Assert.Equal(expectedGPUCount, deserialized.GPUCount);
        Assert.Equal(expectedGPUType, deserialized.GPUType);
        Assert.Equal(expectedIsWebService, deserialized.IsWebService);
        Assert.Equal(expectedMemoryMB, deserialized.MemoryMB);
        Assert.NotNull(deserialized.PipInstall);
        Assert.Equal(expectedPipInstall.Count, deserialized.PipInstall.Count);
        for (int i = 0; i < expectedPipInstall.Count; i++)
        {
            Assert.Equal(expectedPipInstall[i], deserialized.PipInstall[i]);
        }
        Assert.Equal(expectedPort, deserialized.Port);
        Assert.Equal(expectedPythonVersion, deserialized.PythonVersion);
        Assert.Equal(expectedRetries, deserialized.Retries);
        Assert.NotNull(deserialized.SecretGroups);
        Assert.Equal(expectedSecretGroups.Count, deserialized.SecretGroups.Count);
        for (int i = 0; i < expectedSecretGroups.Count; i++)
        {
            Assert.Equal(expectedSecretGroups[i], deserialized.SecretGroups[i]);
        }
        Assert.Equal(expectedTimeoutSeconds, deserialized.TimeoutSeconds);
        Assert.Equal(expectedUseUv, deserialized.UseUv);
        Assert.Equal(expectedWarmInstances, deserialized.WarmInstances);
        Assert.Equal(expectedWorkdir, deserialized.Workdir);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Config
        {
            AddPython = "addPython",
            AllowNetwork = true,
            Cmd = ["string"],
            Concurrency = 0,
            CPUCount = 0,
            CronSchedule = "cronSchedule",
            Dependencies = ["string"],
            Entrypoint = ["string"],
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            GPUCount = 0,
            GPUType = GPUType.CPU,
            IsWebService = true,
            MemoryMB = 0,
            PipInstall = ["string"],
            Port = 0,
            PythonVersion = "pythonVersion",
            Retries = 0,
            SecretGroups = ["string"],
            TimeoutSeconds = 0,
            UseUv = true,
            WarmInstances = 0,
            Workdir = "workdir",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Config { };

        Assert.Null(model.AddPython);
        Assert.False(model.RawData.ContainsKey("addPython"));
        Assert.Null(model.AllowNetwork);
        Assert.False(model.RawData.ContainsKey("allowNetwork"));
        Assert.Null(model.Cmd);
        Assert.False(model.RawData.ContainsKey("cmd"));
        Assert.Null(model.Concurrency);
        Assert.False(model.RawData.ContainsKey("concurrency"));
        Assert.Null(model.CPUCount);
        Assert.False(model.RawData.ContainsKey("cpuCount"));
        Assert.Null(model.CronSchedule);
        Assert.False(model.RawData.ContainsKey("cronSchedule"));
        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
        Assert.Null(model.Entrypoint);
        Assert.False(model.RawData.ContainsKey("entrypoint"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.GPUCount);
        Assert.False(model.RawData.ContainsKey("gpuCount"));
        Assert.Null(model.GPUType);
        Assert.False(model.RawData.ContainsKey("gpuType"));
        Assert.Null(model.IsWebService);
        Assert.False(model.RawData.ContainsKey("isWebService"));
        Assert.Null(model.MemoryMB);
        Assert.False(model.RawData.ContainsKey("memoryMb"));
        Assert.Null(model.PipInstall);
        Assert.False(model.RawData.ContainsKey("pipInstall"));
        Assert.Null(model.Port);
        Assert.False(model.RawData.ContainsKey("port"));
        Assert.Null(model.PythonVersion);
        Assert.False(model.RawData.ContainsKey("pythonVersion"));
        Assert.Null(model.Retries);
        Assert.False(model.RawData.ContainsKey("retries"));
        Assert.Null(model.SecretGroups);
        Assert.False(model.RawData.ContainsKey("secretGroups"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeoutSeconds"));
        Assert.Null(model.UseUv);
        Assert.False(model.RawData.ContainsKey("useUv"));
        Assert.Null(model.WarmInstances);
        Assert.False(model.RawData.ContainsKey("warmInstances"));
        Assert.Null(model.Workdir);
        Assert.False(model.RawData.ContainsKey("workdir"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Config { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Config
        {
            // Null should be interpreted as omitted for these properties
            AddPython = null,
            AllowNetwork = null,
            Cmd = null,
            Concurrency = null,
            CPUCount = null,
            CronSchedule = null,
            Dependencies = null,
            Entrypoint = null,
            Env = null,
            GPUCount = null,
            GPUType = null,
            IsWebService = null,
            MemoryMB = null,
            PipInstall = null,
            Port = null,
            PythonVersion = null,
            Retries = null,
            SecretGroups = null,
            TimeoutSeconds = null,
            UseUv = null,
            WarmInstances = null,
            Workdir = null,
        };

        Assert.Null(model.AddPython);
        Assert.False(model.RawData.ContainsKey("addPython"));
        Assert.Null(model.AllowNetwork);
        Assert.False(model.RawData.ContainsKey("allowNetwork"));
        Assert.Null(model.Cmd);
        Assert.False(model.RawData.ContainsKey("cmd"));
        Assert.Null(model.Concurrency);
        Assert.False(model.RawData.ContainsKey("concurrency"));
        Assert.Null(model.CPUCount);
        Assert.False(model.RawData.ContainsKey("cpuCount"));
        Assert.Null(model.CronSchedule);
        Assert.False(model.RawData.ContainsKey("cronSchedule"));
        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
        Assert.Null(model.Entrypoint);
        Assert.False(model.RawData.ContainsKey("entrypoint"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.GPUCount);
        Assert.False(model.RawData.ContainsKey("gpuCount"));
        Assert.Null(model.GPUType);
        Assert.False(model.RawData.ContainsKey("gpuType"));
        Assert.Null(model.IsWebService);
        Assert.False(model.RawData.ContainsKey("isWebService"));
        Assert.Null(model.MemoryMB);
        Assert.False(model.RawData.ContainsKey("memoryMb"));
        Assert.Null(model.PipInstall);
        Assert.False(model.RawData.ContainsKey("pipInstall"));
        Assert.Null(model.Port);
        Assert.False(model.RawData.ContainsKey("port"));
        Assert.Null(model.PythonVersion);
        Assert.False(model.RawData.ContainsKey("pythonVersion"));
        Assert.Null(model.Retries);
        Assert.False(model.RawData.ContainsKey("retries"));
        Assert.Null(model.SecretGroups);
        Assert.False(model.RawData.ContainsKey("secretGroups"));
        Assert.Null(model.TimeoutSeconds);
        Assert.False(model.RawData.ContainsKey("timeoutSeconds"));
        Assert.Null(model.UseUv);
        Assert.False(model.RawData.ContainsKey("useUv"));
        Assert.Null(model.WarmInstances);
        Assert.False(model.RawData.ContainsKey("warmInstances"));
        Assert.Null(model.Workdir);
        Assert.False(model.RawData.ContainsKey("workdir"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Config
        {
            // Null should be interpreted as omitted for these properties
            AddPython = null,
            AllowNetwork = null,
            Cmd = null,
            Concurrency = null,
            CPUCount = null,
            CronSchedule = null,
            Dependencies = null,
            Entrypoint = null,
            Env = null,
            GPUCount = null,
            GPUType = null,
            IsWebService = null,
            MemoryMB = null,
            PipInstall = null,
            Port = null,
            PythonVersion = null,
            Retries = null,
            SecretGroups = null,
            TimeoutSeconds = null,
            UseUv = null,
            WarmInstances = null,
            Workdir = null,
        };

        model.Validate();
    }
}

public class GPUTypeTest : TestBase
{
    [Theory]
    [InlineData(GPUType.CPU)]
    [InlineData(GPUType.T4)]
    [InlineData(GPUType.L4)]
    [InlineData(GPUType.A10G)]
    [InlineData(GPUType.L40S)]
    [InlineData(GPUType.A100)]
    [InlineData(GPUType.A100_40GB)]
    [InlineData(GPUType.A100_80GB)]
    [InlineData(GPUType.H100)]
    [InlineData(GPUType.H200)]
    [InlineData(GPUType.B200)]
    public void Validation_Works(GPUType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GPUType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GPUType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GPUType.CPU)]
    [InlineData(GPUType.T4)]
    [InlineData(GPUType.L4)]
    [InlineData(GPUType.A10G)]
    [InlineData(GPUType.L40S)]
    [InlineData(GPUType.A100)]
    [InlineData(GPUType.A100_40GB)]
    [InlineData(GPUType.A100_80GB)]
    [InlineData(GPUType.H100)]
    [InlineData(GPUType.H200)]
    [InlineData(GPUType.B200)]
    public void SerializationRoundtrip_Works(GPUType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GPUType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GPUType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GPUType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GPUType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RuntimeTest : TestBase
{
    [Theory]
    [InlineData(Runtime.Python)]
    [InlineData(Runtime.Dockerfile)]
    [InlineData(Runtime.Image)]
    public void Validation_Works(Runtime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Runtime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Runtime.Python)]
    [InlineData(Runtime.Dockerfile)]
    [InlineData(Runtime.Image)]
    public void SerializationRoundtrip_Works(Runtime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Runtime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
