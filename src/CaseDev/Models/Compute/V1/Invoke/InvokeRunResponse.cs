using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Compute.V1.Invoke;

[JsonConverter(typeof(InvokeRunResponseConverter))]
public record class InvokeRunResponse
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? RunID
    {
        get { return Match<string?>(synchronous: (x) => x.RunID, asynchronous: (x) => x.RunID); }
    }

    public InvokeRunResponse(SynchronousResponse value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvokeRunResponse(AsynchronousResponse value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvokeRunResponse(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickSynchronous([NotNullWhen(true)] out SynchronousResponse? value)
    {
        value = this.Value as SynchronousResponse;
        return value != null;
    }

    public bool TryPickAsynchronous([NotNullWhen(true)] out AsynchronousResponse? value)
    {
        value = this.Value as AsynchronousResponse;
        return value != null;
    }

    public void Switch(
        System::Action<SynchronousResponse> synchronous,
        System::Action<AsynchronousResponse> asynchronous
    )
    {
        switch (this.Value)
        {
            case SynchronousResponse value:
                synchronous(value);
                break;
            case AsynchronousResponse value:
                asynchronous(value);
                break;
            default:
                throw new CasedevInvalidDataException(
                    "Data did not match any variant of InvokeRunResponse"
                );
        }
    }

    public T Match<T>(
        System::Func<SynchronousResponse, T> synchronous,
        System::Func<AsynchronousResponse, T> asynchronous
    )
    {
        return this.Value switch
        {
            SynchronousResponse value => synchronous(value),
            AsynchronousResponse value => asynchronous(value),
            _ => throw new CasedevInvalidDataException(
                "Data did not match any variant of InvokeRunResponse"
            ),
        };
    }

    public static implicit operator InvokeRunResponse(SynchronousResponse value) => new(value);

    public static implicit operator InvokeRunResponse(AsynchronousResponse value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException(
                "Data did not match any variant of InvokeRunResponse"
            );
        }
    }
}

sealed class InvokeRunResponseConverter : JsonConverter<InvokeRunResponse>
{
    public override InvokeRunResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SynchronousResponse>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AsynchronousResponse>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvokeRunResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<SynchronousResponse, SynchronousResponseFromRaw>))]
public sealed record class SynchronousResponse : ModelBase
{
    /// <summary>
    /// Execution duration in milliseconds
    /// </summary>
    public double? Duration
    {
        get
        {
            if (!this._rawData.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Error message if status is failed
    /// </summary>
    public string? Error
    {
        get
        {
            if (!this._rawData.TryGetValue("error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Function return value
    /// </summary>
    public JsonElement? Output
    {
        get
        {
            if (!this._rawData.TryGetValue("output", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["output"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique run identifier
    /// </summary>
    public string? RunID
    {
        get
        {
            if (!this._rawData.TryGetValue("runId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["runId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Error;
        _ = this.Output;
        _ = this.RunID;
        this.Status?.Validate();
    }

    public SynchronousResponse() { }

    public SynchronousResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SynchronousResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SynchronousResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SynchronousResponseFromRaw : IFromRaw<SynchronousResponse>
{
    public SynchronousResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SynchronousResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Failed,
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

[JsonConverter(typeof(ModelConverter<AsynchronousResponse, AsynchronousResponseFromRaw>))]
public sealed record class AsynchronousResponse : ModelBase
{
    /// <summary>
    /// URL to check run status and logs
    /// </summary>
    public string? LogsURL
    {
        get
        {
            if (!this._rawData.TryGetValue("logsUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["logsUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique run identifier
    /// </summary>
    public string? RunID
    {
        get
        {
            if (!this._rawData.TryGetValue("runId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["runId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, AsynchronousResponseStatus>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AsynchronousResponseStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.LogsURL;
        _ = this.RunID;
        this.Status?.Validate();
    }

    public AsynchronousResponse() { }

    public AsynchronousResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AsynchronousResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AsynchronousResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AsynchronousResponseFromRaw : IFromRaw<AsynchronousResponse>
{
    public AsynchronousResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AsynchronousResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AsynchronousResponseStatusConverter))]
public enum AsynchronousResponseStatus
{
    Running,
}

sealed class AsynchronousResponseStatusConverter : JsonConverter<AsynchronousResponseStatus>
{
    public override AsynchronousResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => AsynchronousResponseStatus.Running,
            _ => (AsynchronousResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AsynchronousResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AsynchronousResponseStatus.Running => "running",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
