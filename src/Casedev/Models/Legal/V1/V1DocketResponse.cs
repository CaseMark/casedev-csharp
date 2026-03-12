using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Legal.V1;

[JsonConverter(typeof(JsonModelConverter<V1DocketResponse, V1DocketResponseFromRaw>))]
public sealed record class V1DocketResponse : JsonModel
{
    /// <summary>
    /// Echo of court filter (search mode only)
    /// </summary>
    public string? Court
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("court");
        }
        init { this._rawData.Set("court", value); }
    }

    /// <summary>
    /// Echo of date filter
    /// </summary>
    public string? DateFiledAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateFiledAfter");
        }
        init { this._rawData.Set("dateFiledAfter", value); }
    }

    /// <summary>
    /// Echo of date filter
    /// </summary>
    public string? DateFiledBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateFiledBefore");
        }
        init { this._rawData.Set("dateFiledBefore", value); }
    }

    /// <summary>
    /// Full docket record (lookup mode)
    /// </summary>
    public DocketDetail? Docket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocketDetail>("docket");
        }
        init { this._rawData.Set("docket", value); }
    }

    /// <summary>
    /// Search results (search mode)
    /// </summary>
    public IReadOnlyList<DocketSearchResult>? Dockets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DocketSearchResult>>("dockets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DocketSearchResult>?>(
                "dockets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Docket entries/filings (lookup mode with includeEntries)
    /// </summary>
    public IReadOnlyList<Entry>? Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Entry>>("entries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entry>?>(
                "entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Found
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("found");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("found", value);
        }
    }

    /// <summary>
    /// Whether entries were requested (lookup mode only)
    /// </summary>
    public bool? IncludeEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeEntries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeEntries", value);
        }
    }

    /// <summary>
    /// Whether this was a live PACER fetch (lookup mode only)
    /// </summary>
    public bool? Live
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("live");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("live", value);
        }
    }

    /// <summary>
    /// PACER fee information (present when live: true)
    /// </summary>
    public PacerFees? PacerFees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PacerFees>("pacerFees");
        }
        init { this._rawData.Set("pacerFees", value); }
    }

    /// <summary>
    /// Pagination info for entry list (lookup mode with includeEntries)
    /// </summary>
    public Pagination? Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <summary>
    /// Echo of search query (search mode only)
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    public ApiEnum<string, V1DocketResponseType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, V1DocketResponseType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Court;
        _ = this.DateFiledAfter;
        _ = this.DateFiledBefore;
        this.Docket?.Validate();
        foreach (var item in this.Dockets ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Entries ?? [])
        {
            item.Validate();
        }
        _ = this.Found;
        _ = this.IncludeEntries;
        _ = this.Live;
        this.PacerFees?.Validate();
        this.Pagination?.Validate();
        _ = this.Query;
        this.Type?.Validate();
    }

    public V1DocketResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DocketResponse(V1DocketResponse v1DocketResponse)
        : base(v1DocketResponse) { }
#pragma warning restore CS8618

    public V1DocketResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DocketResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DocketResponseFromRaw.FromRawUnchecked"/>
    public static V1DocketResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DocketResponseFromRaw : IFromRawJson<V1DocketResponse>
{
    /// <inheritdoc/>
    public V1DocketResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DocketResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Entry, EntryFromRaw>))]
public sealed record class Entry : JsonModel
{
    public string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public IReadOnlyList<Document>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Document>>("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Document>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? EntryNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("entryNumber");
        }
        init { this._rawData.Set("entryNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Date;
        _ = this.Description;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.EntryNumber;
    }

    public Entry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entry(Entry entry)
        : base(entry) { }
#pragma warning restore CS8618

    public Entry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntryFromRaw.FromRawUnchecked"/>
    public static Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntryFromRaw : IFromRawJson<Entry>
{
    /// <inheritdoc/>
    public Entry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
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

    public long? AttachmentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attachmentNumber");
        }
        init { this._rawData.Set("attachmentNumber", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? DocumentNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("documentNumber");
        }
        init { this._rawData.Set("documentNumber", value); }
    }

    public bool? IsAvailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isAvailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isAvailable", value);
        }
    }

    public long? PageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pageCount");
        }
        init { this._rawData.Set("pageCount", value); }
    }

    public string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdfUrl");
        }
        init { this._rawData.Set("pdfUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AttachmentNumber;
        _ = this.Description;
        _ = this.DocumentNumber;
        _ = this.IsAvailable;
        _ = this.PageCount;
        _ = this.PdfUrl;
    }

    public Document() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document(Document document)
        : base(document) { }
#pragma warning restore CS8618

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}

/// <summary>
/// PACER fee information (present when live: true)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PacerFees, PacerFeesFromRaw>))]
public sealed record class PacerFees : JsonModel
{
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Time taken for PACER fetch in milliseconds
    /// </summary>
    public long? FetchDurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fetchDurationMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fetchDurationMs", value);
        }
    }

    /// <summary>
    /// Maximum PACER charge per docket in USD
    /// </summary>
    public double? MaxPacerCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxPacerCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxPacerCost", value);
        }
    }

    /// <summary>
    /// CaseMark service fee in USD
    /// </summary>
    public double? ServiceFee
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("serviceFee");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("serviceFee", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Currency?.Validate();
        _ = this.FetchDurationMs;
        _ = this.MaxPacerCost;
        _ = this.ServiceFee;
    }

    public PacerFees() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PacerFees(PacerFees pacerFees)
        : base(pacerFees) { }
#pragma warning restore CS8618

    public PacerFees(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PacerFees(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PacerFeesFromRaw.FromRawUnchecked"/>
    public static PacerFees FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PacerFeesFromRaw : IFromRawJson<PacerFees>
{
    /// <inheritdoc/>
    public PacerFees FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PacerFees.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    Usd,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.Usd,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "USD",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination info for entry list (lookup mode with includeEntries)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    public long? Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("offset", value);
        }
    }

    public long? Returned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("returned");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("returned", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Limit;
        _ = this.Offset;
        _ = this.Returned;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(V1DocketResponseTypeConverter))]
public enum V1DocketResponseType
{
    Search,
    Lookup,
}

sealed class V1DocketResponseTypeConverter : JsonConverter<V1DocketResponseType>
{
    public override V1DocketResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "search" => V1DocketResponseType.Search,
            "lookup" => V1DocketResponseType.Lookup,
            _ => (V1DocketResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1DocketResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1DocketResponseType.Search => "search",
                V1DocketResponseType.Lookup => "lookup",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
