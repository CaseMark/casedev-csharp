using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillReadResponse, SkillReadResponseFromRaw>))]
public sealed record class SkillReadResponse : JsonModel
{
    /// <summary>
    /// Skill author
    /// </summary>
    public string? AuthorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author_name", value);
        }
    }

    /// <summary>
    /// Full skill content in markdown
    /// </summary>
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

    /// <summary>
    /// Skill license
    /// </summary>
    public string? License
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("license", value);
        }
    }

    /// <summary>
    /// Custom metadata (custom skills only)
    /// </summary>
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
    /// Skill source (authenticated requests only)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
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

    /// <summary>
    /// Skill version
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
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
        _ = this.AuthorName;
        _ = this.Content;
        _ = this.License;
        _ = this.Metadata;
        _ = this.Name;
        _ = this.Slug;
        this.Source?.Validate();
        _ = this.Summary;
        _ = this.Tags;
        _ = this.Version;
    }

    public SkillReadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillReadResponse(SkillReadResponse skillReadResponse)
        : base(skillReadResponse) { }
#pragma warning restore CS8618

    public SkillReadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillReadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillReadResponseFromRaw.FromRawUnchecked"/>
    public static SkillReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillReadResponseFromRaw : IFromRawJson<SkillReadResponse>
{
    /// <inheritdoc/>
    public SkillReadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillReadResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Skill source (authenticated requests only)
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Curated,
    Custom,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "curated" => Source.Curated,
            "custom" => Source.Custom,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Curated => "curated",
                Source.Custom => "custom",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
