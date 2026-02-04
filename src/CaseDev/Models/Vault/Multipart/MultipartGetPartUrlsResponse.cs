using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Multipart;

[JsonConverter(
    typeof(JsonModelConverter<MultipartGetPartUrlsResponse, MultipartGetPartUrlsResponseFromRaw>)
)]
public sealed record class MultipartGetPartUrlsResponse : JsonModel
{
    public IReadOnlyList<Url>? Urls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Url>>("urls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Url>?>(
                "urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Urls ?? [])
        {
            item.Validate();
        }
    }

    public MultipartGetPartUrlsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultipartGetPartUrlsResponse(MultipartGetPartUrlsResponse multipartGetPartUrlsResponse)
        : base(multipartGetPartUrlsResponse) { }
#pragma warning restore CS8618

    public MultipartGetPartUrlsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultipartGetPartUrlsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultipartGetPartUrlsResponseFromRaw.FromRawUnchecked"/>
    public static MultipartGetPartUrlsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultipartGetPartUrlsResponseFromRaw : IFromRawJson<MultipartGetPartUrlsResponse>
{
    /// <inheritdoc/>
    public MultipartGetPartUrlsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MultipartGetPartUrlsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Url, UrlFromRaw>))]
public sealed record class Url : JsonModel
{
    public long? PartNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("partNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("partNumber", value);
        }
    }

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartNumber;
        _ = this.UrlValue;
    }

    public Url() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Url(Url url)
        : base(url) { }
#pragma warning restore CS8618

    public Url(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Url(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlFromRaw.FromRawUnchecked"/>
    public static Url FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlFromRaw : IFromRawJson<Url>
{
    /// <inheritdoc/>
    public Url FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Url.FromRawUnchecked(rawData);
}
