using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Skills.Custom;

[JsonConverter(typeof(JsonModelConverter<CustomListResponse, CustomListResponseFromRaw>))]
public sealed record class CustomListResponse : JsonModel
{
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    public IReadOnlyList<Skill>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Skill>>("skills");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Skill>?>(
                "skills",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
        foreach (var item in this.Skills ?? [])
        {
            item.Validate();
        }
    }

    public CustomListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomListResponse(CustomListResponse customListResponse)
        : base(customListResponse) { }
#pragma warning restore CS8618

    public CustomListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomListResponseFromRaw.FromRawUnchecked"/>
    public static CustomListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomListResponseFromRaw : IFromRawJson<CustomListResponse>
{
    /// <inheritdoc/>
    public CustomListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Skill, SkillFromRaw>))]
public sealed record class Skill : JsonModel
{
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

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

    public string? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

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

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public long? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Name;
        _ = this.Slug;
        _ = this.Summary;
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public Skill() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Skill(Skill skill)
        : base(skill) { }
#pragma warning restore CS8618

    public Skill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Skill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillFromRaw.FromRawUnchecked"/>
    public static Skill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillFromRaw : IFromRawJson<Skill>
{
    /// <inheritdoc/>
    public Skill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Skill.FromRawUnchecked(rawData);
}
