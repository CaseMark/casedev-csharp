using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Secrets;

/// <summary>
/// Retrieve the keys (names) of secrets in a specified group within a compute environment.
/// For security reasons, actual secret values are not returned - only the keys and metadata.
/// </summary>
public sealed record class SecretRetrieveGroupParams : ParamsBase
{
    public string? Group { get; init; }

    /// <summary>
    /// Environment name. If not specified, uses the default environment
    /// </summary>
    public string? Env
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "env"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "env", value);
        }
    }

    public SecretRetrieveGroupParams() { }

    public SecretRetrieveGroupParams(SecretRetrieveGroupParams secretRetrieveGroupParams)
        : base(secretRetrieveGroupParams)
    {
        this.Group = secretRetrieveGroupParams.Group;
    }

    public SecretRetrieveGroupParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretRetrieveGroupParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SecretRetrieveGroupParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
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
}
