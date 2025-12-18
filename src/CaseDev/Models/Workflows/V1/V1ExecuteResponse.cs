using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(JsonModelConverter<V1ExecuteResponse, V1ExecuteResponseFromRaw>))]
public sealed record class V1ExecuteResponse : JsonModel
{
    public long? Duration
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "duration", value);
        }
    }

    public string? ExecutionArn
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "executionArn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "executionArn", value);
        }
    }

    public string? ExecutionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "executionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "executionId", value);
        }
    }

    public ApiEnum<string, Mode>? Mode
    {
        get { return JsonModel.GetNullableClass<ApiEnum<string, Mode>>(this.RawData, "mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "mode", value);
        }
    }

    public JsonElement? Output
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "output"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "output", value);
        }
    }

    public ApiEnum<string, V1ExecuteResponseStatus>? Status
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, V1ExecuteResponseStatus>>(
                this.RawData,
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        _ = this.ExecutionArn;
        _ = this.ExecutionID;
        this.Mode?.Validate();
        _ = this.Output;
        this.Status?.Validate();
    }

    public V1ExecuteResponse() { }

    public V1ExecuteResponse(V1ExecuteResponse v1ExecuteResponse)
        : base(v1ExecuteResponse) { }

    public V1ExecuteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ExecuteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ExecuteResponseFromRaw.FromRawUnchecked"/>
    public static V1ExecuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ExecuteResponseFromRaw : IFromRawJson<V1ExecuteResponse>
{
    /// <inheritdoc/>
    public V1ExecuteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ExecuteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    FireAndForget,
    Callback,
    Sync,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fire-and-forget" => Mode.FireAndForget,
            "callback" => Mode.Callback,
            "sync" => Mode.Sync,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.FireAndForget => "fire-and-forget",
                Mode.Callback => "callback",
                Mode.Sync => "sync",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(V1ExecuteResponseStatusConverter))]
public enum V1ExecuteResponseStatus
{
    Running,
    Completed,
    Failed,
}

sealed class V1ExecuteResponseStatusConverter : JsonConverter<V1ExecuteResponseStatus>
{
    public override V1ExecuteResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => V1ExecuteResponseStatus.Running,
            "completed" => V1ExecuteResponseStatus.Completed,
            "failed" => V1ExecuteResponseStatus.Failed,
            _ => (V1ExecuteResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1ExecuteResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1ExecuteResponseStatus.Running => "running",
                V1ExecuteResponseStatus.Completed => "completed",
                V1ExecuteResponseStatus.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
