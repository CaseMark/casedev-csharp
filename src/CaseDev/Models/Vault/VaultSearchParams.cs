using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

/// <summary>
/// Search across vault documents using multiple methods including hybrid vector
/// + graph search, GraphRAG global search, entity-based search, and fast similarity
/// search. Returns relevant documents and contextual answers based on the search method.
/// </summary>
public sealed record class VaultSearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Search query or question to find relevant documents
    /// </summary>
    public required string Query
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "query"); }
        init { JsonModel.Set(this._rawBodyData, "query", value); }
    }

    /// <summary>
    /// Filters to narrow search results to specific documents
    /// </summary>
    public Filters? Filters
    {
        get { return JsonModel.GetNullableClass<Filters>(this.RawBodyData, "filters"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "filters", value);
        }
    }

    /// <summary>
    /// Search method: 'global' for comprehensive questions, 'entity' for specific
    /// entities, 'fast' for quick similarity search, 'hybrid' for combined approach
    /// </summary>
    public ApiEnum<string, Method>? Method
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Method>>(this.RawBodyData, "method");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "method", value);
        }
    }

    /// <summary>
    /// Maximum number of results to return
    /// </summary>
    public long? TopK
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "topK"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "topK", value);
        }
    }

    public VaultSearchParams() { }

    public VaultSearchParams(VaultSearchParams vaultSearchParams)
        : base(vaultSearchParams)
    {
        this._rawBodyData = [.. vaultSearchParams._rawBodyData];
    }

    public VaultSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static VaultSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/vault/{0}/search", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Filters to narrow search results to specific documents
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    /// <summary>
    /// Filter to specific document(s) by object ID. Accepts a single ID or array
    /// of IDs.
    /// </summary>
    public ObjectID? ObjectID
    {
        get { return JsonModel.GetNullableClass<ObjectID>(this.RawData, "object_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "object_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ObjectID?.Validate();
    }

    public Filters() { }

    public Filters(Filters filters)
        : base(filters) { }

    public Filters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FiltersFromRaw.FromRawUnchecked"/>
    public static Filters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FiltersFromRaw : IFromRawJson<Filters>
{
    /// <inheritdoc/>
    public Filters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filters.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter to specific document(s) by object ID. Accepts a single ID or array of IDs.
/// </summary>
[JsonConverter(typeof(ObjectIDConverter))]
public record class ObjectID : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ObjectID(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ObjectID(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ObjectID(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<string>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList<string>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    ///     (string value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new CasedevInvalidDataException("Data did not match any variant of ObjectID");
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
    ///     (string value) => {...},
    ///     (IReadOnlyList<string> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new CasedevInvalidDataException(
                "Data did not match any variant of ObjectID"
            ),
        };
    }

    public static implicit operator ObjectID(string value) => new(value);

    public static implicit operator ObjectID(List<string> value) =>
        new((IReadOnlyList<string>)value);

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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException("Data did not match any variant of ObjectID");
        }
    }

    public virtual bool Equals(ObjectID? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ObjectIDConverter : JsonConverter<ObjectID>
{
    public override ObjectID? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, ObjectID value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Search method: 'global' for comprehensive questions, 'entity' for specific entities,
/// 'fast' for quick similarity search, 'hybrid' for combined approach
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Vector,
    Graph,
    Hybrid,
    Global,
    Local,
    Fast,
    Entity,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vector" => Method.Vector,
            "graph" => Method.Graph,
            "hybrid" => Method.Hybrid,
            "global" => Method.Global,
            "local" => Method.Local,
            "fast" => Method.Fast,
            "entity" => Method.Entity,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Vector => "vector",
                Method.Graph => "graph",
                Method.Hybrid => "hybrid",
                Method.Global => "global",
                Method.Local => "local",
                Method.Fast => "fast",
                Method.Entity => "entity",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
