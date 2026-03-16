using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Mail.V1.Inboxes;

/// <summary>
/// Get attachment metadata for a message in an inbox owned by the authenticated organization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboxGetAttachmentParams : ParamsBase
{
    public required string InboxID { get; init; }

    public required string MessageID { get; init; }

    public string? AttachmentID { get; init; }

    public InboxGetAttachmentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboxGetAttachmentParams(InboxGetAttachmentParams inboxGetAttachmentParams)
        : base(inboxGetAttachmentParams)
    {
        this.InboxID = inboxGetAttachmentParams.InboxID;
        this.MessageID = inboxGetAttachmentParams.MessageID;
        this.AttachmentID = inboxGetAttachmentParams.AttachmentID;
    }
#pragma warning restore CS8618

    public InboxGetAttachmentParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboxGetAttachmentParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InboxGetAttachmentParams FromRawUnchecked(
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
                    ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
                    ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
                    ["AttachmentID"] = JsonSerializer.SerializeToElement(this.AttachmentID),
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

    public virtual bool Equals(InboxGetAttachmentParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InboxID.Equals(other.InboxID)
            && this.MessageID.Equals(other.MessageID)
            && (this.AttachmentID?.Equals(other.AttachmentID) ?? other.AttachmentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/mail/v1/inboxes/{0}/messages/{1}/attachments/{2}",
                    this.InboxID,
                    this.MessageID,
                    this.AttachmentID
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
