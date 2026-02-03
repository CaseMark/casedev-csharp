using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Projects.V1;

/// <summary>
/// List all environment variables for a project, grouped by environment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1ListEnvVarsParams : ParamsBase
{
    public string? ID { get; init; }

    public ApiEnum<string, V1ListEnvVarsParamsEnvironment>? Environment
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, V1ListEnvVarsParamsEnvironment>
            >("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("environment", value);
        }
    }

    public V1ListEnvVarsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListEnvVarsParams(V1ListEnvVarsParams v1ListEnvVarsParams)
        : base(v1ListEnvVarsParams)
    {
        this.ID = v1ListEnvVarsParams.ID;
    }
#pragma warning restore CS8618

    public V1ListEnvVarsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListEnvVarsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1ListEnvVarsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1ListEnvVarsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

[JsonConverter(typeof(V1ListEnvVarsParamsEnvironmentConverter))]
public enum V1ListEnvVarsParamsEnvironment
{
    Production,
    Preview,
    Development,
    Shared,
}

sealed class V1ListEnvVarsParamsEnvironmentConverter : JsonConverter<V1ListEnvVarsParamsEnvironment>
{
    public override V1ListEnvVarsParamsEnvironment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "production" => V1ListEnvVarsParamsEnvironment.Production,
            "preview" => V1ListEnvVarsParamsEnvironment.Preview,
            "development" => V1ListEnvVarsParamsEnvironment.Development,
            "shared" => V1ListEnvVarsParamsEnvironment.Shared,
            _ => (V1ListEnvVarsParamsEnvironment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1ListEnvVarsParamsEnvironment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1ListEnvVarsParamsEnvironment.Production => "production",
                V1ListEnvVarsParamsEnvironment.Preview => "preview",
                V1ListEnvVarsParamsEnvironment.Development => "development",
                V1ListEnvVarsParamsEnvironment.Shared => "shared",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
