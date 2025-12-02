using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Compute.V1;

/// <summary>
/// Deploy code to Case.dev's serverless compute infrastructure powered by Modal.
/// Supports Python, Dockerfile, and container image runtimes with GPU acceleration
/// for AI/ML workloads. Code is deployed as tasks (batch jobs) or services (web endpoints)
/// with automatic scaling.
/// </summary>
public sealed record class V1DeployParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Function/app name (used for domain: hello → hello.org.case.systems)
    /// </summary>
    public required string EntrypointName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "entrypointName"); }
        init { ModelBase.Set(this._rawBodyData, "entrypointName", value); }
    }

    /// <summary>
    /// Deployment type: task for batch jobs, service for web endpoints
    /// </summary>
    public required ApiEnum<string, global::CaseDev.Models.Compute.V1.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::CaseDev.Models.Compute.V1.Type>
            >(this.RawBodyData, "type");
        }
        init { ModelBase.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// Python code (required for python runtime)
    /// </summary>
    public string? Code
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "code", value);
        }
    }

    /// <summary>
    /// Runtime and resource configuration
    /// </summary>
    public Config? Config
    {
        get { return ModelBase.GetNullableClass<Config>(this.RawBodyData, "config"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "config", value);
        }
    }

    /// <summary>
    /// Dockerfile content (required for dockerfile runtime)
    /// </summary>
    public string? Dockerfile
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "dockerfile"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "dockerfile", value);
        }
    }

    /// <summary>
    /// Python entrypoint file name
    /// </summary>
    public string? EntrypointFile
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "entrypointFile"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "entrypointFile", value);
        }
    }

    /// <summary>
    /// Environment name (uses default if not specified)
    /// </summary>
    public string? Environment
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "environment"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "environment", value);
        }
    }

    /// <summary>
    /// Container image name (required for image runtime, e.g., 'nvidia/cuda:12.8.1-devel-ubuntu22.04')
    /// </summary>
    public string? Image
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "image"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "image", value);
        }
    }

    /// <summary>
    /// Runtime environment
    /// </summary>
    public ApiEnum<string, Runtime>? Runtime
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Runtime>>(
                this.RawBodyData,
                "runtime"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "runtime", value);
        }
    }

    public V1DeployParams() { }

    public V1DeployParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeployParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static V1DeployParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/compute/v1/deploy"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Deployment type: task for batch jobs, service for web endpoints
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Task,
    Service,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Compute.V1.Type>
{
    public override global::CaseDev.Models.Compute.V1.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "task" => global::CaseDev.Models.Compute.V1.Type.Task,
            "service" => global::CaseDev.Models.Compute.V1.Type.Service,
            _ => (global::CaseDev.Models.Compute.V1.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Compute.V1.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Compute.V1.Type.Task => "task",
                global::CaseDev.Models.Compute.V1.Type.Service => "service",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Runtime and resource configuration
/// </summary>
[JsonConverter(typeof(ModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : ModelBase
{
    /// <summary>
    /// Add Python to image (e.g., '3.12', for image runtime)
    /// </summary>
    public string? AddPython
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "addPython"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "addPython", value);
        }
    }

    /// <summary>
    /// Allow network access (default: false for Python, true for Docker)
    /// </summary>
    public bool? AllowNetwork
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "allowNetwork"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "allowNetwork", value);
        }
    }

    /// <summary>
    /// Container command arguments
    /// </summary>
    public IReadOnlyList<string>? Cmd
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "cmd"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cmd", value);
        }
    }

    /// <summary>
    /// Concurrent execution limit
    /// </summary>
    public long? Concurrency
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "concurrency"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "concurrency", value);
        }
    }

    /// <summary>
    /// CPU core count
    /// </summary>
    public long? CPUCount
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "cpuCount"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cpuCount", value);
        }
    }

    /// <summary>
    /// Cron schedule for periodic execution
    /// </summary>
    public string? CronSchedule
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "cronSchedule"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "cronSchedule", value);
        }
    }

    /// <summary>
    /// Python package dependencies (python runtime)
    /// </summary>
    public IReadOnlyList<string>? Dependencies
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "dependencies"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "dependencies", value);
        }
    }

    /// <summary>
    /// Container entrypoint command
    /// </summary>
    public IReadOnlyList<string>? Entrypoint
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "entrypoint"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "entrypoint", value);
        }
    }

    /// <summary>
    /// Environment variables
    /// </summary>
    public IReadOnlyDictionary<string, string>? Env
    {
        get { return ModelBase.GetNullableClass<Dictionary<string, string>>(this.RawData, "env"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "env", value);
        }
    }

    /// <summary>
    /// Number of GPUs (for multi-GPU setups)
    /// </summary>
    public long? GPUCount
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "gpuCount"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "gpuCount", value);
        }
    }

    /// <summary>
    /// GPU type for acceleration
    /// </summary>
    public ApiEnum<string, GPUType>? GPUType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, GPUType>>(this.RawData, "gpuType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "gpuType", value);
        }
    }

    /// <summary>
    /// Deploy as web service (auto-set for service type)
    /// </summary>
    public bool? IsWebService
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "isWebService"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "isWebService", value);
        }
    }

    /// <summary>
    /// Memory allocation in MB
    /// </summary>
    public long? MemoryMB
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "memoryMb"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "memoryMb", value);
        }
    }

    /// <summary>
    /// Packages to pip install (image runtime)
    /// </summary>
    public IReadOnlyList<string>? PipInstall
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "pipInstall"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "pipInstall", value);
        }
    }

    /// <summary>
    /// Port for web services
    /// </summary>
    public long? Port
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "port"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "port", value);
        }
    }

    /// <summary>
    /// Python version (e.g., '3.11')
    /// </summary>
    public string? PythonVersion
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "pythonVersion"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "pythonVersion", value);
        }
    }

    /// <summary>
    /// Retry attempts on failure (Python only)
    /// </summary>
    public long? Retries
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "retries"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "retries", value);
        }
    }

    /// <summary>
    /// Secret group names to inject
    /// </summary>
    public IReadOnlyList<string>? SecretGroups
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "secretGroups"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "secretGroups", value);
        }
    }

    /// <summary>
    /// Maximum execution time
    /// </summary>
    public long? TimeoutSeconds
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "timeoutSeconds"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "timeoutSeconds", value);
        }
    }

    /// <summary>
    /// Use uv for faster package installs
    /// </summary>
    public bool? UseUv
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "useUv"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "useUv", value);
        }
    }

    /// <summary>
    /// Number of warm instances to maintain
    /// </summary>
    public long? WarmInstances
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "warmInstances"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "warmInstances", value);
        }
    }

    /// <summary>
    /// Working directory in container
    /// </summary>
    public string? Workdir
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "workdir"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "workdir", value);
        }
    }

    public override void Validate()
    {
        _ = this.AddPython;
        _ = this.AllowNetwork;
        _ = this.Cmd;
        _ = this.Concurrency;
        _ = this.CPUCount;
        _ = this.CronSchedule;
        _ = this.Dependencies;
        _ = this.Entrypoint;
        _ = this.Env;
        _ = this.GPUCount;
        this.GPUType?.Validate();
        _ = this.IsWebService;
        _ = this.MemoryMB;
        _ = this.PipInstall;
        _ = this.Port;
        _ = this.PythonVersion;
        _ = this.Retries;
        _ = this.SecretGroups;
        _ = this.TimeoutSeconds;
        _ = this.UseUv;
        _ = this.WarmInstances;
        _ = this.Workdir;
    }

    public Config() { }

    public Config(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRaw<Config>
{
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}

/// <summary>
/// GPU type for acceleration
/// </summary>
[JsonConverter(typeof(GPUTypeConverter))]
public enum GPUType
{
    CPU,
    T4,
    L4,
    A10G,
    L40S,
    A100,
    A100_40GB,
    A100_80GB,
    H100,
    H200,
    B200,
}

sealed class GPUTypeConverter : JsonConverter<GPUType>
{
    public override GPUType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cpu" => GPUType.CPU,
            "T4" => GPUType.T4,
            "L4" => GPUType.L4,
            "A10G" => GPUType.A10G,
            "L40S" => GPUType.L40S,
            "A100" => GPUType.A100,
            "A100-40GB" => GPUType.A100_40GB,
            "A100-80GB" => GPUType.A100_80GB,
            "H100" => GPUType.H100,
            "H200" => GPUType.H200,
            "B200" => GPUType.B200,
            _ => (GPUType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, GPUType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GPUType.CPU => "cpu",
                GPUType.T4 => "T4",
                GPUType.L4 => "L4",
                GPUType.A10G => "A10G",
                GPUType.L40S => "L40S",
                GPUType.A100 => "A100",
                GPUType.A100_40GB => "A100-40GB",
                GPUType.A100_80GB => "A100-80GB",
                GPUType.H100 => "H100",
                GPUType.H200 => "H200",
                GPUType.B200 => "B200",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Runtime environment
/// </summary>
[JsonConverter(typeof(RuntimeConverter))]
public enum Runtime
{
    Python,
    Dockerfile,
    Image,
}

sealed class RuntimeConverter : JsonConverter<Runtime>
{
    public override Runtime Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "python" => Runtime.Python,
            "dockerfile" => Runtime.Dockerfile,
            "image" => Runtime.Image,
            _ => (Runtime)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Runtime value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Runtime.Python => "python",
                Runtime.Dockerfile => "dockerfile",
                Runtime.Image => "image",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
