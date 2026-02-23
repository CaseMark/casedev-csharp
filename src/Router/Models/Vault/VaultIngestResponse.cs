using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultIngestResponse, VaultIngestResponseFromRaw>))]
public sealed record class VaultIngestResponse : JsonModel
{
    /// <summary>
    /// Always false - GraphRAG must be triggered separately via POST /vault/:id/graphrag/:objectId
    /// </summary>
    public required bool EnableGraphRag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enableGraphRAG");
        }
        init { this._rawData.Set("enableGraphRAG", value); }
    }

    /// <summary>
    /// Human-readable status message
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// ID of the vault object being processed
    /// </summary>
    public required string ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("objectId");
        }
        init { this._rawData.Set("objectId", value); }
    }

    /// <summary>
    /// Current ingestion status. 'stored' for file types without text extraction
    /// (no chunks/vectors created).
    /// </summary>
    public required ApiEnum<string, VaultIngestResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VaultIngestResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Workflow run ID for tracking progress. Null for file types that skip processing.
    /// </summary>
    public required string? WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowId");
        }
        init { this._rawData.Set("workflowId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableGraphRag;
        _ = this.Message;
        _ = this.ObjectID;
        this.Status.Validate();
        _ = this.WorkflowID;
    }

    public VaultIngestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultIngestResponse(VaultIngestResponse vaultIngestResponse)
        : base(vaultIngestResponse) { }
#pragma warning restore CS8618

    public VaultIngestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultIngestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultIngestResponseFromRaw.FromRawUnchecked"/>
    public static VaultIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultIngestResponseFromRaw : IFromRawJson<VaultIngestResponse>
{
    /// <inheritdoc/>
    public VaultIngestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VaultIngestResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current ingestion status. 'stored' for file types without text extraction (no
/// chunks/vectors created).
/// </summary>
[JsonConverter(typeof(VaultIngestResponseStatusConverter))]
public enum VaultIngestResponseStatus
{
    Processing,
    Stored,
}

sealed class VaultIngestResponseStatusConverter : JsonConverter<VaultIngestResponseStatus>
{
    public override VaultIngestResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "processing" => VaultIngestResponseStatus.Processing,
            "stored" => VaultIngestResponseStatus.Stored,
            _ => (VaultIngestResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VaultIngestResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VaultIngestResponseStatus.Processing => "processing",
                VaultIngestResponseStatus.Stored => "stored",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
