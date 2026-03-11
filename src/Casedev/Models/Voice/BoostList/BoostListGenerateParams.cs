using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Voice.BoostList;

/// <summary>
/// Generates a categorized word boost list from a completed transcription job. Extracts
/// entities from the pass-1 transcript for use as `word_boost` in a second transcription pass.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BoostListGenerateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Completed pass-1 transcription job ID (tr_...)
    /// </summary>
    public required string TranscriptionJobID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("transcription_job_id");
        }
        init { this._rawBodyData.Set("transcription_job_id", value); }
    }

    /// <summary>
    /// Optional filter for entity categories to extract
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BoostListGenerateParamsCategory>>? Categories
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BoostListGenerateParamsCategory>>
            >("categories");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, BoostListGenerateParamsCategory>
            >?>("categories", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    public BoostListGenerateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BoostListGenerateParams(BoostListGenerateParams boostListGenerateParams)
        : base(boostListGenerateParams)
    {
        this._rawBodyData = new(boostListGenerateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BoostListGenerateParams(
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
    BoostListGenerateParams(
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
    public static BoostListGenerateParams FromRawUnchecked(
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

    public virtual bool Equals(BoostListGenerateParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/voice/boost-list/generate"
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

[JsonConverter(typeof(BoostListGenerateParamsCategoryConverter))]
public enum BoostListGenerateParamsCategory
{
    Person,
    Organization,
    LegalTerm,
    Medical,
    Citation,
    Email,
}

sealed class BoostListGenerateParamsCategoryConverter
    : JsonConverter<BoostListGenerateParamsCategory>
{
    public override BoostListGenerateParamsCategory Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "person" => BoostListGenerateParamsCategory.Person,
            "organization" => BoostListGenerateParamsCategory.Organization,
            "legal_term" => BoostListGenerateParamsCategory.LegalTerm,
            "medical" => BoostListGenerateParamsCategory.Medical,
            "citation" => BoostListGenerateParamsCategory.Citation,
            "email" => BoostListGenerateParamsCategory.Email,
            _ => (BoostListGenerateParamsCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BoostListGenerateParamsCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BoostListGenerateParamsCategory.Person => "person",
                BoostListGenerateParamsCategory.Organization => "organization",
                BoostListGenerateParamsCategory.LegalTerm => "legal_term",
                BoostListGenerateParamsCategory.Medical => "medical",
                BoostListGenerateParamsCategory.Citation => "citation",
                BoostListGenerateParamsCategory.Email => "email",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
