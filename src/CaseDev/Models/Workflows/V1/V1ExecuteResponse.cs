using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Workflows.V1;

[JsonConverter(typeof(ModelConverter<V1ExecuteResponse, V1ExecuteResponseFromRaw>))]
public sealed record class V1ExecuteResponse : ModelBase
{
    public long? Duration
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration", value);
        }
    }

    public string? Error
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "error"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "error", value);
        }
    }

    public string? ExecutionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "executionId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "executionId", value);
        }
    }

    public JsonElement? Outputs
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "outputs"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "outputs", value);
        }
    }

    public ApiEnum<string, V1ExecuteResponseStatus>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, V1ExecuteResponseStatus>>(
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

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Error;
        _ = this.ExecutionID;
        _ = this.Outputs;
        this.Status?.Validate();
    }

    public V1ExecuteResponse() { }

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

class V1ExecuteResponseFromRaw : IFromRaw<V1ExecuteResponse>
{
    /// <inheritdoc/>
    public V1ExecuteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ExecuteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(V1ExecuteResponseStatusConverter))]
public enum V1ExecuteResponseStatus
{
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
