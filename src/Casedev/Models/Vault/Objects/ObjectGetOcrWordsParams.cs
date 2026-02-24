using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

/// <summary>
/// Retrieves word-level OCR bounding box data for a processed PDF document. Each
/// word includes its text, normalized bounding box coordinates (0-1 range), confidence
/// score, and global word index. Use this data to highlight specific text ranges
/// in a PDF viewer based on word indices from search results.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ObjectGetOcrWordsParams : ParamsBase
{
    public required string ID { get; init; }

    public string? ObjectID { get; init; }

    /// <summary>
    /// Filter to a specific page number (1-indexed). If omitted, returns all pages.
    /// </summary>
    public long? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Filter to words ending at this index (inclusive). Useful for retrieving words
    /// for a specific chunk.
    /// </summary>
    public long? WordEnd
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("wordEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("wordEnd", value);
        }
    }

    /// <summary>
    /// Filter to words starting at this index (inclusive). Useful for retrieving
    /// words for a specific chunk.
    /// </summary>
    public long? WordStart
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("wordStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("wordStart", value);
        }
    }

    public ObjectGetOcrWordsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetOcrWordsParams(ObjectGetOcrWordsParams objectGetOcrWordsParams)
        : base(objectGetOcrWordsParams)
    {
        this.ID = objectGetOcrWordsParams.ID;
        this.ObjectID = objectGetOcrWordsParams.ObjectID;
    }
#pragma warning restore CS8618

    public ObjectGetOcrWordsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetOcrWordsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ObjectGetOcrWordsParams FromRawUnchecked(
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
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["ObjectID"] = JsonSerializer.SerializeToElement(this.ObjectID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ObjectGetOcrWordsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.ObjectID?.Equals(other.ObjectID) ?? other.ObjectID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/vault/{0}/objects/{1}/ocr-words", this.ID, this.ObjectID)
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
