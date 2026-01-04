using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

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
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "contentType"); }
        init { JsonModel.Set(this._rawBodyData, "contentType", value); }
    }

    /// <summary>
    /// Name of the file to upload
    /// </summary>
    public required string Filename
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "filename"); }
        init { JsonModel.Set(this._rawBodyData, "filename", value); }
    }

    /// <summary>
    /// Whether to automatically process and index the file for search
    /// </summary>
    public bool? AutoIndex
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "auto_index"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "auto_index", value);
        }
    }

    /// <summary>
    /// Additional metadata to associate with the file
    /// </summary>
    public JsonElement? Metadata
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawBodyData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "metadata", value);
        }
    }

    /// <summary>
    /// Optional folder path for hierarchy preservation. Allows integrations to maintain
    /// source folder structure from systems like NetDocs, Clio, or Smokeball. Example: '/Discovery/Depositions/2024'
    /// </summary>
    public string? Path
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "path"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "path", value);
        }
    }

    /// <summary>
    /// Estimated file size in bytes for cost calculation
    /// </summary>
    public double? SizeBytes
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawBodyData, "sizeBytes"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "sizeBytes", value);
        }
    }

    public VaultUploadParams() { }

    public VaultUploadParams(VaultUploadParams vaultUploadParams)
        : base(vaultUploadParams)
    {
        this._rawBodyData = [.. vaultUploadParams._rawBodyData];
    }

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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
}
