using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Secrets;

/// <summary>
/// Creates a new secret group in a compute environment. Secret groups organize related
/// secrets for use in serverless functions and workflows. If no environment is specified,
/// the group is created in the default environment.
///
/// <para>**Features:** - Organize secrets by logical groups (e.g., database, APIs,
/// third-party services) - Environment-based isolation - Validation of group names
/// - Conflict detection for existing groups</para>
/// </summary>
public sealed record class SecretCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Unique name for the secret group. Must contain only letters, numbers, hyphens,
    /// and underscores.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Optional description of the secret group's purpose
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "description", value);
        }
    }

    /// <summary>
    /// Environment name where the secret group will be created. Uses default environment
    /// if not specified.
    /// </summary>
    public string? Env
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "env"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "env", value);
        }
    }

    public SecretCreateParams() { }

    public SecretCreateParams(SecretCreateParams secretCreateParams)
        : base(secretCreateParams)
    {
        this._rawBodyData = [.. secretCreateParams._rawBodyData];
    }

    public SecretCreateParams(
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
    SecretCreateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SecretCreateParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/compute/v1/secrets")
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
