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
/// Create a new environment variable for a project
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProjectCreateEnvParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Environment variable name
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("key");
        }
        init { this._rawBodyData.Set("key", value); }
    }

    /// <summary>
    /// Deployment targets for this variable
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ProjectCreateEnvParamsTarget>> Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ProjectCreateEnvParamsTarget>>
            >("target");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, ProjectCreateEnvParamsTarget>>>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("value");
        }
        init { this._rawBodyData.Set("value", value); }
    }

    /// <summary>
    /// Specific git branch (for preview deployments)
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
    /// Variable type
    /// </summary>
    public ApiEnum<string, ProjectCreateEnvParamsType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ProjectCreateEnvParamsType>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    public ProjectCreateEnvParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateEnvParams(ProjectCreateEnvParams projectCreateEnvParams)
        : base(projectCreateEnvParams)
    {
        this.ID = projectCreateEnvParams.ID;

        this._rawBodyData = new(projectCreateEnvParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProjectCreateEnvParams(
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
    ProjectCreateEnvParams(
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
    public static ProjectCreateEnvParams FromRawUnchecked(
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

    public virtual bool Equals(ProjectCreateEnvParams? other)
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
                + string.Format("/applications/v1/projects/{0}/env", this.ID)
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

[JsonConverter(typeof(ProjectCreateEnvParamsTargetConverter))]
public enum ProjectCreateEnvParamsTarget
{
    Production,
    Preview,
    Development,
}

sealed class ProjectCreateEnvParamsTargetConverter : JsonConverter<ProjectCreateEnvParamsTarget>
{
    public override ProjectCreateEnvParamsTarget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "production" => ProjectCreateEnvParamsTarget.Production,
            "preview" => ProjectCreateEnvParamsTarget.Preview,
            "development" => ProjectCreateEnvParamsTarget.Development,
            _ => (ProjectCreateEnvParamsTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectCreateEnvParamsTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectCreateEnvParamsTarget.Production => "production",
                ProjectCreateEnvParamsTarget.Preview => "preview",
                ProjectCreateEnvParamsTarget.Development => "development",
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
[JsonConverter(typeof(ProjectCreateEnvParamsTypeConverter))]
public enum ProjectCreateEnvParamsType
{
    Plain,
    Encrypted,
    Secret,
}

sealed class ProjectCreateEnvParamsTypeConverter : JsonConverter<ProjectCreateEnvParamsType>
{
    public override ProjectCreateEnvParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "plain" => ProjectCreateEnvParamsType.Plain,
            "encrypted" => ProjectCreateEnvParamsType.Encrypted,
            "secret" => ProjectCreateEnvParamsType.Secret,
            _ => (ProjectCreateEnvParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectCreateEnvParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectCreateEnvParamsType.Plain => "plain",
                ProjectCreateEnvParamsType.Encrypted => "encrypted",
                ProjectCreateEnvParamsType.Secret => "secret",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
