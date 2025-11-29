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

namespace CaseDev.Models.Llm.V1;

/// <summary>
/// Create vector embeddings from text using OpenAI-compatible models. Perfect for
/// semantic search, document similarity, and building RAG systems for legal documents.
/// </summary>
public sealed record class V1CreateEmbeddingParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Text or array of texts to create embeddings for
    /// </summary>
    public required Input Input
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("input", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'input' cannot be null",
                    new ArgumentOutOfRangeException("input", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'input' cannot be null",
                    new ArgumentNullException("input")
                );
        }
        init
        {
            this._rawBodyData["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Embedding model to use (e.g., text-embedding-ada-002, text-embedding-3-small)
    /// </summary>
    public required string Model
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("model", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'model' cannot be null",
                    new ArgumentOutOfRangeException("model", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'model' cannot be null",
                    new ArgumentNullException("model")
                );
        }
        init
        {
            this._rawBodyData["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of dimensions for the embeddings (model-specific)
    /// </summary>
    public long? Dimensions
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("dimensions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["dimensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Format for returned embeddings
    /// </summary>
    public ApiEnum<string, EncodingFormat>? EncodingFormat
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("encoding_format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>?>(
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

            this._rawBodyData["encoding_format"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the end-user
    /// </summary>
    public string? User
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("user", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["user"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1CreateEmbeddingParams() { }

    public V1CreateEmbeddingParams(
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
    V1CreateEmbeddingParams(
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

    public static V1CreateEmbeddingParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/llm/v1/embeddings")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
/// Text or array of texts to create embeddings for
/// </summary>
[JsonConverter(typeof(InputConverter))]
public record class Input
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Input(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Input(IReadOnlyList<string> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public Input(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new CasedevInvalidDataException("Data did not match any variant of Input");
        }
    }

    public T Match<T>(Func<string, T> @string, Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new CasedevInvalidDataException("Data did not match any variant of Input"),
        };
    }

    public static implicit operator Input(string value) => new(value);

    public static implicit operator Input(List<string> value) => new((IReadOnlyList<string>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException("Data did not match any variant of Input");
        }
    }
}

sealed class InputConverter : JsonConverter<Input>
{
    public override Input? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Input value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Format for returned embeddings
/// </summary>
[JsonConverter(typeof(EncodingFormatConverter))]
public enum EncodingFormat
{
    Float,
    Base64,
}

sealed class EncodingFormatConverter : JsonConverter<EncodingFormat>
{
    public override EncodingFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "float" => EncodingFormat.Float,
            "base64" => EncodingFormat.Base64,
            _ => (EncodingFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EncodingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EncodingFormat.Float => "float",
                EncodingFormat.Base64 => "base64",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
