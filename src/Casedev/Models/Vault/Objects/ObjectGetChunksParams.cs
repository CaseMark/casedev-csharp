using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Vault.Objects;

/// <summary>
/// Retrieves full extracted chunk text for a processed vault object. Use this after
/// search when a truncated preview is not enough and you need the exact chunk text
/// or adjacent chunks for surrounding context such as tables, exhibit lists, or
/// multi-part passages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ObjectGetChunksParams : ParamsBase
{
    public required string ID { get; init; }

    public string? ObjectID { get; init; }

    /// <summary>
    /// The last chunk index to return (inclusive). If omitted, only the `start`
    /// chunk is returned. Ranges are limited to 10 chunks.
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
    /// The first chunk index to return (0-based). Defaults to 0.
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

    public ObjectGetChunksParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetChunksParams(ObjectGetChunksParams objectGetChunksParams)
        : base(objectGetChunksParams)
    {
        this.ID = objectGetChunksParams.ID;
        this.ObjectID = objectGetChunksParams.ObjectID;
    }
#pragma warning restore CS8618

    public ObjectGetChunksParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetChunksParams(
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
    public static ObjectGetChunksParams FromRawUnchecked(
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

    public virtual bool Equals(ObjectGetChunksParams? other)
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
                + string.Format("/vault/{0}/objects/{1}/chunks", this.ID, this.ObjectID)
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
