using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Payments.V1.Accounts;

/// <summary>
/// Create a new payment account (trust, operating, escrow, client sub-account, etc.)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Account name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Account type
    /// </summary>
    public required ApiEnum<string, global::CaseDev.Models.Payments.V1.Accounts.Type> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::CaseDev.Models.Payments.V1.Accounts.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Currency code
    /// </summary>
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

    /// <summary>
    /// Associated matter ID
    /// </summary>
    public string? MatterID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("matter_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("matter_id", value);
        }
    }

    /// <summary>
    /// Additional metadata
    /// </summary>
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
    /// Parent account ID for sub-accounts
    /// </summary>
    public string? ParentAccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("parent_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("parent_account_id", value);
        }
    }

    public AccountCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCreateParams(AccountCreateParams accountCreateParams)
        : base(accountCreateParams)
    {
        this._rawBodyData = new(accountCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountCreateParams(
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
    AccountCreateParams(
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
    public static AccountCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AccountCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/payments/v1/accounts"
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

/// <summary>
/// Account type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Trust,
    Operating,
    Escrow,
    Reserve,
    Client,
    Sub,
}

sealed class TypeConverter : JsonConverter<global::CaseDev.Models.Payments.V1.Accounts.Type>
{
    public override global::CaseDev.Models.Payments.V1.Accounts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trust" => global::CaseDev.Models.Payments.V1.Accounts.Type.Trust,
            "operating" => global::CaseDev.Models.Payments.V1.Accounts.Type.Operating,
            "escrow" => global::CaseDev.Models.Payments.V1.Accounts.Type.Escrow,
            "reserve" => global::CaseDev.Models.Payments.V1.Accounts.Type.Reserve,
            "client" => global::CaseDev.Models.Payments.V1.Accounts.Type.Client,
            "sub" => global::CaseDev.Models.Payments.V1.Accounts.Type.Sub,
            _ => (global::CaseDev.Models.Payments.V1.Accounts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::CaseDev.Models.Payments.V1.Accounts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::CaseDev.Models.Payments.V1.Accounts.Type.Trust => "trust",
                global::CaseDev.Models.Payments.V1.Accounts.Type.Operating => "operating",
                global::CaseDev.Models.Payments.V1.Accounts.Type.Escrow => "escrow",
                global::CaseDev.Models.Payments.V1.Accounts.Type.Reserve => "reserve",
                global::CaseDev.Models.Payments.V1.Accounts.Type.Client => "client",
                global::CaseDev.Models.Payments.V1.Accounts.Type.Sub => "sub",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
