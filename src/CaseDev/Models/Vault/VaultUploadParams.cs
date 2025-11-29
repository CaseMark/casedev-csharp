using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

/// <summary>
/// Generate a presigned URL for uploading files directly to a vault's S3 storage.
/// This endpoint creates a temporary upload URL that allows secure file uploads without
/// exposing credentials. Files can be automatically indexed for semantic search
/// or stored for manual processing.
/// </summary>
public sealed record class VaultUploadParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// MIME type of the file (e.g., application/pdf, image/jpeg)
    /// </summary>
    public required string ContentType
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("contentType", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'contentType' cannot be null",
                    new ArgumentOutOfRangeException("contentType", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'contentType' cannot be null",
                    new ArgumentNullException("contentType")
                );
        }
        init
        {
            this._rawBodyData["contentType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the file to upload
    /// </summary>
    public required string Filename
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("filename", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'filename' cannot be null",
                    new ArgumentOutOfRangeException("filename", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'filename' cannot be null",
                    new ArgumentNullException("filename")
                );
        }
        init
        {
            this._rawBodyData["filename"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to automatically process and index the file for search
    /// </summary>
    public bool? AutoIndex
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("auto_index", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["auto_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata to associate with the file
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Estimated file size in bytes for cost calculation
    /// </summary>
    public double? SizeBytes
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("sizeBytes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["sizeBytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public VaultUploadParams() { }

    public VaultUploadParams(
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
    VaultUploadParams(
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

    public static VaultUploadParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/vault/{0}/upload", this.ID)
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
