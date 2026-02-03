using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1SimilarResponse, V1SimilarResponseFromRaw>))]
public sealed record class V1SimilarResponse : JsonModel
{
    /// <summary>
    /// Number of similar sources found
    /// </summary>
    public long? Found
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("found");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("found", value);
        }
    }

    /// <summary>
    /// Usage guidance
    /// </summary>
    public string? Hint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hint", value);
        }
    }

    /// <summary>
    /// Jurisdiction filter applied
    /// </summary>
    public string? Jurisdiction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jurisdiction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jurisdiction", value);
        }
    }

    public IReadOnlyList<SimilarSource>? SimilarSources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimilarSource>>("similarSources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SimilarSource>?>(
                "similarSources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original source URL
    /// </summary>
    public string? SourceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Found;
        _ = this.Hint;
        _ = this.Jurisdiction;
        foreach (var item in this.SimilarSources ?? [])
        {
            item.Validate();
        }
        _ = this.SourceUrl;
    }

    public V1SimilarResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SimilarResponse(V1SimilarResponse v1SimilarResponse)
        : base(v1SimilarResponse) { }
#pragma warning restore CS8618

    public V1SimilarResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SimilarResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SimilarResponseFromRaw.FromRawUnchecked"/>
    public static V1SimilarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SimilarResponseFromRaw : IFromRawJson<V1SimilarResponse>
{
    /// <inheritdoc/>
    public V1SimilarResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SimilarResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SimilarSource, SimilarSourceFromRaw>))]
public sealed record class SimilarSource : JsonModel
{
    /// <summary>
    /// Publication date
    /// </summary>
    public string? PublishedDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publishedDate");
        }
        init { this._rawData.Set("publishedDate", value); }
    }

    /// <summary>
    /// Text excerpt from the document
    /// </summary>
    public string? Snippet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("snippet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("snippet", value);
        }
    }

    /// <summary>
    /// Domain of the source
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Title of the document
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <summary>
    /// URL of the similar source
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublishedDate;
        _ = this.Snippet;
        _ = this.Source;
        _ = this.Title;
        _ = this.Url;
    }

    public SimilarSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimilarSource(SimilarSource similarSource)
        : base(similarSource) { }
#pragma warning restore CS8618

    public SimilarSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SimilarSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SimilarSourceFromRaw.FromRawUnchecked"/>
    public static SimilarSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SimilarSourceFromRaw : IFromRawJson<SimilarSource>
{
    /// <inheritdoc/>
    public SimilarSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SimilarSource.FromRawUnchecked(rawData);
}
