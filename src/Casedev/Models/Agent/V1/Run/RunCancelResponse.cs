using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunCancelResponse, RunCancelResponseFromRaw>))]
public sealed record class RunCancelResponse : JsonModel
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

    /// <summary>
    /// Present if run was already finished
    /// </summary>
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

    public ApiEnum<string, RunCancelResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RunCancelResponseStatus>>(
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
        _ = this.Message;
        this.Status?.Validate();
    }

    public RunCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunCancelResponse(RunCancelResponse runCancelResponse)
        : base(runCancelResponse) { }
#pragma warning restore CS8618

    public RunCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunCancelResponseFromRaw.FromRawUnchecked"/>
    public static RunCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunCancelResponseFromRaw : IFromRawJson<RunCancelResponse>
{
    /// <inheritdoc/>
    public RunCancelResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunCancelResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RunCancelResponseStatusConverter))]
public enum RunCancelResponseStatus
{
    Cancelled,
    Completed,
    Failed,
}

sealed class RunCancelResponseStatusConverter : JsonConverter<RunCancelResponseStatus>
{
    public override RunCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cancelled" => RunCancelResponseStatus.Cancelled,
            "completed" => RunCancelResponseStatus.Completed,
            "failed" => RunCancelResponseStatus.Failed,
            _ => (RunCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RunCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RunCancelResponseStatus.Cancelled => "cancelled",
                RunCancelResponseStatus.Completed => "completed",
                RunCancelResponseStatus.Failed => "failed",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
