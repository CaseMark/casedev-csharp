using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Search.V1;

[JsonConverter(typeof(ModelConverter<V1ContentsResponse, V1ContentsResponseFromRaw>))]
public sealed record class V1ContentsResponse : ModelBase
{
    public IReadOnlyList<Result>? Results
    {
        get { return ModelBase.GetNullableClass<List<Result>>(this.RawData, "results"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public V1ContentsResponse() { }

    public V1ContentsResponse(V1ContentsResponse v1ContentsResponse)
        : base(v1ContentsResponse) { }

    public V1ContentsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ContentsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ContentsResponseFromRaw.FromRawUnchecked"/>
    public static V1ContentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ContentsResponseFromRaw : IFromRaw<V1ContentsResponse>
{
    /// <inheritdoc/>
    public V1ContentsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ContentsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : ModelBase
{
    /// <summary>
    /// Content highlights if requested
    /// </summary>
    public IReadOnlyList<string>? Highlights
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "highlights"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "highlights", value);
        }
    }

    /// <summary>
    /// Additional metadata about the content
    /// </summary>
    public JsonElement? Metadata
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "metadata", value);
        }
    }

    /// <summary>
    /// Content summary if requested
    /// </summary>
    public string? Summary
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "summary"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "summary", value);
        }
    }

    /// <summary>
    /// Extracted text content
    /// </summary>
    public string? Text
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "text", value);
        }
    }

    /// <summary>
    /// Page title
    /// </summary>
    public string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "title", value);
        }
    }

    /// <summary>
    /// Source URL
    /// </summary>
    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Highlights;
        _ = this.Metadata;
        _ = this.Summary;
        _ = this.Text;
        _ = this.Title;
        _ = this.URL;
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
