using System;
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

namespace CaseDev.Models.Projects.V1;

/// <summary>
/// Create or update environment variables for a project
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1CreateEnvVarsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public IReadOnlyList<EnvVar>? EnvVars
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<EnvVar>>("envVars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EnvVar>?>(
                "envVars",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public V1CreateEnvVarsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateEnvVarsParams(V1CreateEnvVarsParams v1CreateEnvVarsParams)
        : base(v1CreateEnvVarsParams)
    {
        this.ID = v1CreateEnvVarsParams.ID;

        this._rawBodyData = new(v1CreateEnvVarsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1CreateEnvVarsParams(
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
    V1CreateEnvVarsParams(
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
    public static V1CreateEnvVarsParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1CreateEnvVarsParams? other)
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/projects/v1/{0}/env-vars", this.ID)
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

[JsonConverter(typeof(JsonModelConverter<EnvVar, EnvVarFromRaw>))]
public sealed record class EnvVar : JsonModel
{
    public required ApiEnum<string, global::CaseDev.Models.Projects.V1.Environment> Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::CaseDev.Models.Projects.V1.Environment>
            >("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public bool? IsSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isSecret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isSecret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Environment.Validate();
        _ = this.Key;
        _ = this.Value;
        _ = this.Description;
        _ = this.IsSecret;
    }

    public EnvVar() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvVar(EnvVar envVar)
        : base(envVar) { }
#pragma warning restore CS8618

    public EnvVar(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvVar(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvVarFromRaw.FromRawUnchecked"/>
    public static EnvVar FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvVarFromRaw : IFromRawJson<EnvVar>
{
    /// <inheritdoc/>
    public EnvVar FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnvVar.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EnvironmentConverter))]
public enum Environment
{
    Production,
    Preview,
    Development,
    Shared,
}

sealed class EnvironmentConverter : JsonConverter<global::CaseDev.Models.Projects.V1.Environment>
{
    public override global::CaseDev.Models.Projects.V1.Environment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "production" => global::CaseDev.Models.Projects.V1.Environment.Production,
            "preview" => global::CaseDev.Models.Projects.V1.Environment.Preview,
            "development" => global::CaseDev.Models.Projects.V1.Environment.Development,
            "shared" => global::CaseDev.Models.Projects.V1.Environment.Shared,
            _ => (global::CaseDev.Models.Projects.V1.Environment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Projects.V1.Environment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Projects.V1.Environment.Production => "production",
                global::CaseDev.Models.Projects.V1.Environment.Preview => "preview",
                global::CaseDev.Models.Projects.V1.Environment.Development => "development",
                global::CaseDev.Models.Projects.V1.Environment.Shared => "shared",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
