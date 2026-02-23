using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;
using System = System;

namespace Router.Models.Applications.V1.Projects;

/// <summary>
/// Trigger a new deployment for a project.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProjectCreateDeploymentParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Additional environment variables to set or update before deployment
    /// </summary>
    public IReadOnlyList<ProjectCreateDeploymentParamsEnvironmentVariable>? EnvironmentVariables
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ProjectCreateDeploymentParamsEnvironmentVariable>
            >("environmentVariables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ProjectCreateDeploymentParamsEnvironmentVariable>?>(
                "environmentVariables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ProjectCreateDeploymentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateDeploymentParams(
        ProjectCreateDeploymentParams projectCreateDeploymentParams
    )
        : base(projectCreateDeploymentParams)
    {
        this.ID = projectCreateDeploymentParams.ID;

        this._rawBodyData = new(projectCreateDeploymentParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProjectCreateDeploymentParams(
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
    ProjectCreateDeploymentParams(
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
    public static ProjectCreateDeploymentParams FromRawUnchecked(
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
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(ProjectCreateDeploymentParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/applications/v1/projects/{0}/deployments", this.ID)
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

[JsonConverter(
    typeof(JsonModelConverter<
        ProjectCreateDeploymentParamsEnvironmentVariable,
        ProjectCreateDeploymentParamsEnvironmentVariableFromRaw
    >)
)]
public sealed record class ProjectCreateDeploymentParamsEnvironmentVariable : JsonModel
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
    public required IReadOnlyList<
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
    > Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<
                    ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
                >
            >("target");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<
                    ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
                >
            >("target", ImmutableArray.ToImmutableArray(value));
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
    public ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>
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

    public ProjectCreateDeploymentParamsEnvironmentVariable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateDeploymentParamsEnvironmentVariable(
        ProjectCreateDeploymentParamsEnvironmentVariable projectCreateDeploymentParamsEnvironmentVariable
    )
        : base(projectCreateDeploymentParamsEnvironmentVariable) { }
#pragma warning restore CS8618

    public ProjectCreateDeploymentParamsEnvironmentVariable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectCreateDeploymentParamsEnvironmentVariable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectCreateDeploymentParamsEnvironmentVariableFromRaw.FromRawUnchecked"/>
    public static ProjectCreateDeploymentParamsEnvironmentVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectCreateDeploymentParamsEnvironmentVariableFromRaw
    : IFromRawJson<ProjectCreateDeploymentParamsEnvironmentVariable>
{
    /// <inheritdoc/>
    public ProjectCreateDeploymentParamsEnvironmentVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectCreateDeploymentParamsEnvironmentVariable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProjectCreateDeploymentParamsEnvironmentVariableTargetConverter))]
public enum ProjectCreateDeploymentParamsEnvironmentVariableTarget
{
    Production,
    Preview,
    Development,
}

sealed class ProjectCreateDeploymentParamsEnvironmentVariableTargetConverter
    : JsonConverter<ProjectCreateDeploymentParamsEnvironmentVariableTarget>
{
    public override ProjectCreateDeploymentParamsEnvironmentVariableTarget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "production" => ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production,
            "preview" => ProjectCreateDeploymentParamsEnvironmentVariableTarget.Preview,
            "development" => ProjectCreateDeploymentParamsEnvironmentVariableTarget.Development,
            _ => (ProjectCreateDeploymentParamsEnvironmentVariableTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectCreateDeploymentParamsEnvironmentVariableTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production => "production",
                ProjectCreateDeploymentParamsEnvironmentVariableTarget.Preview => "preview",
                ProjectCreateDeploymentParamsEnvironmentVariableTarget.Development => "development",
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
[JsonConverter(typeof(ProjectCreateDeploymentParamsEnvironmentVariableTypeConverter))]
public enum ProjectCreateDeploymentParamsEnvironmentVariableType
{
    Plain,
    Encrypted,
    Secret,
}

sealed class ProjectCreateDeploymentParamsEnvironmentVariableTypeConverter
    : JsonConverter<ProjectCreateDeploymentParamsEnvironmentVariableType>
{
    public override ProjectCreateDeploymentParamsEnvironmentVariableType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "plain" => ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
            "encrypted" => ProjectCreateDeploymentParamsEnvironmentVariableType.Encrypted,
            "secret" => ProjectCreateDeploymentParamsEnvironmentVariableType.Secret,
            _ => (ProjectCreateDeploymentParamsEnvironmentVariableType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectCreateDeploymentParamsEnvironmentVariableType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectCreateDeploymentParamsEnvironmentVariableType.Plain => "plain",
                ProjectCreateDeploymentParamsEnvironmentVariableType.Encrypted => "encrypted",
                ProjectCreateDeploymentParamsEnvironmentVariableType.Secret => "secret",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
