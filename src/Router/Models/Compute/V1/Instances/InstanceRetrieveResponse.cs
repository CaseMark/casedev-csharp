using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Compute.V1.Instances;

[JsonConverter(
    typeof(JsonModelConverter<InstanceRetrieveResponse, InstanceRetrieveResponseFromRaw>)
)]
public sealed record class InstanceRetrieveResponse : JsonModel
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

    public long? AutoShutdownMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("autoShutdownMinutes");
        }
        init { this._rawData.Set("autoShutdownMinutes", value); }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? CurrentCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currentCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentCost", value);
        }
    }

    public long? CurrentRuntimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("currentRuntimeSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentRuntimeSeconds", value);
        }
    }

    public string? Gpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gpu", value);
        }
    }

    public string? InstanceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instanceType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instanceType", value);
        }
    }

    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init { this._rawData.Set("ip", value); }
    }

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

    public string? PricePerHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pricePerHour");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pricePerHour", value);
        }
    }

    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public JsonElement? Specs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("specs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("specs", value);
        }
    }

    public Ssh? Ssh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Ssh>("ssh");
        }
        init { this._rawData.Set("ssh", value); }
    }

    public string? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public JsonElement? VaultMounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("vaultMounts");
        }
        init { this._rawData.Set("vaultMounts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AutoShutdownMinutes;
        _ = this.CreatedAt;
        _ = this.CurrentCost;
        _ = this.CurrentRuntimeSeconds;
        _ = this.Gpu;
        _ = this.InstanceType;
        _ = this.IP;
        _ = this.Name;
        _ = this.PricePerHour;
        _ = this.Region;
        _ = this.Specs;
        this.Ssh?.Validate();
        _ = this.StartedAt;
        _ = this.Status;
        _ = this.VaultMounts;
    }

    public InstanceRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstanceRetrieveResponse(InstanceRetrieveResponse instanceRetrieveResponse)
        : base(instanceRetrieveResponse) { }
#pragma warning restore CS8618

    public InstanceRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstanceRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstanceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InstanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstanceRetrieveResponseFromRaw : IFromRawJson<InstanceRetrieveResponse>
{
    /// <inheritdoc/>
    public InstanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstanceRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Ssh, SshFromRaw>))]
public sealed record class Ssh : JsonModel
{
    public string? Command
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("command");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("command", value);
        }
    }

    public string? Host
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("host");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("host", value);
        }
    }

    public IReadOnlyList<JsonElement>? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "instructions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("privateKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("privateKey", value);
        }
    }

    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Command;
        _ = this.Host;
        _ = this.Instructions;
        _ = this.PrivateKey;
        _ = this.User;
    }

    public Ssh() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ssh(Ssh ssh)
        : base(ssh) { }
#pragma warning restore CS8618

    public Ssh(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ssh(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshFromRaw.FromRawUnchecked"/>
    public static Ssh FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SshFromRaw : IFromRawJson<Ssh>
{
    /// <inheritdoc/>
    public Ssh FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ssh.FromRawUnchecked(rawData);
}
