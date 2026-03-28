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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        _ = this.Message;
        this.Provider?.Validate();
        _ = this.RunID;
        this.RuntimeState?.Validate();
        this.Status?.Validate();
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

[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Daytona,
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
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
