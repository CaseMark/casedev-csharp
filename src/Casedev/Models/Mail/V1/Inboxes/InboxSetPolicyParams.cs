using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Casedev.Core;

namespace Casedev.Models.Mail.V1.Inboxes;

/// <summary>
/// Set the sender allowlist and send/reply/read access rules for an inbox owned
/// by the authenticated organization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InboxSetPolicyParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboxID { get; init; }

    /// <summary>
    /// Exact emails, @domain rules, or *
    /// </summary>
    public IReadOnlyList<string>? AllowedSenderPatterns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "allowedSenderPatterns"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "allowedSenderPatterns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? EnforceSenderAllowlist
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enforceSenderAllowlist");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enforceSenderAllowlist", value);
        }
    }

    /// <summary>
    /// Rules like organization, operator, user:&lt;id&gt;, api_key, api_key:&lt;id&gt;,
    /// clerk_session, or *
    /// </summary>
    public IReadOnlyList<string>? ReadAccessRules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("readAccessRules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "readAccessRules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rules like organization, operator, user:&lt;id&gt;, api_key, api_key:&lt;id&gt;,
    /// clerk_session, or *
    /// </summary>
    public IReadOnlyList<string>? ReplyAccessRules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("replyAccessRules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "replyAccessRules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rules like organization, user:&lt;id&gt;, api_key, api_key:&lt;id&gt;, clerk_session,
    /// or *
    /// </summary>
    public IReadOnlyList<string>? SendAccessRules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("sendAccessRules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "sendAccessRules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public InboxSetPolicyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboxSetPolicyParams(InboxSetPolicyParams inboxSetPolicyParams)
        : base(inboxSetPolicyParams)
    {
        this.InboxID = inboxSetPolicyParams.InboxID;

        this._rawBodyData = new(inboxSetPolicyParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InboxSetPolicyParams(
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
    InboxSetPolicyParams(
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InboxSetPolicyParams FromRawUnchecked(
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
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InboxSetPolicyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InboxID?.Equals(other.InboxID) ?? other.InboxID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/mail/v1/inboxes/{0}/policy", this.InboxID)
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
