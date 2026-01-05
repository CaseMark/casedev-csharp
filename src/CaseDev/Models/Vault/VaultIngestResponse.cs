using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

[JsonConverter(typeof(JsonModelConverter<VaultIngestResponse, VaultIngestResponseFromRaw>))]
public sealed record class VaultIngestResponse : JsonModel
{
    /// <summary>
    /// Always false - GraphRAG must be triggered separately via POST /vault/:id/graphrag/:objectId
    /// </summary>
    public required bool EnableGraphRag
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "enableGraphRAG"); }
        init { JsonModel.Set(this._rawData, "enableGraphRAG", value); }
    }

    /// <summary>
    /// Human-readable status message
    /// </summary>
    public required string Message
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "message"); }
        init { JsonModel.Set(this._rawData, "message", value); }
    }

    /// <summary>
    /// ID of the vault object being processed
    /// </summary>
    public required string ObjectID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "objectId"); }
        init { JsonModel.Set(this._rawData, "objectId", value); }
    }

    /// <summary>
    /// Current ingestion status
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// Workflow run ID for tracking progress
    /// </summary>
    public required string WorkflowID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "workflowId"); }
        init { JsonModel.Set(this._rawData, "workflowId", value); }
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

    public VaultIngestResponse(VaultIngestResponse vaultIngestResponse)
        : base(vaultIngestResponse) { }

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
