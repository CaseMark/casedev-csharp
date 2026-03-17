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

[JsonConverter(typeof(JsonModelConverter<V1SecFilingResponse, V1SecFilingResponseFromRaw>))]
public sealed record class V1SecFilingResponse : JsonModel
{
    public string? Cik
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cik");
        }
        init { this._rawData.Set("cik", value); }
    }

    public string? DateAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateAfter");
        }
        init { this._rawData.Set("dateAfter", value); }
    }

    public string? DateBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dateBefore");
        }
        init { this._rawData.Set("dateBefore", value); }
    }

    public string? Entity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entity");
        }
        init { this._rawData.Set("entity", value); }
    }

    public IReadOnlyList<Filing>? Filings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Filing>>("filings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Filing>?>(
                "filings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? FormTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("formTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "formTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    public string? Ticker
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticker");
        }
        init { this._rawData.Set("ticker", value); }
    }

    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    public ApiEnum<string, V1SecFilingResponseType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, V1SecFilingResponseType>>("type");
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
        _ = this.Cik;
        _ = this.DateAfter;
        _ = this.DateBefore;
        _ = this.Entity;
        foreach (var item in this.Filings ?? [])
        {
            item.Validate();
        }
        _ = this.FormTypes;
        _ = this.Limit;
        _ = this.Offset;
        _ = this.Query;
        _ = this.Ticker;
        _ = this.Total;
        this.Type?.Validate();
    }

    public V1SecFilingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SecFilingResponse(V1SecFilingResponse v1SecFilingResponse)
        : base(v1SecFilingResponse) { }
#pragma warning restore CS8618

    public V1SecFilingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SecFilingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1SecFilingResponseFromRaw.FromRawUnchecked"/>
    public static V1SecFilingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1SecFilingResponseFromRaw : IFromRawJson<V1SecFilingResponse>
{
    /// <inheritdoc/>
    public V1SecFilingResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1SecFilingResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Filing, FilingFromRaw>))]
public sealed record class Filing : JsonModel
{
    public string? AccessionNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accessionNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accessionNumber", value);
        }
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

    public IReadOnlyList<FilingDocument>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FilingDocument>>("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FilingDocument>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Entity? Entity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Entity>("entity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entity", value);
        }
    }

    public string? FiledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filedAt", value);
        }
    }

    public string? FormType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formType", value);
        }
    }

    public string? PeriodOfReport
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("periodOfReport");
        }
        init { this._rawData.Set("periodOfReport", value); }
    }

    public string? SecUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("secUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("secUrl", value);
        }
    }

    public string? Snippet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("snippet");
        }
        init { this._rawData.Set("snippet", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessionNumber;
        _ = this.Description;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        this.Entity?.Validate();
        _ = this.FiledAt;
        _ = this.FormType;
        _ = this.PeriodOfReport;
        _ = this.SecUrl;
        _ = this.Snippet;
    }

    public Filing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filing(Filing filing)
        : base(filing) { }
#pragma warning restore CS8618

    public Filing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilingFromRaw.FromRawUnchecked"/>
    public static Filing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilingFromRaw : IFromRawJson<Filing>
{
    /// <inheritdoc/>
    public Filing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FilingDocument, FilingDocumentFromRaw>))]
public sealed record class FilingDocument : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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
        _ = this.Description;
        _ = this.Type;
        _ = this.Url;
    }

    public FilingDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilingDocument(FilingDocument filingDocument)
        : base(filingDocument) { }
#pragma warning restore CS8618

    public FilingDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilingDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilingDocumentFromRaw.FromRawUnchecked"/>
    public static FilingDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilingDocumentFromRaw : IFromRawJson<FilingDocument>
{
    /// <inheritdoc/>
    public FilingDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FilingDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Entity, EntityFromRaw>))]
public sealed record class Entity : JsonModel
{
    public string? Cik
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cik");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cik", value);
        }
    }

    public string? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entityType");
        }
        init { this._rawData.Set("entityType", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Sic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sic");
        }
        init { this._rawData.Set("sic", value); }
    }

    public string? SicDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sicDescription");
        }
        init { this._rawData.Set("sicDescription", value); }
    }

    public string? StateOfIncorporation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stateOfIncorporation");
        }
        init { this._rawData.Set("stateOfIncorporation", value); }
    }

    public string? Ticker
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticker");
        }
        init { this._rawData.Set("ticker", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cik;
        _ = this.EntityType;
        _ = this.Name;
        _ = this.Sic;
        _ = this.SicDescription;
        _ = this.StateOfIncorporation;
        _ = this.Ticker;
    }

    public Entity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entity(Entity entity)
        : base(entity) { }
#pragma warning restore CS8618

    public Entity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityFromRaw.FromRawUnchecked"/>
    public static Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityFromRaw : IFromRawJson<Entity>
{
    /// <inheritdoc/>
    public Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entity.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(V1SecFilingResponseTypeConverter))]
public enum V1SecFilingResponseType
{
    Search,
    Entity,
}

sealed class V1SecFilingResponseTypeConverter : JsonConverter<V1SecFilingResponseType>
{
    public override V1SecFilingResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "search" => V1SecFilingResponseType.Search,
            "entity" => V1SecFilingResponseType.Entity,
            _ => (V1SecFilingResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1SecFilingResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                V1SecFilingResponseType.Search => "search",
                V1SecFilingResponseType.Entity => "entity",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
