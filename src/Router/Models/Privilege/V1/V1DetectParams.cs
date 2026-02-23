using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Privilege.V1;

/// <summary>
/// Analyzes text or vault documents for legal privilege. Detects attorney-client
/// privilege, work product doctrine, common interest privilege, and litigation hold materials.
///
/// <para>Returns structured privilege flags with confidence scores and policy-friendly
/// rationale suitable for discovery workflows and privilege logs.</para>
///
/// <para>**Size Limit:** Maximum 200,000 characters (larger documents rejected).</para>
///
/// <para>**Permissions:** Requires `chat` permission. When using `document_id`, also
/// requires `vault` permission.</para>
///
/// <para>**Note:** When analyzing vault documents, results are automatically stored
/// in the document's `privilege_analysis` metadata field.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1DetectParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Privilege categories to check. Defaults to all: attorney_client, work_product,
    /// common_interest, litigation_hold
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Category>>? Categories
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, Category>>>(
                "categories"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, Category>>?>(
                "categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Text content to analyze (required if document_id not provided)
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("content", value);
        }
    }

    /// <summary>
    /// Vault object ID to analyze (required if content not provided)
    /// </summary>
    public string? DocumentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("document_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("document_id", value);
        }
    }

    /// <summary>
    /// Include detailed rationale for each category
    /// </summary>
    public bool? IncludeRationale
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("include_rationale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("include_rationale", value);
        }
    }

    /// <summary>
    /// Jurisdiction for privilege rules
    /// </summary>
    public ApiEnum<string, Jurisdiction>? Jurisdiction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Jurisdiction>>(
                "jurisdiction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("jurisdiction", value);
        }
    }

    /// <summary>
    /// LLM model to use for analysis
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    /// <summary>
    /// Vault ID (required when using document_id)
    /// </summary>
    public string? VaultID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("vault_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("vault_id", value);
        }
    }

    public V1DetectParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DetectParams(V1DetectParams v1DetectParams)
        : base(v1DetectParams)
    {
        this._rawBodyData = new(v1DetectParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1DetectParams(
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
    V1DetectParams(
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
    public static V1DetectParams FromRawUnchecked(
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

    public virtual bool Equals(V1DetectParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/privilege/v1/detect")
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

[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    AttorneyClient,
    WorkProduct,
    CommonInterest,
    LitigationHold,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "attorney_client" => Category.AttorneyClient,
            "work_product" => Category.WorkProduct,
            "common_interest" => Category.CommonInterest,
            "litigation_hold" => Category.LitigationHold,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.AttorneyClient => "attorney_client",
                Category.WorkProduct => "work_product",
                Category.CommonInterest => "common_interest",
                Category.LitigationHold => "litigation_hold",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Jurisdiction for privilege rules
/// </summary>
[JsonConverter(typeof(JurisdictionConverter))]
public enum Jurisdiction
{
    UsFederal,
}

sealed class JurisdictionConverter : JsonConverter<Jurisdiction>
{
    public override Jurisdiction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US-Federal" => Jurisdiction.UsFederal,
            _ => (Jurisdiction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Jurisdiction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Jurisdiction.UsFederal => "US-Federal",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
