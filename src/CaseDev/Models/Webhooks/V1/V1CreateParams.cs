using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Webhooks.V1;

/// <summary>
/// Create a new webhook endpoint to receive real-time notifications for events in
/// your Case.dev workspace. Webhooks enable automated workflows by sending HTTP
/// POST requests to your specified URL when events occur.
///
/// <para>**Security**: Webhooks are signed with HMAC-SHA256 using the provided secret.
/// The signature is included in the `X-Case-Signature` header.</para>
///
/// <para>**Available Events**: - `document.processed` - Document OCR/processing completed
/// - `vault.updated` - Document added/removed from vault - `action.completed` -
/// Workflow action finished - `compute.finished` - Compute job completed</para>
/// </summary>
public sealed record class V1CreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of event types to subscribe to
    /// </summary>
    public required IReadOnlyList<string> Events
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("events", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'events' cannot be null",
                    new ArgumentOutOfRangeException("events", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'events' cannot be null",
                    new ArgumentNullException("events")
                );
        }
        init
        {
            this._rawBodyData["events"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// HTTPS URL where webhook events will be sent
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("url", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        init
        {
            this._rawBodyData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional description for the webhook
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1CreateParams() { }

    public V1CreateParams(
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
    V1CreateParams(
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

    public static V1CreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/webhooks/v1")
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
