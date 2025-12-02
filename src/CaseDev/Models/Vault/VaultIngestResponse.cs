using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(ModelConverter<VaultIngestResponse, VaultIngestResponseFromRaw>))]
public sealed record class VaultIngestResponse : ModelBase
{
    /// <summary>
    /// Whether GraphRAG is enabled for this vault
    /// </summary>
    public required bool EnableGraphRag
    {
        get
        {
            if (!this._rawData.TryGetValue("enableGraphRAG", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'enableGraphRAG' cannot be null",
                    new ArgumentOutOfRangeException("enableGraphRAG", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["enableGraphRAG"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Human-readable status message
    /// </summary>
    public required string Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
                );
        }
        init
        {
            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ID of the vault object being processed
    /// </summary>
    public required string ObjectID
    {
        get
        {
            if (!this._rawData.TryGetValue("objectId", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'objectId' cannot be null",
                    new ArgumentOutOfRangeException("objectId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'objectId' cannot be null",
                    new ArgumentNullException("objectId")
                );
        }
        init
        {
            this._rawData["objectId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current ingestion status
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CasedevInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentNullException("status")
                );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Workflow run ID for tracking progress
    /// </summary>
    public required string WorkflowID
    {
        get
        {
            if (!this._rawData.TryGetValue("workflowId", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'workflowId' cannot be null",
                    new ArgumentOutOfRangeException("workflowId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'workflowId' cannot be null",
                    new ArgumentNullException("workflowId")
                );
        }
        init
        {
            this._rawData["workflowId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EnableGraphRag;
        _ = this.Message;
        _ = this.ObjectID;
        this.Status.Validate();
        _ = this.WorkflowID;
    }

    public VaultIngestResponse() { }

    public VaultIngestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultIngestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static VaultIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultIngestResponseFromRaw : IFromRaw<VaultIngestResponse>
{
    public VaultIngestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultIngestResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current ingestion status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Processing,
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
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
