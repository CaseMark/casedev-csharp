using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault.Objects;

[JsonConverter(
    typeof(JsonModelConverter<ObjectGetSummarizeJobResponse, ObjectGetSummarizeJobResponseFromRaw>)
)]
public sealed record class ObjectGetSummarizeJobResponse : JsonModel
{
    /// <summary>
    /// When the job completed
    /// </summary>
    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init { this._rawData.Set("completedAt", value); }
    }

    /// <summary>
    /// When the job was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Error message (if failed)
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Case.dev job ID
    /// </summary>
    public string? JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jobId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jobId", value);
        }
    }

    /// <summary>
    /// Filename of the result document (if completed)
    /// </summary>
    public string? ResultFilename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resultFilename");
        }
        init { this._rawData.Set("resultFilename", value); }
    }

    /// <summary>
    /// ID of the result document (if completed)
    /// </summary>
    public string? ResultObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resultObjectId");
        }
        init { this._rawData.Set("resultObjectId", value); }
    }

    /// <summary>
    /// ID of the source document
    /// </summary>
    public string? SourceObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceObjectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceObjectId", value);
        }
    }

    /// <summary>
    /// Current job status
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

    /// <summary>
    /// Type of workflow being executed
    /// </summary>
    public string? WorkflowType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.Error;
        _ = this.JobID;
        _ = this.ResultFilename;
        _ = this.ResultObjectID;
        _ = this.SourceObjectID;
        this.Status?.Validate();
        _ = this.WorkflowType;
    }

    public ObjectGetSummarizeJobResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetSummarizeJobResponse(
        ObjectGetSummarizeJobResponse objectGetSummarizeJobResponse
    )
        : base(objectGetSummarizeJobResponse) { }
#pragma warning restore CS8618

    public ObjectGetSummarizeJobResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetSummarizeJobResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetSummarizeJobResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGetSummarizeJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetSummarizeJobResponseFromRaw : IFromRawJson<ObjectGetSummarizeJobResponse>
{
    /// <inheritdoc/>
    public ObjectGetSummarizeJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetSummarizeJobResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Processing,
    Completed,
    Failed,
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
            "pending" => Status.Pending,
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
                Status.Pending => "pending",
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
