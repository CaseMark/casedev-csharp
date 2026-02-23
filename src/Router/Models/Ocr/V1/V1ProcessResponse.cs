using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;
using System = System;

namespace Router.Models.Ocr.V1;

[JsonConverter(typeof(JsonModelConverter<V1ProcessResponse, V1ProcessResponseFromRaw>))]
public sealed record class V1ProcessResponse : JsonModel
{
    /// <summary>
    /// Unique job identifier
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
    /// Job creation timestamp
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
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

    /// <summary>
    /// Document identifier
    /// </summary>
    public string? DocumentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <summary>
    /// OCR engine used
    /// </summary>
    public string? Engine
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("engine");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("engine", value);
        }
    }

    /// <summary>
    /// Estimated completion time
    /// </summary>
    public System::DateTimeOffset? EstimatedCompletion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("estimated_completion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("estimated_completion", value);
        }
    }

    /// <summary>
    /// Number of pages detected
    /// </summary>
    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_count", value);
        }
    }

    /// <summary>
    /// Current job status
    /// </summary>
    public ApiEnum<string, V1ProcessResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, V1ProcessResponseStatus>>(
                "status"
            );
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
        _ = this.CreatedAt;
        _ = this.DocumentID;
        _ = this.Engine;
        _ = this.EstimatedCompletion;
        _ = this.PageCount;
        this.Status?.Validate();
    }

    public V1ProcessResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ProcessResponse(V1ProcessResponse v1ProcessResponse)
        : base(v1ProcessResponse) { }
#pragma warning restore CS8618

    public V1ProcessResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ProcessResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ProcessResponseFromRaw.FromRawUnchecked"/>
    public static V1ProcessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ProcessResponseFromRaw : IFromRawJson<V1ProcessResponse>
{
    /// <inheritdoc/>
    public V1ProcessResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ProcessResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job status
/// </summary>
[JsonConverter(typeof(V1ProcessResponseStatusConverter))]
public enum V1ProcessResponseStatus
{
    Queued,
    Processing,
    Completed,
    Failed,
}

sealed class V1ProcessResponseStatusConverter : JsonConverter<V1ProcessResponseStatus>
{
    public override V1ProcessResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => V1ProcessResponseStatus.Queued,
            "processing" => V1ProcessResponseStatus.Processing,
            "completed" => V1ProcessResponseStatus.Completed,
            "failed" => V1ProcessResponseStatus.Failed,
            _ => (V1ProcessResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1ProcessResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1ProcessResponseStatus.Queued => "queued",
                V1ProcessResponseStatus.Processing => "processing",
                V1ProcessResponseStatus.Completed => "completed",
                V1ProcessResponseStatus.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
