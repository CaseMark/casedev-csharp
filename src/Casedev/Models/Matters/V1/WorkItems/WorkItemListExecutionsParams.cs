using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Matters.V1.WorkItems;

/// <summary>
/// List execution attempts for a work item, including agent and run linkage.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkItemListExecutionsParams : ParamsBase
{
    public required string ID { get; init; }

    public string? WorkItemID { get; init; }

    public WorkItemListExecutionsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkItemListExecutionsParams(WorkItemListExecutionsParams workItemListExecutionsParams)
        : base(workItemListExecutionsParams)
    {
        this.ID = workItemListExecutionsParams.ID;
        this.WorkItemID = workItemListExecutionsParams.WorkItemID;
    }
#pragma warning restore CS8618

    public WorkItemListExecutionsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkItemListExecutionsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id,
        string workItemID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
        this.WorkItemID = workItemID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkItemListExecutionsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id,
        string workItemID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id,
            workItemID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["WorkItemID"] = JsonSerializer.SerializeToElement(this.WorkItemID),
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

    public virtual bool Equals(WorkItemListExecutionsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.WorkItemID?.Equals(other.WorkItemID) ?? other.WorkItemID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/matters/v1/{0}/work-items/{1}/executions",
                    this.ID,
                    this.WorkItemID
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
