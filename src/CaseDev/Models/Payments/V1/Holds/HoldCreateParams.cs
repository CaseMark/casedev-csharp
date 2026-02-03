using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Payments.V1.Holds;

/// <summary>
/// Create a hold on funds in an account with release conditions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class HoldCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Account to hold funds in
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("account_id");
        }
        init { this._rawBodyData.Set("account_id", value); }
    }

    /// <summary>
    /// Amount in cents to hold
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    public string? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("currency", value);
        }
    }

    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expires_at", value);
        }
    }

    public string? Memo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("memo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("memo", value);
        }
    }

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
    /// Action to take when released
    /// </summary>
    public string? OnReleaseAction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("on_release_action");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("on_release_action", value);
        }
    }

    public JsonElement? OnReleaseConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("on_release_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("on_release_config", value);
        }
    }

    public IReadOnlyList<ReleaseCondition>? ReleaseConditions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ReleaseCondition>>(
                "release_conditions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ReleaseCondition>?>(
                "release_conditions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public HoldCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HoldCreateParams(HoldCreateParams holdCreateParams)
        : base(holdCreateParams)
    {
        this._rawBodyData = new(holdCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public HoldCreateParams(
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
    HoldCreateParams(
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
    public static HoldCreateParams FromRawUnchecked(
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
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(HoldCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/payments/v1/holds"
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

[JsonConverter(typeof(JsonModelConverter<ReleaseCondition, ReleaseConditionFromRaw>))]
public sealed record class ReleaseCondition : JsonModel
{
    public IReadOnlyList<string>? Approvers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("approvers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "approvers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    public string? DocumentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    public ApiEnum<string, global::CaseDev.Models.Payments.V1.Holds.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::CaseDev.Models.Payments.V1.Holds.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Approvers;
        _ = this.Date;
        _ = this.DocumentID;
        this.Type?.Validate();
    }

    public ReleaseCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReleaseCondition(ReleaseCondition releaseCondition)
        : base(releaseCondition) { }
#pragma warning restore CS8618

    public ReleaseCondition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReleaseCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReleaseConditionFromRaw.FromRawUnchecked"/>
    public static ReleaseCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReleaseConditionFromRaw : IFromRawJson<ReleaseCondition>
{
    /// <inheritdoc/>
    public ReleaseCondition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReleaseCondition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ManualApproval,
    DocumentSigned,
    DateReached,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Payments.V1.Holds.Type>
{
    public override global::CaseDev.Models.Payments.V1.Holds.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual_approval" => global::CaseDev.Models.Payments.V1.Holds.Type.ManualApproval,
            "document_signed" => global::CaseDev.Models.Payments.V1.Holds.Type.DocumentSigned,
            "date_reached" => global::CaseDev.Models.Payments.V1.Holds.Type.DateReached,
            _ => (global::CaseDev.Models.Payments.V1.Holds.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Payments.V1.Holds.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Payments.V1.Holds.Type.ManualApproval => "manual_approval",
                global::CaseDev.Models.Payments.V1.Holds.Type.DocumentSigned => "document_signed",
                global::CaseDev.Models.Payments.V1.Holds.Type.DateReached => "date_reached",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
