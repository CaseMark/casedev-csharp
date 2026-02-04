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

namespace CaseDev.Models.Vault.Multipart;

/// <summary>
/// Complete a multipart upload by providing the list of part numbers and ETags.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MultipartCompleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required string ObjectID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("objectId");
        }
        init { this._rawBodyData.Set("objectId", value); }
    }

    public required IReadOnlyList<Part> Parts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Part>>("parts");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Part>>(
                "parts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long SizeBytes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("sizeBytes");
        }
        init { this._rawBodyData.Set("sizeBytes", value); }
    }

    public required string UploadID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("uploadId");
        }
        init { this._rawBodyData.Set("uploadId", value); }
    }

    public MultipartCompleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultipartCompleteParams(MultipartCompleteParams multipartCompleteParams)
        : base(multipartCompleteParams)
    {
        this.ID = multipartCompleteParams.ID;

        this._rawBodyData = new(multipartCompleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MultipartCompleteParams(
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
    MultipartCompleteParams(
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
    public static MultipartCompleteParams FromRawUnchecked(
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

    public virtual bool Equals(MultipartCompleteParams? other)
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
                + string.Format("/vault/{0}/multipart/complete", this.ID)
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

[JsonConverter(typeof(JsonModelConverter<Part, PartFromRaw>))]
public sealed record class Part : JsonModel
{
    public required string Etag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("etag");
        }
        init { this._rawData.Set("etag", value); }
    }

    public required long PartNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("partNumber");
        }
        init { this._rawData.Set("partNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Etag;
        _ = this.PartNumber;
    }

    public Part() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Part(Part part)
        : base(part) { }
#pragma warning restore CS8618

    public Part(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Part(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PartFromRaw.FromRawUnchecked"/>
    public static Part FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PartFromRaw : IFromRawJson<Part>
{
    /// <inheritdoc/>
    public Part FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Part.FromRawUnchecked(rawData);
}
