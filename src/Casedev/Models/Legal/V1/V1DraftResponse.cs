using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1DraftResponse, V1DraftResponseFromRaw>))]
public sealed record class V1DraftResponse : JsonModel
{
    /// <summary>
    /// Ephemeral agent ID
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agent_id", value);
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

    /// <summary>
    /// Run ID — poll /agent/v1/run/:id/status for progress
    /// </summary>
    public string? RunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("run_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("run_id", value);
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
        _ = this.RunID;
        this.Status?.Validate();
    }

    public V1DraftResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DraftResponse(V1DraftResponse v1DraftResponse)
        : base(v1DraftResponse) { }
#pragma warning restore CS8618

    public V1DraftResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DraftResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DraftResponseFromRaw.FromRawUnchecked"/>
    public static V1DraftResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DraftResponseFromRaw : IFromRawJson<V1DraftResponse>
{
    /// <inheritdoc/>
    public V1DraftResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DraftResponse.FromRawUnchecked(rawData);
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
        System::Type typeToConvert,
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
