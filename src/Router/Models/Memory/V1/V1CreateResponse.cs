using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Memory.V1;

[JsonConverter(typeof(JsonModelConverter<V1CreateResponse, V1CreateResponseFromRaw>))]
public sealed record class V1CreateResponse : JsonModel
{
    public IReadOnlyList<Result>? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public V1CreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateResponse(V1CreateResponse v1CreateResponse)
        : base(v1CreateResponse) { }
#pragma warning restore CS8618

    public V1CreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1CreateResponseFromRaw.FromRawUnchecked"/>
    public static V1CreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1CreateResponseFromRaw : IFromRawJson<V1CreateResponse>
{
    /// <inheritdoc/>
    public V1CreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1CreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Memory ID
    /// </summary>
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
    /// What happened to this memory
    /// </summary>
    public ApiEnum<string, Event>? Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Event>>("event");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event", value);
        }
    }

    /// <summary>
    /// Extracted memory text
    /// </summary>
    public string? Memory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memory", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Event?.Validate();
        _ = this.Memory;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// What happened to this memory
/// </summary>
[JsonConverter(typeof(EventConverter))]
public enum Event
{
    Add,
    Update,
    Delete,
    None,
}

sealed class EventConverter : JsonConverter<Event>
{
    public override Event Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ADD" => Event.Add,
            "UPDATE" => Event.Update,
            "DELETE" => Event.Delete,
            "NONE" => Event.None,
            _ => (Event)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Event.Add => "ADD",
                Event.Update => "UPDATE",
                Event.Delete => "DELETE",
                Event.None => "NONE",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
