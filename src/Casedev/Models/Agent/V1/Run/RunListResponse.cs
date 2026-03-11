using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunListResponse, RunListResponseFromRaw>))]
public sealed record class RunListResponse : JsonModel
{
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasMore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasMore", value);
        }
    }

    /// <summary>
    /// Pass as cursor to fetch the next page
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    public IReadOnlyList<RunListResponseRun>? Runs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RunListResponseRun>>("runs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RunListResponseRun>?>(
                "runs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
        foreach (var item in this.Runs ?? [])
        {
            item.Validate();
        }
    }

    public RunListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunListResponse(RunListResponse runListResponse)
        : base(runListResponse) { }
#pragma warning restore CS8618

    public RunListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunListResponseFromRaw.FromRawUnchecked"/>
    public static RunListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunListResponseFromRaw : IFromRawJson<RunListResponse>
{
    /// <inheritdoc/>
    public RunListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RunListResponseRun, RunListResponseRunFromRaw>))]
public sealed record class RunListResponseRun : JsonModel
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

    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agentId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agentId", value);
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

    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
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

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Truncated to first 200 characters
    /// </summary>
    public string? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt", value);
        }
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

    public ApiEnum<string, RunListResponseRunStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RunListResponseRunStatus>>(
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
        _ = this.AgentID;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.Model;
        _ = this.Prompt;
        _ = this.StartedAt;
        this.Status?.Validate();
    }

    public RunListResponseRun() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunListResponseRun(RunListResponseRun runListResponseRun)
        : base(runListResponseRun) { }
#pragma warning restore CS8618

    public RunListResponseRun(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunListResponseRun(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunListResponseRunFromRaw.FromRawUnchecked"/>
    public static RunListResponseRun FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunListResponseRunFromRaw : IFromRawJson<RunListResponseRun>
{
    /// <inheritdoc/>
    public RunListResponseRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunListResponseRun.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RunListResponseRunStatusConverter))]
public enum RunListResponseRunStatus
{
    Queued,
    Running,
    Completed,
    Failed,
    Cancelled,
}

sealed class RunListResponseRunStatusConverter : JsonConverter<RunListResponseRunStatus>
{
    public override RunListResponseRunStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => RunListResponseRunStatus.Queued,
            "running" => RunListResponseRunStatus.Running,
            "completed" => RunListResponseRunStatus.Completed,
            "failed" => RunListResponseRunStatus.Failed,
            "cancelled" => RunListResponseRunStatus.Cancelled,
            _ => (RunListResponseRunStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RunListResponseRunStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RunListResponseRunStatus.Queued => "queued",
                RunListResponseRunStatus.Running => "running",
                RunListResponseRunStatus.Completed => "completed",
                RunListResponseRunStatus.Failed => "failed",
                RunListResponseRunStatus.Cancelled => "cancelled",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
