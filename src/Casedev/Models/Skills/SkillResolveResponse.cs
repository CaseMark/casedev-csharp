using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillResolveResponse, SkillResolveResponseFromRaw>))]
public sealed record class SkillResolveResponse : JsonModel
{
    /// <summary>
    /// Search methods used (text, tag, semantic)
    /// </summary>
    public IReadOnlyList<string>? MethodsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("methods_used");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "methods_used",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Result>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MethodsUsed;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public SkillResolveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillResolveResponse(SkillResolveResponse skillResolveResponse)
        : base(skillResolveResponse) { }
#pragma warning restore CS8618

    public SkillResolveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillResolveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillResolveResponseFromRaw.FromRawUnchecked"/>
    public static SkillResolveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillResolveResponseFromRaw : IFromRawJson<SkillResolveResponse>
{
    /// <inheritdoc/>
    public SkillResolveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SkillResolveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Skill name
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

    /// <summary>
    /// Relevance score
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Unique skill identifier
    /// </summary>
    public string? Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slug");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    /// <summary>
    /// Brief skill description
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

    /// <summary>
    /// Skill tags
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Score;
        _ = this.Slug;
        _ = this.Summary;
        _ = this.Tags;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
