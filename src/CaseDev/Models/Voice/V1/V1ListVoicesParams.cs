using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Voice.V1;

/// <summary>
/// Retrieve a list of available voices for text-to-speech synthesis. This endpoint
/// provides access to a comprehensive catalog of voices with various characteristics,
/// languages, and styles suitable for legal document narration, client presentations,
/// and accessibility purposes.
/// </summary>
public sealed record class V1ListVoicesParams : ParamsBase
{
    /// <summary>
    /// Filter by voice category
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    /// <summary>
    /// Filter by voice collection ID
    /// </summary>
    public string? CollectionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("collection_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("collection_id", value);
        }
    }

    /// <summary>
    /// Whether to include total count in response
    /// </summary>
    public bool? IncludeTotalCount
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_total_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_total_count", value);
        }
    }

    /// <summary>
    /// Token for retrieving the next page of results
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("next_page_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("next_page_token", value);
        }
    }

    /// <summary>
    /// Number of voices to return per page (max 100)
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Search term to filter voices by name or description
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search", value);
        }
    }

    /// <summary>
    /// Field to sort by
    /// </summary>
    public ApiEnum<string, Sort>? Sort
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>("sort");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    /// <summary>
    /// Sort direction
    /// </summary>
    public ApiEnum<string, SortDirection>? SortDirection
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortDirection>>(
                "sort_direction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort_direction", value);
        }
    }

    /// <summary>
    /// Filter by voice type
    /// </summary>
    public ApiEnum<string, VoiceType>? VoiceType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, VoiceType>>("voice_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("voice_type", value);
        }
    }

    public V1ListVoicesParams() { }

    public V1ListVoicesParams(V1ListVoicesParams v1ListVoicesParams)
        : base(v1ListVoicesParams) { }

    public V1ListVoicesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListVoicesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static V1ListVoicesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/voice/v1/voices")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Field to sort by
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    Name,
    CreatedAt,
    UpdatedAt,
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "name" => Sort.Name,
            "created_at" => Sort.CreatedAt,
            "updated_at" => Sort.UpdatedAt,
            _ => (Sort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sort.Name => "name",
                Sort.CreatedAt => "created_at",
                Sort.UpdatedAt => "updated_at",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort direction
/// </summary>
[JsonConverter(typeof(SortDirectionConverter))]
public enum SortDirection
{
    Asc,
    Desc,
}

sealed class SortDirectionConverter : JsonConverter<SortDirection>
{
    public override SortDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => SortDirection.Asc,
            "desc" => SortDirection.Desc,
            _ => (SortDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortDirection.Asc => "asc",
                SortDirection.Desc => "desc",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by voice type
/// </summary>
[JsonConverter(typeof(VoiceTypeConverter))]
public enum VoiceType
{
    Premade,
    Cloned,
    Professional,
}

sealed class VoiceTypeConverter : JsonConverter<VoiceType>
{
    public override VoiceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "premade" => VoiceType.Premade,
            "cloned" => VoiceType.Cloned,
            "professional" => VoiceType.Professional,
            _ => (VoiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoiceType.Premade => "premade",
                VoiceType.Cloned => "cloned",
                VoiceType.Professional => "professional",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
