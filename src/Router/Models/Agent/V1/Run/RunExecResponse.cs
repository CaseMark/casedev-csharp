using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;
using System = System;

namespace Router.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunExecResponse, RunExecResponseFromRaw>))]
public sealed record class RunExecResponse : JsonModel
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

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public ApiEnum<string, RunExecResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RunExecResponseStatus>>("status");
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
    /// Durable workflow run ID
    /// </summary>
    public string? WorkflowID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflowId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workflowId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Message;
        this.Status?.Validate();
        _ = this.WorkflowID;
    }

    public RunExecResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunExecResponse(RunExecResponse runExecResponse)
        : base(runExecResponse) { }
#pragma warning restore CS8618

    public RunExecResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunExecResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunExecResponseFromRaw.FromRawUnchecked"/>
    public static RunExecResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunExecResponseFromRaw : IFromRawJson<RunExecResponse>
{
    /// <inheritdoc/>
    public RunExecResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunExecResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RunExecResponseStatusConverter))]
public enum RunExecResponseStatus
{
    Running,
}

sealed class RunExecResponseStatusConverter : JsonConverter<RunExecResponseStatus>
{
    public override RunExecResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => RunExecResponseStatus.Running,
            _ => (RunExecResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RunExecResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RunExecResponseStatus.Running => "running",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
