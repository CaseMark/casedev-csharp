using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault.Graphrag;

[JsonConverter(
    typeof(JsonModelConverter<GraphragGetStatsResponse, GraphragGetStatsResponseFromRaw>)
)]
public sealed record class GraphragGetStatsResponse : JsonModel
{
    /// <summary>
    /// Number of entity communities identified
    /// </summary>
    public long? Communities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("communities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communities", value);
        }
    }

    /// <summary>
    /// Number of processed documents
    /// </summary>
    public long? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("documents", value);
        }
    }

    /// <summary>
    /// Total number of entities extracted from documents
    /// </summary>
    public long? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entities", value);
        }
    }

    /// <summary>
    /// Timestamp of last GraphRAG processing
    /// </summary>
    public DateTimeOffset? LastProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastProcessed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastProcessed", value);
        }
    }

    /// <summary>
    /// Total number of relationships between entities
    /// </summary>
    public long? Relationships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("relationships");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("relationships", value);
        }
    }

    /// <summary>
    /// Current processing status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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
        _ = this.Communities;
        _ = this.Documents;
        _ = this.Entities;
        _ = this.LastProcessed;
        _ = this.Relationships;
        this.Status?.Validate();
    }

    public GraphragGetStatsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GraphragGetStatsResponse(GraphragGetStatsResponse graphragGetStatsResponse)
        : base(graphragGetStatsResponse) { }
#pragma warning restore CS8618

    public GraphragGetStatsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphragGetStatsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GraphragGetStatsResponseFromRaw.FromRawUnchecked"/>
    public static GraphragGetStatsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GraphragGetStatsResponseFromRaw : IFromRawJson<GraphragGetStatsResponse>
{
    /// <inheritdoc/>
    public GraphragGetStatsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GraphragGetStatsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current processing status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Processing,
    Completed,
    Error,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "processing" => Status.Processing,
            "completed" => Status.Completed,
            "error" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Processing => "processing",
                Status.Completed => "completed",
                Status.Error => "error",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
