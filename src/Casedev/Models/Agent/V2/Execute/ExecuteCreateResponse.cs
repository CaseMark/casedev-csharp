using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Agent.V2.Execute;

[JsonConverter(typeof(JsonModelConverter<ExecuteCreateResponse, ExecuteCreateResponseFromRaw>))]
public sealed record class ExecuteCreateResponse : JsonModel
{
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

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public Logs? Logs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Logs>("logs");
        }
        init { this._rawData.Set("logs", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public string? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output");
        }
        init { this._rawData.Set("output", value); }
    }

    public ApiEnum<string, Provider>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    public string? RunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("runId", value);
        }
    }

    public string? RuntimeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runtimeId");
        }
        init { this._rawData.Set("runtimeId", value); }
    }

    public ApiEnum<string, RuntimeState>? RuntimeState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RuntimeState>>("runtimeState");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("runtimeState", value);
        }
    }

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

    public JsonElement? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        _ = this.Error;
        this.Logs?.Validate();
        _ = this.Message;
        _ = this.Output;
        this.Provider?.Validate();
        _ = this.RunID;
        _ = this.RuntimeID;
        this.RuntimeState?.Validate();
        this.Status?.Validate();
        _ = this.Usage;
    }

    public ExecuteCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecuteCreateResponse(ExecuteCreateResponse executeCreateResponse)
        : base(executeCreateResponse) { }
#pragma warning restore CS8618

    public ExecuteCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecuteCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecuteCreateResponseFromRaw.FromRawUnchecked"/>
    public static ExecuteCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecuteCreateResponseFromRaw : IFromRawJson<ExecuteCreateResponse>
{
    /// <inheritdoc/>
    public ExecuteCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecuteCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Logs, LogsFromRaw>))]
public sealed record class Logs : JsonModel
{
    public string? Linc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("linc");
        }
        init { this._rawData.Set("linc", value); }
    }

    public string? Runner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("runner");
        }
        init { this._rawData.Set("runner", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Linc;
        _ = this.Runner;
    }

    public Logs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Logs(Logs logs)
        : base(logs) { }
#pragma warning restore CS8618

    public Logs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LogsFromRaw.FromRawUnchecked"/>
    public static Logs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogsFromRaw : IFromRawJson<Logs>
{
    /// <inheritdoc/>
    public Logs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Logs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Daytona,
    Vercel,
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daytona" => Provider.Daytona,
            "vercel" => Provider.Vercel,
            _ => (Provider)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Provider value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Provider.Daytona => "daytona",
                Provider.Vercel => "vercel",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RuntimeStateConverter))]
public enum RuntimeState
{
    Running,
    Ended,
    Error,
}

sealed class RuntimeStateConverter : JsonConverter<RuntimeState>
{
    public override RuntimeState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => RuntimeState.Running,
            "ended" => RuntimeState.Ended,
            "error" => RuntimeState.Error,
            _ => (RuntimeState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RuntimeState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuntimeState.Running => "running",
                RuntimeState.Ended => "ended",
                RuntimeState.Error => "error",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Running,
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
            "running" => Status.Running,
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
                Status.Running => "running",
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
