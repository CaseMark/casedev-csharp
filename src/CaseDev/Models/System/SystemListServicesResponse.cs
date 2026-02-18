using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.System;

[JsonConverter(
    typeof(JsonModelConverter<SystemListServicesResponse, SystemListServicesResponseFromRaw>)
)]
public sealed record class SystemListServicesResponse : JsonModel
{
    public required IReadOnlyList<Service> Services
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Service>>("services");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Service>>(
                "services",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Services)
        {
            item.Validate();
        }
    }

    public SystemListServicesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SystemListServicesResponse(SystemListServicesResponse systemListServicesResponse)
        : base(systemListServicesResponse) { }
#pragma warning restore CS8618

    public SystemListServicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SystemListServicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SystemListServicesResponseFromRaw.FromRawUnchecked"/>
    public static SystemListServicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SystemListServicesResponse(IReadOnlyList<Service> services)
        : this()
    {
        this.Services = services;
    }
}

class SystemListServicesResponseFromRaw : IFromRawJson<SystemListServicesResponse>
{
    /// <inheritdoc/>
    public SystemListServicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SystemListServicesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Service, ServiceFromRaw>))]
public sealed record class Service : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    public required string Icon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("icon");
        }
        init { this._rawData.Set("icon", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required long Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("order");
        }
        init { this._rawData.Set("order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Href;
        _ = this.Icon;
        _ = this.Name;
        _ = this.Order;
    }

    public Service() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Service(Service service)
        : base(service) { }
#pragma warning restore CS8618

    public Service(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Service(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServiceFromRaw.FromRawUnchecked"/>
    public static Service FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServiceFromRaw : IFromRawJson<Service>
{
    /// <inheritdoc/>
    public Service FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Service.FromRawUnchecked(rawData);
}
