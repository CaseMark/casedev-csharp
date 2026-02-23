using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Legal.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1TrademarkSearchResponse, V1TrademarkSearchResponseFromRaw>)
)]
public sealed record class V1TrademarkSearchResponse : JsonModel
{
    /// <summary>
    /// Attorney of record
    /// </summary>
    public string? Attorney
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attorney");
        }
        init { this._rawData.Set("attorney", value); }
    }

    /// <summary>
    /// Date the application was filed
    /// </summary>
    public string? FilingDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filingDate");
        }
        init { this._rawData.Set("filingDate", value); }
    }

    /// <summary>
    /// Goods and services descriptions with class numbers
    /// </summary>
    public IReadOnlyList<GoodsAndService>? GoodsAndServices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GoodsAndService>>(
                "goodsAndServices"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<GoodsAndService>?>(
                "goodsAndServices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL to the mark image on USPTO CDN
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init { this._rawData.Set("imageUrl", value); }
    }

    /// <summary>
    /// The text of the trademark
    /// </summary>
    public string? MarkText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("markText");
        }
        init { this._rawData.Set("markText", value); }
    }

    /// <summary>
    /// Type of mark (e.g. "Standard Character Mark", "Design Mark")
    /// </summary>
    public string? MarkType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("markType");
        }
        init { this._rawData.Set("markType", value); }
    }

    /// <summary>
    /// Nice classification class numbers
    /// </summary>
    public IReadOnlyList<long>? NiceClasses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("niceClasses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "niceClasses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Current owner/applicant information
    /// </summary>
    public Owner? Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Owner>("owner");
        }
        init { this._rawData.Set("owner", value); }
    }

    /// <summary>
    /// Date the mark was registered
    /// </summary>
    public string? RegistrationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registrationDate");
        }
        init { this._rawData.Set("registrationDate", value); }
    }

    /// <summary>
    /// USPTO registration number (if registered)
    /// </summary>
    public string? RegistrationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registrationNumber");
        }
        init { this._rawData.Set("registrationNumber", value); }
    }

    /// <summary>
    /// USPTO serial number
    /// </summary>
    public string? SerialNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("serialNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("serialNumber", value);
        }
    }

    /// <summary>
    /// Current status (e.g. "Registered", "Pending", "Abandoned", "Cancelled")
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Date of most recent status update
    /// </summary>
    public string? StatusDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("statusDate");
        }
        init { this._rawData.Set("statusDate", value); }
    }

    /// <summary>
    /// Canonical TSDR link for this mark
    /// </summary>
    public string? UsptoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("usptoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usptoUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attorney;
        _ = this.FilingDate;
        foreach (var item in this.GoodsAndServices ?? [])
        {
            item.Validate();
        }
        _ = this.ImageUrl;
        _ = this.MarkText;
        _ = this.MarkType;
        _ = this.NiceClasses;
        this.Owner?.Validate();
        _ = this.RegistrationDate;
        _ = this.RegistrationNumber;
        _ = this.SerialNumber;
        _ = this.Status;
        _ = this.StatusDate;
        _ = this.UsptoUrl;
    }

    public V1TrademarkSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1TrademarkSearchResponse(V1TrademarkSearchResponse v1TrademarkSearchResponse)
        : base(v1TrademarkSearchResponse) { }
#pragma warning restore CS8618

    public V1TrademarkSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1TrademarkSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1TrademarkSearchResponseFromRaw.FromRawUnchecked"/>
    public static V1TrademarkSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1TrademarkSearchResponseFromRaw : IFromRawJson<V1TrademarkSearchResponse>
{
    /// <inheritdoc/>
    public V1TrademarkSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1TrademarkSearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GoodsAndService, GoodsAndServiceFromRaw>))]
public sealed record class GoodsAndService : JsonModel
{
    public string? ClassNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("classNumber");
        }
        init { this._rawData.Set("classNumber", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClassNumber;
        _ = this.Description;
    }

    public GoodsAndService() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoodsAndService(GoodsAndService goodsAndService)
        : base(goodsAndService) { }
#pragma warning restore CS8618

    public GoodsAndService(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoodsAndService(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoodsAndServiceFromRaw.FromRawUnchecked"/>
    public static GoodsAndService FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoodsAndServiceFromRaw : IFromRawJson<GoodsAndService>
{
    /// <inheritdoc/>
    public GoodsAndService FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoodsAndService.FromRawUnchecked(rawData);
}

/// <summary>
/// Current owner/applicant information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Owner, OwnerFromRaw>))]
public sealed record class Owner : JsonModel
{
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.EntityType;
        _ = this.Name;
    }

    public Owner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Owner(Owner owner)
        : base(owner) { }
#pragma warning restore CS8618

    public Owner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Owner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OwnerFromRaw.FromRawUnchecked"/>
    public static Owner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnerFromRaw : IFromRawJson<Owner>
{
    /// <inheritdoc/>
    public Owner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Owner.FromRawUnchecked(rawData);
}
