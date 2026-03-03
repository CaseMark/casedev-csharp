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
    public Docket? Docket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Docket>("docket");
        }
        init { this._rawData.Set("docket", value); }
    }

    /// <summary>
    /// Search results (search mode)
    /// </summary>
    public IReadOnlyList<V1DocketResponseDocket>? Dockets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<V1DocketResponseDocket>>(
                "dockets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<V1DocketResponseDocket>?>(
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

/// <summary>
/// Full docket record (lookup mode)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Docket, DocketFromRaw>))]
public sealed record class Docket : JsonModel
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

    public string? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    public string? CaseName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caseName");
        }
        init { this._rawData.Set("caseName", value); }
    }

    public string? Cause
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cause");
        }
        init { this._rawData.Set("cause", value); }
    }

    public string? Court
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("court");
        }
        init { this._rawData.Set("court", value); }
    }

    public string? CourtID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("courtId");
        }
        init { this._rawData.Set("courtId", value); }
    }

    public string? DateFiled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateFiled");
        }
        init { this._rawData.Set("dateFiled", value); }
    }

    public string? DateTerminated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateTerminated");
        }
        init { this._rawData.Set("dateTerminated", value); }
    }

    public string? DocketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("docketNumber");
        }
        init { this._rawData.Set("docketNumber", value); }
    }

    public string? NatureOfSuit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("natureOfSuit");
        }
        init { this._rawData.Set("natureOfSuit", value); }
    }

    public string? PacerCaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pacerCaseId");
        }
        init { this._rawData.Set("pacerCaseId", value); }
    }

    public IReadOnlyList<string>? Parties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("parties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "parties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AssignedTo;
        _ = this.CaseName;
        _ = this.Cause;
        _ = this.Court;
        _ = this.CourtID;
        _ = this.DateFiled;
        _ = this.DateTerminated;
        _ = this.DocketNumber;
        _ = this.NatureOfSuit;
        _ = this.PacerCaseID;
        _ = this.Parties;
        _ = this.Url;
    }

    public Docket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Docket(Docket docket)
        : base(docket) { }
#pragma warning restore CS8618

    public Docket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Docket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocketFromRaw.FromRawUnchecked"/>
    public static Docket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocketFromRaw : IFromRawJson<Docket>
{
    /// <inheritdoc/>
    public Docket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Docket.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V1DocketResponseDocket, V1DocketResponseDocketFromRaw>))]
public sealed record class V1DocketResponseDocket : JsonModel
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

    public string? AssignedTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("assignedTo");
        }
        init { this._rawData.Set("assignedTo", value); }
    }

    public string? CaseName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("caseName");
        }
        init { this._rawData.Set("caseName", value); }
    }

    public string? Cause
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cause");
        }
        init { this._rawData.Set("cause", value); }
    }

    public string? Court
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("court");
        }
        init { this._rawData.Set("court", value); }
    }

    public string? CourtID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("courtId");
        }
        init { this._rawData.Set("courtId", value); }
    }

    public string? DateFiled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateFiled");
        }
        init { this._rawData.Set("dateFiled", value); }
    }

    public string? DateTerminated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateTerminated");
        }
        init { this._rawData.Set("dateTerminated", value); }
    }

    public string? DocketNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("docketNumber");
        }
        init { this._rawData.Set("docketNumber", value); }
    }

    public string? NatureOfSuit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("natureOfSuit");
        }
        init { this._rawData.Set("natureOfSuit", value); }
    }

    public string? PacerCaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pacerCaseId");
        }
        init { this._rawData.Set("pacerCaseId", value); }
    }

    public IReadOnlyList<string>? Parties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("parties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "parties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AssignedTo;
        _ = this.CaseName;
        _ = this.Cause;
        _ = this.Court;
        _ = this.CourtID;
        _ = this.DateFiled;
        _ = this.DateTerminated;
        _ = this.DocketNumber;
        _ = this.NatureOfSuit;
        _ = this.PacerCaseID;
        _ = this.Parties;
        _ = this.Url;
    }

    public V1DocketResponseDocket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DocketResponseDocket(V1DocketResponseDocket v1DocketResponseDocket)
        : base(v1DocketResponseDocket) { }
#pragma warning restore CS8618

    public V1DocketResponseDocket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DocketResponseDocket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DocketResponseDocketFromRaw.FromRawUnchecked"/>
    public static V1DocketResponseDocket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DocketResponseDocketFromRaw : IFromRawJson<V1DocketResponseDocket>
{
    /// <inheritdoc/>
    public V1DocketResponseDocket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1DocketResponseDocket.FromRawUnchecked(rawData);
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
