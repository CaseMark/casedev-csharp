using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Format.V1.Templates;

[JsonConverter(typeof(ModelConverter<TemplateCreateResponse, TemplateCreateResponseFromRaw>))]
public sealed record class TemplateCreateResponse : ModelBase
{
    /// <summary>
    /// Template ID
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Template name
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Template type
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Detected template variables
    /// </summary>
    public IReadOnlyList<string>? Variables
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "variables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "variables", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.Type;
        _ = this.Variables;
    }

    public TemplateCreateResponse() { }

    public TemplateCreateResponse(TemplateCreateResponse templateCreateResponse)
        : base(templateCreateResponse) { }

    public TemplateCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateCreateResponseFromRaw.FromRawUnchecked"/>
    public static TemplateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateCreateResponseFromRaw : IFromRaw<TemplateCreateResponse>
{
    /// <inheritdoc/>
    public TemplateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateCreateResponse.FromRawUnchecked(rawData);
}
