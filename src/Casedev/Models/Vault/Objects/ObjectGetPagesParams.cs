using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

/// <summary>
/// Retrieves the raw text of a processed vault object split by page. The object
/// must have completed ingestion before pages can be retrieved — for PDFs this requires
/// the OCR pipeline to have finished writing the per-page sidecar, so freshly uploaded
/// PDFs return 400 with the current `ingestionStatus` until processing completes.
/// For PDFs this returns the per-page OCR text. For plain text files (txt, md, source
/// code, court reporter transcripts) the text is split using right-aligned page-number
/// markers when present (preserving the original document numbering, including continuations
/// like Volume 2 starting at page 234), falling back to form-feed (\f) page-break
/// characters, and finally a single page if neither signal is present. Use the optional
/// `start` and `end` query parameters to fetch a specific inclusive page range.
/// Pages with no text are omitted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ObjectGetPagesParams : ParamsBase
{
    public required string ID { get; init; }

    public string? ObjectID { get; init; }

    /// <summary>
    /// Last page to return (inclusive, 1-indexed). If omitted, returns through the
    /// last page with text.
    /// </summary>
    public long? End
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("end", value);
        }
    }

    /// <summary>
    /// First page to return (inclusive, 1-indexed). If omitted, starts at the first
    /// page with text.
    /// </summary>
    public long? Start
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("start", value);
        }
    }

    public ObjectGetPagesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetPagesParams(ObjectGetPagesParams objectGetPagesParams)
        : base(objectGetPagesParams)
    {
        this.ID = objectGetPagesParams.ID;
        this.ObjectID = objectGetPagesParams.ObjectID;
    }
#pragma warning restore CS8618

    public ObjectGetPagesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetPagesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id,
        string objectID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
        this.ObjectID = objectID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ObjectGetPagesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id,
        string objectID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id,
            objectID
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

    public virtual bool Equals(ObjectGetPagesParams? other)
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
                + string.Format("/vault/{0}/objects/{1}/pages", this.ID, this.ObjectID)
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
