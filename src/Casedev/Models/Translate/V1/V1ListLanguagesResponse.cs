using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Translate.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListLanguagesResponse, V1ListLanguagesResponseFromRaw>))]
public sealed record class V1ListLanguagesResponse : JsonModel
{
    public V1ListLanguagesResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V1ListLanguagesResponseData>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
    }

    public V1ListLanguagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListLanguagesResponse(V1ListLanguagesResponse v1ListLanguagesResponse)
        : base(v1ListLanguagesResponse) { }
#pragma warning restore CS8618

    public V1ListLanguagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListLanguagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListLanguagesResponseFromRaw.FromRawUnchecked"/>
    public static V1ListLanguagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListLanguagesResponseFromRaw : IFromRawJson<V1ListLanguagesResponse>
{
    /// <inheritdoc/>
    public V1ListLanguagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListLanguagesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1ListLanguagesResponseData, V1ListLanguagesResponseDataFromRaw>)
)]
public sealed record class V1ListLanguagesResponseData : JsonModel
{
    public IReadOnlyList<Language>? Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Language>>("languages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Language>?>(
                "languages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Languages ?? [])
        {
            item.Validate();
        }
    }

    public V1ListLanguagesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListLanguagesResponseData(V1ListLanguagesResponseData v1ListLanguagesResponseData)
        : base(v1ListLanguagesResponseData) { }
#pragma warning restore CS8618

    public V1ListLanguagesResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListLanguagesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListLanguagesResponseDataFromRaw.FromRawUnchecked"/>
    public static V1ListLanguagesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListLanguagesResponseDataFromRaw : IFromRawJson<V1ListLanguagesResponseData>
{
    /// <inheritdoc/>
    public V1ListLanguagesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListLanguagesResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Language, LanguageFromRaw>))]
public sealed record class Language : JsonModel
{
    /// <summary>
    /// Language code (ISO 639-1)
    /// </summary>
    public string? LanguageValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// Language name (if target specified)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LanguageValue;
        _ = this.Name;
    }

    public Language() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Language(Language language)
        : base(language) { }
#pragma warning restore CS8618

    public Language(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Language(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LanguageFromRaw.FromRawUnchecked"/>
    public static Language FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LanguageFromRaw : IFromRawJson<Language>
{
    /// <inheritdoc/>
    public Language FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Language.FromRawUnchecked(rawData);
}
