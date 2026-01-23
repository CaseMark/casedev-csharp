using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Search.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1RetrieveResearchResponse, V1RetrieveResearchResponseFromRaw>)
)]
public sealed record class V1RetrieveResearchResponse : JsonModel
{
    /// <summary>
    /// Research task ID
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Task completion timestamp
    /// </summary>
    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completedAt", value);
        }
    }

    /// <summary>
    /// Task creation timestamp
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Research model used
    /// </summary>
    public ApiEnum<string, V1RetrieveResearchResponseModel>? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, V1RetrieveResearchResponseModel>>(
                "model"
            );
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
    /// Completion percentage (0-100)
    /// </summary>
    public double? Progress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("progress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("progress", value);
        }
    }

    /// <summary>
    /// Original research query
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <summary>
    /// Research findings and analysis
    /// </summary>
    public Results? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Results>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("results", value);
        }
    }

    /// <summary>
    /// Current status of the research task
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        this.Model?.Validate();
        _ = this.Progress;
        _ = this.Query;
        this.Results?.Validate();
        this.Status?.Validate();
    }

    public V1RetrieveResearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1RetrieveResearchResponse(V1RetrieveResearchResponse v1RetrieveResearchResponse)
        : base(v1RetrieveResearchResponse) { }
#pragma warning restore CS8618

    public V1RetrieveResearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1RetrieveResearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1RetrieveResearchResponseFromRaw.FromRawUnchecked"/>
    public static V1RetrieveResearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1RetrieveResearchResponseFromRaw : IFromRawJson<V1RetrieveResearchResponse>
{
    /// <inheritdoc/>
    public V1RetrieveResearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1RetrieveResearchResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Research model used
/// </summary>
[JsonConverter(typeof(V1RetrieveResearchResponseModelConverter))]
public enum V1RetrieveResearchResponseModel
{
    Fast,
    Normal,
    Pro,
}

sealed class V1RetrieveResearchResponseModelConverter
    : JsonConverter<V1RetrieveResearchResponseModel>
{
    public override V1RetrieveResearchResponseModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => V1RetrieveResearchResponseModel.Fast,
            "normal" => V1RetrieveResearchResponseModel.Normal,
            "pro" => V1RetrieveResearchResponseModel.Pro,
            _ => (V1RetrieveResearchResponseModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1RetrieveResearchResponseModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1RetrieveResearchResponseModel.Fast => "fast",
                V1RetrieveResearchResponseModel.Normal => "normal",
                V1RetrieveResearchResponseModel.Pro => "pro",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Research findings and analysis
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Results, ResultsFromRaw>))]
public sealed record class Results : JsonModel
{
    /// <summary>
    /// Detailed research sections
    /// </summary>
    public IReadOnlyList<Section>? Sections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Section>>("sections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Section>?>(
                "sections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// All sources referenced in research
    /// </summary>
    public IReadOnlyList<ResultsSource>? Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ResultsSource>>("sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ResultsSource>?>(
                "sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Executive summary of research findings
    /// </summary>
    public string? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("summary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("summary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Sections ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Sources ?? [])
        {
            item.Validate();
        }
        _ = this.Summary;
    }

    public Results() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Results(Results results)
        : base(results) { }
#pragma warning restore CS8618

    public Results(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Results(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultsFromRaw.FromRawUnchecked"/>
    public static Results FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultsFromRaw : IFromRawJson<Results>
{
    /// <inheritdoc/>
    public Results FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Results.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Section, SectionFromRaw>))]
public sealed record class Section : JsonModel
{
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public IReadOnlyList<Source>? Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Source>>("sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Source>?>(
                "sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        foreach (var item in this.Sources ?? [])
        {
            item.Validate();
        }
        _ = this.Title;
    }

    public Section() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Section(Section section)
        : base(section) { }
#pragma warning restore CS8618

    public Section(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Section(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SectionFromRaw.FromRawUnchecked"/>
    public static Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SectionFromRaw : IFromRawJson<Section>
{
    /// <inheritdoc/>
    public Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Section.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
{
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
        _ = this.Snippet;
        _ = this.Title;
        _ = this.Url;
    }

    public Source() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source(Source source)
        : base(source) { }
#pragma warning restore CS8618

    public Source(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Source(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Source.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ResultsSource, ResultsSourceFromRaw>))]
public sealed record class ResultsSource : JsonModel
{
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
        _ = this.Snippet;
        _ = this.Title;
        _ = this.Url;
    }

    public ResultsSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultsSource(ResultsSource resultsSource)
        : base(resultsSource) { }
#pragma warning restore CS8618

    public ResultsSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultsSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultsSourceFromRaw.FromRawUnchecked"/>
    public static ResultsSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultsSourceFromRaw : IFromRawJson<ResultsSource>
{
    /// <inheritdoc/>
    public ResultsSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResultsSource.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the research task
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Running,
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "running" => Status.Running,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Running => "running",
                Status.Completed => "completed",
                Status.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
