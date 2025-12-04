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

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SynchronousResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSynchronous(out var value)) {
    ///     // `value` is of type `SynchronousResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSynchronous([NotNullWhen(true)] out SynchronousResponse? value)
    {
        value = this.Value as SynchronousResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AsynchronousResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAsynchronous(out var value)) {
    ///     // `value` is of type `AsynchronousResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAsynchronous([NotNullWhen(true)] out AsynchronousResponse? value)
    {
        value = this.Value as AsynchronousResponse;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SynchronousResponse value) => {...},
    ///     (AsynchronousResponse value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SynchronousResponse value) => {...},
    ///     (AsynchronousResponse value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException(
                "Data did not match any variant of InvokeRunResponse"
            );
        }
    }

    public virtual bool Equals(InvokeRunResponse? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "duration"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration", value);
        }
    }

    /// <summary>
    /// Error message if status is failed
    /// </summary>
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

    /// <summary>
    /// Function return value
    /// </summary>
    public JsonElement? Output
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "output"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "output", value);
        }
    }

    /// <summary>
    /// Unique run identifier
    /// </summary>
    public string? RunID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "runId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "runId", value);
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawData, "status"); }
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
        _ = this.Output;
        _ = this.RunID;
        this.Status?.Validate();
    }

    public SynchronousResponse() { }

    public SynchronousResponse(SynchronousResponse synchronousResponse)
        : base(synchronousResponse) { }

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

    /// <inheritdoc cref="SynchronousResponseFromRaw.FromRawUnchecked"/>
    public static SynchronousResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SynchronousResponseFromRaw : IFromRaw<SynchronousResponse>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "logsUrl"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "logsUrl", value);
        }
    }

    /// <summary>
    /// Unique run identifier
    /// </summary>
    public string? RunID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "runId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "runId", value);
        }
    }

    public ApiEnum<string, AsynchronousResponseStatus>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, AsynchronousResponseStatus>>(
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
        _ = this.LogsURL;
        _ = this.RunID;
        this.Status?.Validate();
    }

    public AsynchronousResponse() { }

    public AsynchronousResponse(AsynchronousResponse asynchronousResponse)
        : base(asynchronousResponse) { }

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

    /// <inheritdoc cref="AsynchronousResponseFromRaw.FromRawUnchecked"/>
    public static AsynchronousResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AsynchronousResponseFromRaw : IFromRaw<AsynchronousResponse>
{
    /// <inheritdoc/>
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
