using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Applications.V1.Projects;

/// <summary>
/// Create a new web application project
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProjectCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// GitHub repository URL or "owner/repo"
    /// </summary>
    public required string GitRepo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("gitRepo");
        }
        init { this._rawBodyData.Set("gitRepo", value); }
    }

    /// <summary>
    /// Project name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Custom build command
    /// </summary>
    public string? BuildCommand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("buildCommand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("buildCommand", value);
        }
    }

    /// <summary>
    /// Environment variables to set on the project
    /// </summary>
    public IReadOnlyList<EnvironmentVariable>? EnvironmentVariables
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<EnvironmentVariable>>(
                "environmentVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EnvironmentVariable>?>(
                "environmentVariables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Framework (e.g., "nextjs", "remix", "astro")
    /// </summary>
    public string? Framework
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("framework");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("framework", value);
        }
    }

    /// <summary>
    /// Git branch to deploy
    /// </summary>
    public string? GitBranch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("gitBranch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("gitBranch", value);
        }
    }

    /// <summary>
    /// Custom install command
    /// </summary>
    public string? InstallCommand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("installCommand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("installCommand", value);
        }
    }

    /// <summary>
    /// Build output directory
    /// </summary>
    public string? OutputDirectory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("outputDirectory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("outputDirectory", value);
        }
    }

    /// <summary>
    /// Root directory of the project
    /// </summary>
    public string? RootDirectory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rootDirectory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rootDirectory", value);
        }
    }

    public ProjectCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateParams(ProjectCreateParams projectCreateParams)
        : base(projectCreateParams)
    {
        this._rawBodyData = new(projectCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProjectCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ProjectCreateParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ProjectCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/applications/v1/projects"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<EnvironmentVariable, EnvironmentVariableFromRaw>))]
public sealed record class EnvironmentVariable : JsonModel
{
    /// <summary>
    /// Environment variable name
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Deployment targets for this variable
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Target>> Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Target>>>(
                "target"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Target>>>(
                "target",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Environment variable value
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Variable type
    /// </summary>
    public ApiEnum<string, global::CaseDev.Models.Applications.V1.Projects.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::CaseDev.Models.Applications.V1.Projects.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        foreach (var item in this.Target)
        {
            item.Validate();
        }
        _ = this.Value;
        this.Type?.Validate();
    }

    public EnvironmentVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvironmentVariable(EnvironmentVariable environmentVariable)
        : base(environmentVariable) { }
#pragma warning restore CS8618

    public EnvironmentVariable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentVariableFromRaw.FromRawUnchecked"/>
    public static EnvironmentVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentVariableFromRaw : IFromRawJson<EnvironmentVariable>
{
    /// <inheritdoc/>
    public EnvironmentVariable FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnvironmentVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TargetConverter))]
public enum Target
{
    Production,
    Preview,
    Development,
}

sealed class TargetConverter : JsonConverter<Target>
{
    public override Target Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "production" => Target.Production,
            "preview" => Target.Preview,
            "development" => Target.Development,
            _ => (Target)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Target value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Target.Production => "production",
                Target.Preview => "preview",
                Target.Development => "development",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Variable type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Plain,
    Encrypted,
    Secret,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Applications.V1.Projects.Type>
{
    public override global::CaseDev.Models.Applications.V1.Projects.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "plain" => global::CaseDev.Models.Applications.V1.Projects.Type.Plain,
            "encrypted" => global::CaseDev.Models.Applications.V1.Projects.Type.Encrypted,
            "secret" => global::CaseDev.Models.Applications.V1.Projects.Type.Secret,
            _ => (global::CaseDev.Models.Applications.V1.Projects.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Applications.V1.Projects.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Applications.V1.Projects.Type.Plain => "plain",
                global::CaseDev.Models.Applications.V1.Projects.Type.Encrypted => "encrypted",
                global::CaseDev.Models.Applications.V1.Projects.Type.Secret => "secret",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
