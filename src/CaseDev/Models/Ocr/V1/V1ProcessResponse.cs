using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Ocr.V1;

[JsonConverter(typeof(JsonModelConverter<V1ProcessResponse, V1ProcessResponseFromRaw>))]
public sealed record class V1ProcessResponse : JsonModel
{
    /// <summary>
    /// Unique job identifier
    /// </summary>
    public string? ID
    {
        get { return this._rawData.GetNullableClass<string>("id"); }
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
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at"); }
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
        get { return this._rawData.GetNullableClass<string>("document_id"); }
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
        get { return this._rawData.GetNullableClass<string>("engine"); }
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
        get { return this._rawData.GetNullableStruct<long>("page_count"); }
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
    public ApiEnum<string, Status>? Status
    {
        get { return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status"); }
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

    public V1ProcessResponse(V1ProcessResponse v1ProcessResponse)
        : base(v1ProcessResponse) { }

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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    Processing,
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => Status.Queued,
            "processing" => Status.Processing,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Queued => "queued",
                Status.Processing => "processing",
                Status.Completed => "completed",
                Status.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
