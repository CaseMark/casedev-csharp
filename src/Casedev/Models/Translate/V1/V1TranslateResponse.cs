using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Translate.V1;

[JsonConverter(typeof(JsonModelConverter<V1TranslateResponse, V1TranslateResponseFromRaw>))]
public sealed record class V1TranslateResponse : JsonModel
{
    public V1TranslateResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V1TranslateResponseData>("data");
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

    public V1TranslateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1TranslateResponse(V1TranslateResponse v1TranslateResponse)
        : base(v1TranslateResponse) { }
#pragma warning restore CS8618

    public V1TranslateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1TranslateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1TranslateResponseFromRaw.FromRawUnchecked"/>
    public static V1TranslateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1TranslateResponseFromRaw : IFromRawJson<V1TranslateResponse>
{
    /// <inheritdoc/>
    public V1TranslateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1TranslateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1TranslateResponseData, V1TranslateResponseDataFromRaw>))]
public sealed record class V1TranslateResponseData : JsonModel
{
    public IReadOnlyList<Translation>? Translations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Translation>>("translations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Translation>?>(
                "translations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Translations ?? [])
        {
            item.Validate();
        }
    }

    public V1TranslateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1TranslateResponseData(V1TranslateResponseData v1TranslateResponseData)
        : base(v1TranslateResponseData) { }
#pragma warning restore CS8618

    public V1TranslateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1TranslateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1TranslateResponseDataFromRaw.FromRawUnchecked"/>
    public static V1TranslateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1TranslateResponseDataFromRaw : IFromRawJson<V1TranslateResponseData>
{
    /// <inheritdoc/>
    public V1TranslateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1TranslateResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Translation, TranslationFromRaw>))]
public sealed record class Translation : JsonModel
{
    /// <summary>
    /// Detected source language (if source not specified)
    /// </summary>
    public string? DetectedSourceLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("detectedSourceLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("detectedSourceLanguage", value);
        }
    }

    /// <summary>
    /// Model used for translation
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Translated text
    /// </summary>
    public string? TranslatedText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("translatedText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("translatedText", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DetectedSourceLanguage;
        _ = this.Model;
        _ = this.TranslatedText;
    }

    public Translation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Translation(Translation translation)
        : base(translation) { }
#pragma warning restore CS8618

    public Translation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Translation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranslationFromRaw.FromRawUnchecked"/>
    public static Translation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TranslationFromRaw : IFromRawJson<Translation>
{
    /// <inheritdoc/>
    public Translation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Translation.FromRawUnchecked(rawData);
}
