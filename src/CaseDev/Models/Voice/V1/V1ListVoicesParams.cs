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
            if (!this._rawQueryData.TryGetValue("category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["category"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by voice collection ID
    /// </summary>
    public string? CollectionID
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("collection_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["collection_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to include total count in response
    /// </summary>
    public bool? IncludeTotalCount
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("include_total_count", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["include_total_count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Token for retrieving the next page of results
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("next_page_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["next_page_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of voices to return per page (max 100)
    /// </summary>
    public long? PageSize
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("page_size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["page_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Search term to filter voices by name or description
    /// </summary>
    public string? Search
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("search", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["search"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Field to sort by
    /// </summary>
    public ApiEnum<string, Sort>? Sort
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("sort", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Sort>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["sort"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sort direction
    /// </summary>
    public ApiEnum<string, SortDirection>? SortDirection
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("sort_direction", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, SortDirection>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["sort_direction"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by voice type
    /// </summary>
    public ApiEnum<string, VoiceType>? VoiceType
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("voice_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, VoiceType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["voice_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1ListVoicesParams() { }

    public V1ListVoicesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListVoicesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

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
