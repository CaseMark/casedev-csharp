using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillReadResponse, SkillReadResponseFromRaw>))]
public sealed record class SkillReadResponse : JsonModel
{
    /// <summary>
    /// Skill author
    /// </summary>
    public string? AuthorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author_name", value);
        }
    }

    /// <summary>
    /// Skill bundle metadata for root skills and companion file rows
    /// </summary>
    public Bundle? Bundle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Bundle>("bundle");
        }
        init { this._rawData.Set("bundle", value); }
    }

    /// <summary>
    /// Full skill content in markdown
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// Skill license
    /// </summary>
    public string? License
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("license", value);
        }
    }

    /// <summary>
    /// Custom metadata (custom skills only)
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Skill name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Unique skill identifier
    /// </summary>
    public string? Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slug");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    /// <summary>
    /// Skill source (authenticated requests only)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Brief skill description
    /// </summary>
    public string? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("summary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("summary", value);
        }
    }

    /// <summary>
    /// Skill tags
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Skill version
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorName;
        this.Bundle?.Validate();
        _ = this.Content;
        _ = this.License;
        _ = this.Metadata;
        _ = this.Name;
        _ = this.Slug;
        this.Source?.Validate();
        _ = this.Summary;
        _ = this.Tags;
        _ = this.Version;
    }

    public SkillReadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillReadResponse(SkillReadResponse skillReadResponse)
        : base(skillReadResponse) { }
#pragma warning restore CS8618

    public SkillReadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillReadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillReadResponseFromRaw.FromRawUnchecked"/>
    public static SkillReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillReadResponseFromRaw : IFromRawJson<SkillReadResponse>
{
    /// <inheritdoc/>
    public SkillReadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillReadResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Skill bundle metadata for root skills and companion file rows
/// </summary>
[JsonConverter(typeof(BundleConverter))]
public record class Bundle : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Bundle(ReadResponseRootBundle value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Bundle(ReadResponseFileBundle value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Bundle(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReadResponseRootBundle"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadResponseRoot(out var value)) {
    ///     // `value` is of type `ReadResponseRootBundle`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadResponseRoot([NotNullWhen(true)] out ReadResponseRootBundle? value)
    {
        value = this.Value as ReadResponseRootBundle;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReadResponseFileBundle"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadResponseFile(out var value)) {
    ///     // `value` is of type `ReadResponseFileBundle`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadResponseFile([NotNullWhen(true)] out ReadResponseFileBundle? value)
    {
        value = this.Value as ReadResponseFileBundle;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (ReadResponseRootBundle value) =&gt; {...},
    ///     (ReadResponseFileBundle value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ReadResponseRootBundle> readResponseRoot,
        Action<ReadResponseFileBundle> readResponseFile
    )
    {
        switch (this.Value)
        {
            case ReadResponseRootBundle value:
                readResponseRoot(value);
                break;
            case ReadResponseFileBundle value:
                readResponseFile(value);
                break;
            default:
                throw new CasedevInvalidDataException("Data did not match any variant of Bundle");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (ReadResponseRootBundle value) =&gt; {...},
    ///     (ReadResponseFileBundle value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ReadResponseRootBundle, T> readResponseRoot,
        Func<ReadResponseFileBundle, T> readResponseFile
    )
    {
        return this.Value switch
        {
            ReadResponseRootBundle value => readResponseRoot(value),
            ReadResponseFileBundle value => readResponseFile(value),
            _ => throw new CasedevInvalidDataException("Data did not match any variant of Bundle"),
        };
    }

    public static implicit operator Bundle(ReadResponseRootBundle value) => new(value);

    public static implicit operator Bundle(ReadResponseFileBundle value) => new(value);

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
            throw new CasedevInvalidDataException("Data did not match any variant of Bundle");
        }
        this.Switch(
            (readResponseRoot) => readResponseRoot.Validate(),
            (readResponseFile) => readResponseFile.Validate()
        );
    }

    public virtual bool Equals(Bundle? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            ReadResponseRootBundle _ => 0,
            ReadResponseFileBundle _ => 1,
            _ => -1,
        };
    }
}

sealed class BundleConverter : JsonConverter<Bundle?>
{
    public override Bundle? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ReadResponseRootBundle>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ReadResponseFileBundle>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Bundle? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Skill source (authenticated requests only)
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Curated,
    Custom,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "curated" => Source.Curated,
            "custom" => Source.Custom,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Curated => "curated",
                Source.Custom => "custom",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
