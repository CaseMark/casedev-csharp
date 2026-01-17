using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Secrets;

/// <summary>
/// Delete an entire secret group or a specific key within a secret group. When deleting
/// a specific key, the remaining secrets in the group are preserved. When deleting
/// the entire group, all secrets and the group itself are removed.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SecretDeleteGroupParams : ParamsBase
{
    public string? Group { get; init; }

    /// <summary>
    /// Environment name. If not provided, uses the default environment
    /// </summary>
    public string? Env
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("env");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("env", value);
        }
    }

    /// <summary>
    /// Specific key to delete within the group. If not provided, the entire group
    /// is deleted
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("key", value);
        }
    }

    public SecretDeleteGroupParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretDeleteGroupParams(SecretDeleteGroupParams secretDeleteGroupParams)
        : base(secretDeleteGroupParams)
    {
        this.Group = secretDeleteGroupParams.Group;
    }
#pragma warning restore CS8618

    public SecretDeleteGroupParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretDeleteGroupParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SecretDeleteGroupParams FromRawUnchecked(
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
                ["Group"] = this.Group,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SecretDeleteGroupParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Group?.Equals(other.Group) ?? other.Group == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/compute/v1/secrets/{0}", this.Group)
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
