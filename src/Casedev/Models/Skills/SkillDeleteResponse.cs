using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillDeleteResponse, SkillDeleteResponseFromRaw>))]
public sealed record class SkillDeleteResponse : JsonModel
{
    public bool? Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("deleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deleted", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deleted;
        _ = this.Slug;
    }

    public SkillDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillDeleteResponse(SkillDeleteResponse skillDeleteResponse)
        : base(skillDeleteResponse) { }
#pragma warning restore CS8618

    public SkillDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SkillDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillDeleteResponseFromRaw : IFromRawJson<SkillDeleteResponse>
{
    /// <inheritdoc/>
    public SkillDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillDeleteResponse.FromRawUnchecked(rawData);
}
