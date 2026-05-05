using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Vault.Objects;

[JsonConverter(typeof(JsonModelConverter<ObjectGetPagesResponse, ObjectGetPagesResponseFromRaw>))]
public sealed record class ObjectGetPagesResponse : JsonModel
{
    public required ObjectGetPagesResponseMetadata Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ObjectGetPagesResponseMetadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <summary>
    /// Per-page OCR text in ascending page order
    /// </summary>
    public required IReadOnlyList<ObjectGetPagesResponsePage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ObjectGetPagesResponsePage>>(
                "pages"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ObjectGetPagesResponsePage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Metadata.Validate();
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public ObjectGetPagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetPagesResponse(ObjectGetPagesResponse objectGetPagesResponse)
        : base(objectGetPagesResponse) { }
#pragma warning restore CS8618

    public ObjectGetPagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetPagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetPagesResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGetPagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetPagesResponseFromRaw : IFromRawJson<ObjectGetPagesResponse>
{
    /// <inheritdoc/>
    public ObjectGetPagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetPagesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ObjectGetPagesResponseMetadata,
        ObjectGetPagesResponseMetadataFromRaw
    >)
)]
public sealed record class ObjectGetPagesResponseMetadata : JsonModel
{
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    public required string ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("object_id");
        }
        init { this._rawData.Set("object_id", value); }
    }

    /// <summary>
    /// Total number of pages with extracted text in the document
    /// </summary>
    public required long PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_count");
        }
        init { this._rawData.Set("page_count", value); }
    }

    /// <summary>
    /// Number of pages returned after applying the range filter
    /// </summary>
    public required long ReturnedPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("returned_pages");
        }
        init { this._rawData.Set("returned_pages", value); }
    }

    /// <summary>
    /// Where the page text came from. `ocr` for PDFs (per-page OCR sidecar). `txt`
    /// for plain-text files split on form-feed (\f) characters.
    /// </summary>
    public required ApiEnum<string, Source> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Source>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vault_id");
        }
        init { this._rawData.Set("vault_id", value); }
    }

    /// <summary>
    /// Echoes the end query param if provided
    /// </summary>
    public long? End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Echoes the start query param if provided
    /// </summary>
    public long? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Filename;
        _ = this.ObjectID;
        _ = this.PageCount;
        _ = this.ReturnedPages;
        this.Source.Validate();
        _ = this.VaultID;
        _ = this.End;
        _ = this.Start;
    }

    public ObjectGetPagesResponseMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetPagesResponseMetadata(
        ObjectGetPagesResponseMetadata objectGetPagesResponseMetadata
    )
        : base(objectGetPagesResponseMetadata) { }
#pragma warning restore CS8618

    public ObjectGetPagesResponseMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetPagesResponseMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetPagesResponseMetadataFromRaw.FromRawUnchecked"/>
    public static ObjectGetPagesResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetPagesResponseMetadataFromRaw : IFromRawJson<ObjectGetPagesResponseMetadata>
{
    /// <inheritdoc/>
    public ObjectGetPagesResponseMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetPagesResponseMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Where the page text came from. `ocr` for PDFs (per-page OCR sidecar). `txt` for
/// plain-text files split on form-feed (\f) characters.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Ocr,
    Txt,
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
            "ocr" => Source.Ocr,
            "txt" => Source.Txt,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Ocr => "ocr",
                Source.Txt => "txt",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ObjectGetPagesResponsePage, ObjectGetPagesResponsePageFromRaw>)
)]
public sealed record class ObjectGetPagesResponsePage : JsonModel
{
    /// <summary>
    /// Page number (1-indexed)
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// OCR text for this page
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.Text;
    }

    public ObjectGetPagesResponsePage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGetPagesResponsePage(ObjectGetPagesResponsePage objectGetPagesResponsePage)
        : base(objectGetPagesResponsePage) { }
#pragma warning restore CS8618

    public ObjectGetPagesResponsePage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGetPagesResponsePage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGetPagesResponsePageFromRaw.FromRawUnchecked"/>
    public static ObjectGetPagesResponsePage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGetPagesResponsePageFromRaw : IFromRawJson<ObjectGetPagesResponsePage>
{
    /// <inheritdoc/>
    public ObjectGetPagesResponsePage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGetPagesResponsePage.FromRawUnchecked(rawData);
}
