using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunGetStatusResponse, RunGetStatusResponseFromRaw>))]
public sealed record class RunGetStatusResponse : JsonModel
{
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

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completedAt");
        }
        init { this._rawData.Set("completedAt", value); }
    }

    /// <summary>
    /// Elapsed time in milliseconds
    /// </summary>
    public long? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("durationMs");
        }
        init { this._rawData.Set("durationMs", value); }
    }

    public System::DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    public ApiEnum<string, RunGetStatusResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RunGetStatusResponseStatus>>(
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
        _ = this.CompletedAt;
        _ = this.DurationMs;
        _ = this.StartedAt;
        this.Status?.Validate();
    }

    public RunGetStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunGetStatusResponse(RunGetStatusResponse runGetStatusResponse)
        : base(runGetStatusResponse) { }
#pragma warning restore CS8618

    public RunGetStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunGetStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunGetStatusResponseFromRaw.FromRawUnchecked"/>
    public static RunGetStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunGetStatusResponseFromRaw : IFromRawJson<RunGetStatusResponse>
{
    /// <inheritdoc/>
    public RunGetStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RunGetStatusResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RunGetStatusResponseStatusConverter))]
public enum RunGetStatusResponseStatus
{
    Queued,
    Running,
    Completed,
    Failed,
    Cancelled,
}

sealed class RunGetStatusResponseStatusConverter : JsonConverter<RunGetStatusResponseStatus>
{
    public override RunGetStatusResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => RunGetStatusResponseStatus.Queued,
            "running" => RunGetStatusResponseStatus.Running,
            "completed" => RunGetStatusResponseStatus.Completed,
            "failed" => RunGetStatusResponseStatus.Failed,
            "cancelled" => RunGetStatusResponseStatus.Cancelled,
            _ => (RunGetStatusResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RunGetStatusResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RunGetStatusResponseStatus.Queued => "queued",
                RunGetStatusResponseStatus.Running => "running",
                RunGetStatusResponseStatus.Completed => "completed",
                RunGetStatusResponseStatus.Failed => "failed",
                RunGetStatusResponseStatus.Cancelled => "cancelled",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
