using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Actions.V1;

/// <summary>
/// Create a new action definition for multi-step workflow automation. Actions can
/// be defined using YAML or JSON format and support complex workflows including document
/// processing, data extraction, and analysis pipelines.
/// </summary>
public sealed record class V1CreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Action definition in YAML string, JSON string, or JSON object format
    /// </summary>
    public required Definition Definition
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("definition", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'definition' cannot be null",
                    new ArgumentOutOfRangeException("definition", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Definition>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'definition' cannot be null",
                    new ArgumentNullException("definition")
                );
        }
        init
        {
            this._rawBodyData["definition"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique name for the action
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("name", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._rawBodyData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional description of the action's purpose
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional webhook endpoint ID for action completion notifications
    /// </summary>
    public string? WebhookID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("webhook_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["webhook_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public V1CreateParams() { }

    public V1CreateParams(
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
    V1CreateParams(
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

    public static V1CreateParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/actions/v1")
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
/// Action definition in YAML string, JSON string, or JSON object format
/// </summary>
[JsonConverter(typeof(DefinitionConverter))]
public record class Definition
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Definition(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Definition(JsonElement value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Definition(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickJsonElement([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    public void Switch(Action<string> @string, Action<JsonElement> jsonElement)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case JsonElement value:
                jsonElement(value);
                break;
            default:
                throw new CasedevInvalidDataException(
                    "Data did not match any variant of Definition"
                );
        }
    }

    public T Match<T>(Func<string, T> @string, Func<JsonElement, T> jsonElement)
    {
        return this.Value switch
        {
            string value => @string(value),
            JsonElement value => jsonElement(value),
            _ => throw new CasedevInvalidDataException(
                "Data did not match any variant of Definition"
            ),
        };
    }

    public static implicit operator Definition(string value) => new(value);

    public static implicit operator Definition(JsonElement value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException("Data did not match any variant of Definition");
        }
    }

    public virtual bool Equals(Definition? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DefinitionConverter : JsonConverter<Definition>
{
    public override Definition? Read(
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
            return new(JsonSerializer.Deserialize<JsonElement>(json, options));
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Definition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
