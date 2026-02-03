using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using CaseDev.Core;

namespace CaseDev.Models.Vault.Objects;

/// <summary>
/// Get the status of a CaseMark summary workflow job. If the job has been processing
/// for too long, this endpoint will poll CaseMark directly to recover stuck jobs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ObjectGetSummarizeJobParams : ParamsBase
{
    public required string ID { get; init; }

    public required string ObjectID { get; init; }

    public string? JobID { get; init; }

    public ObjectGetSummarizeJobParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetSummarizeJobParams(ObjectGetSummarizeJobParams objectGetSummarizeJobParams)
        : base(objectGetSummarizeJobParams)
    {
        this.ID = objectGetSummarizeJobParams.ID;
        this.ObjectID = objectGetSummarizeJobParams.ObjectID;
        this.JobID = objectGetSummarizeJobParams.JobID;
    }
#pragma warning restore CS8618

    public ObjectGetSummarizeJobParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetSummarizeJobParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ObjectGetSummarizeJobParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["ObjectID"] = this.ObjectID,
                ["JobID"] = this.JobID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ObjectGetSummarizeJobParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && this.ObjectID.Equals(other.ObjectID)
            && (this.JobID?.Equals(other.JobID) ?? other.JobID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/vault/{0}/objects/{1}/summarize/{2}",
                    this.ID,
                    this.ObjectID,
                    this.JobID
                )
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
