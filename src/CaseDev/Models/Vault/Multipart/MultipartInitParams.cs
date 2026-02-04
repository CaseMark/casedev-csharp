using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Multipart;

/// <summary>
/// Initiate a multipart upload for large files (>5GB). Returns an uploadId and object
/// metadata. Use part URLs endpoint to upload parts and complete endpoint to finalize.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MultipartInitParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// MIME type of the file
    /// </summary>
    public required string ContentType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("contentType");
        }
        init { this._rawBodyData.Set("contentType", value); }
    }

    /// <summary>
    /// Name of the file to upload
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("filename");
        }
        init { this._rawBodyData.Set("filename", value); }
    }

    /// <summary>
    /// File size in bytes (required, max 8GB).
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("sizeBytes");
        }
        init { this._rawBodyData.Set("sizeBytes", value); }
    }

    /// <summary>
    /// Whether to automatically process and index the file for search
    /// </summary>
    public bool? AutoIndex
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("auto_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("auto_index", value);
        }
    }

    /// <summary>
    /// Additional metadata to associate with the file
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Multipart part size in bytes (min 5MB). Defaults to 64MB.
    /// </summary>
    public long? PartSizeBytes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("partSizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("partSizeBytes", value);
        }
    }

    /// <summary>
    /// Optional folder path for hierarchy preservation
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("path", value);
        }
    }

    public MultipartInitParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultipartInitParams(MultipartInitParams multipartInitParams)
        : base(multipartInitParams)
    {
        this.ID = multipartInitParams.ID;

        this._rawBodyData = new(multipartInitParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MultipartInitParams(
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
    MultipartInitParams(
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
    public static MultipartInitParams FromRawUnchecked(
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

    public virtual bool Equals(MultipartInitParams? other)
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
                + string.Format("/vault/{0}/multipart/init", this.ID)
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
