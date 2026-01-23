using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Format.V1.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateListResponse, TemplateListResponseFromRaw>))]
public sealed record class TemplateListResponse : JsonModel
{
    public IReadOnlyList<Template>? Templates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Template>>("templates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Template>?>(
                "templates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Templates ?? [])
        {
            item.Validate();
        }
    }

    public TemplateListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateListResponse(TemplateListResponse templateListResponse)
        : base(templateListResponse) { }
#pragma warning restore CS8618

    public TemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateListResponseFromRaw.FromRawUnchecked"/>
    public static TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateListResponseFromRaw : IFromRawJson<TemplateListResponse>
{
    /// <inheritdoc/>
    public TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Unique template identifier
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
    /// Template creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
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
    /// Template description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Template name
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
    /// Template tags for organization
    /// </summary>
    public IReadOnlyList<JsonElement>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template type/category
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Number of times template has been used
    /// </summary>
    public long? UsageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("usageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usageCount", value);
        }
    }

    /// <summary>
    /// Template variables for customization
    /// </summary>
    public IReadOnlyList<JsonElement>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.Tags;
        _ = this.Type;
        _ = this.UsageCount;
        _ = this.Variables;
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}
