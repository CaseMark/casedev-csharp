using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Voice.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListVoicesResponse, V1ListVoicesResponseFromRaw>))]
public sealed record class V1ListVoicesResponse : JsonModel
{
    /// <summary>
    /// Token for next page of results
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_page_token", value);
        }
    }

    /// <summary>
    /// Total number of voices (if requested)
    /// </summary>
    public long? TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_count", value);
        }
    }

    public IReadOnlyList<V1ListVoicesResponseVoice>? Voices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1ListVoicesResponseVoice>>(
                "voices"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1ListVoicesResponseVoice>?>(
                "voices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextPageToken;
        _ = this.TotalCount;
        foreach (var item in this.Voices ?? [])
        {
            item.Validate();
        }
    }

    public V1ListVoicesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListVoicesResponse(V1ListVoicesResponse v1ListVoicesResponse)
        : base(v1ListVoicesResponse) { }
#pragma warning restore CS8618

    public V1ListVoicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListVoicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListVoicesResponseFromRaw.FromRawUnchecked"/>
    public static V1ListVoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListVoicesResponseFromRaw : IFromRawJson<V1ListVoicesResponse>
{
    /// <inheritdoc/>
    public V1ListVoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListVoicesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<V1ListVoicesResponseVoice, V1ListVoicesResponseVoiceFromRaw>)
)]
public sealed record class V1ListVoicesResponseVoice : JsonModel
{
    /// <summary>
    /// Available subscription tiers
    /// </summary>
    public IReadOnlyList<string>? AvailableForTiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("available_for_tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "available_for_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Voice category
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// Voice description
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
    /// Voice characteristics and metadata
    /// </summary>
    public JsonElement? Labels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("labels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("labels", value);
        }
    }

    /// <summary>
    /// Voice name
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
    /// URL to preview audio sample
    /// </summary>
    public string? PreviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preview_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preview_url", value);
        }
    }

    /// <summary>
    /// Unique voice identifier
    /// </summary>
    public string? VoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voice_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voice_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvailableForTiers;
        _ = this.Category;
        _ = this.Description;
        _ = this.Labels;
        _ = this.Name;
        _ = this.PreviewUrl;
        _ = this.VoiceID;
    }

    public V1ListVoicesResponseVoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListVoicesResponseVoice(V1ListVoicesResponseVoice v1ListVoicesResponseVoice)
        : base(v1ListVoicesResponseVoice) { }
#pragma warning restore CS8618

    public V1ListVoicesResponseVoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListVoicesResponseVoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListVoicesResponseVoiceFromRaw.FromRawUnchecked"/>
    public static V1ListVoicesResponseVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListVoicesResponseVoiceFromRaw : IFromRawJson<V1ListVoicesResponseVoice>
{
    /// <inheritdoc/>
    public V1ListVoicesResponseVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListVoicesResponseVoice.FromRawUnchecked(rawData);
}
