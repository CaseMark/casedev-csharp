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
        get
        {
            if (!this._rawBodyData.TryGetValue("entrypointName", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'entrypointName' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entrypointName",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'entrypointName' cannot be null",
                    new System::ArgumentNullException("entrypointName")
                );
        }
        init
        {
            this._rawBodyData["entrypointName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Deployment type: task for batch jobs, service for web endpoints
    /// </summary>
    public required ApiEnum<string, global::CaseDev.Models.Compute.V1.Type> Type
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("type", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::CaseDev.Models.Compute.V1.Type>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Python code (required for python runtime)
    /// </summary>
    public string? Code
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Runtime and resource configuration
    /// </summary>
    public Config? Config
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Config?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Dockerfile content (required for dockerfile runtime)
    /// </summary>
    public string? Dockerfile
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("dockerfile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["dockerfile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Python entrypoint file name
    /// </summary>
    public string? EntrypointFile
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("entrypointFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["entrypointFile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Environment name (uses default if not specified)
    /// </summary>
    public string? Environment
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("environment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["environment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Container image name (required for image runtime, e.g., 'nvidia/cuda:12.8.1-devel-ubuntu22.04')
    /// </summary>
    public string? Image
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Runtime environment
    /// </summary>
    public ApiEnum<string, Runtime>? Runtime
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("runtime", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Runtime>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["runtime"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._rawData.TryGetValue("addPython", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["addPython"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Allow network access (default: false for Python, true for Docker)
    /// </summary>
    public bool? AllowNetwork
    {
        get
        {
            if (!this._rawData.TryGetValue("allowNetwork", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allowNetwork"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Container command arguments
    /// </summary>
    public IReadOnlyList<string>? Cmd
    {
        get
        {
            if (!this._rawData.TryGetValue("cmd", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["cmd"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Concurrent execution limit
    /// </summary>
    public long? Concurrency
    {
        get
        {
            if (!this._rawData.TryGetValue("concurrency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["concurrency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// CPU core count
    /// </summary>
    public long? CPUCount
    {
        get
        {
            if (!this._rawData.TryGetValue("cpuCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["cpuCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cron schedule for periodic execution
    /// </summary>
    public string? CronSchedule
    {
        get
        {
            if (!this._rawData.TryGetValue("cronSchedule", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["cronSchedule"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Python package dependencies (python runtime)
    /// </summary>
    public IReadOnlyList<string>? Dependencies
    {
        get
        {
            if (!this._rawData.TryGetValue("dependencies", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["dependencies"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Container entrypoint command
    /// </summary>
    public IReadOnlyList<string>? Entrypoint
    {
        get
        {
            if (!this._rawData.TryGetValue("entrypoint", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["entrypoint"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Environment variables
    /// </summary>
    public IReadOnlyDictionary<string, string>? Env
    {
        get
        {
            if (!this._rawData.TryGetValue("env", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["env"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of GPUs (for multi-GPU setups)
    /// </summary>
    public long? GPUCount
    {
        get
        {
            if (!this._rawData.TryGetValue("gpuCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["gpuCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// GPU type for acceleration
    /// </summary>
    public ApiEnum<string, GPUType>? GPUType
    {
        get
        {
            if (!this._rawData.TryGetValue("gpuType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, GPUType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["gpuType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Deploy as web service (auto-set for service type)
    /// </summary>
    public bool? IsWebService
    {
        get
        {
            if (!this._rawData.TryGetValue("isWebService", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["isWebService"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Memory allocation in MB
    /// </summary>
    public long? MemoryMB
    {
        get
        {
            if (!this._rawData.TryGetValue("memoryMb", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["memoryMb"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Packages to pip install (image runtime)
    /// </summary>
    public IReadOnlyList<string>? PipInstall
    {
        get
        {
            if (!this._rawData.TryGetValue("pipInstall", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["pipInstall"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Port for web services
    /// </summary>
    public long? Port
    {
        get
        {
            if (!this._rawData.TryGetValue("port", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["port"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Python version (e.g., '3.11')
    /// </summary>
    public string? PythonVersion
    {
        get
        {
            if (!this._rawData.TryGetValue("pythonVersion", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["pythonVersion"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Retry attempts on failure (Python only)
    /// </summary>
    public long? Retries
    {
        get
        {
            if (!this._rawData.TryGetValue("retries", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["retries"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Secret group names to inject
    /// </summary>
    public IReadOnlyList<string>? SecretGroups
    {
        get
        {
            if (!this._rawData.TryGetValue("secretGroups", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["secretGroups"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum execution time
    /// </summary>
    public long? TimeoutSeconds
    {
        get
        {
            if (!this._rawData.TryGetValue("timeoutSeconds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["timeoutSeconds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Use uv for faster package installs
    /// </summary>
    public bool? UseUv
    {
        get
        {
            if (!this._rawData.TryGetValue("useUv", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["useUv"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of warm instances to maintain
    /// </summary>
    public long? WarmInstances
    {
        get
        {
            if (!this._rawData.TryGetValue("warmInstances", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["warmInstances"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Working directory in container
    /// </summary>
    public string? Workdir
    {
        get
        {
            if (!this._rawData.TryGetValue("workdir", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["workdir"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
