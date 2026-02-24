using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Compute.V1.Environments;

[JsonConverter(typeof(JsonModelConverter<EnvironmentListResponse, EnvironmentListResponseFromRaw>))]
public sealed record class EnvironmentListResponse : JsonModel
{
    public IReadOnlyList<global::Casedev.Models.Compute.V1.Environments.Environment>? Environments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::Casedev.Models.Compute.V1.Environments.Environment>
            >("environments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::Casedev.Models.Compute.V1.Environments.Environment>?>(
                "environments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Environments ?? [])
        {
            item.Validate();
        }
    }

    public EnvironmentListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvironmentListResponse(EnvironmentListResponse environmentListResponse)
        : base(environmentListResponse) { }
#pragma warning restore CS8618

    public EnvironmentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentListResponseFromRaw.FromRawUnchecked"/>
    public static EnvironmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentListResponseFromRaw : IFromRawJson<EnvironmentListResponse>
{
    /// <inheritdoc/>
    public EnvironmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Casedev.Models.Compute.V1.Environments.Environment,
        EnvironmentFromRaw
    >)
)]
public sealed record class Environment : JsonModel
{
    /// <summary>
    /// Unique environment identifier
    /// </summary>
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

    /// <summary>
    /// Environment creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
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

    /// <summary>
    /// Environment domain
    /// </summary>
    public string? Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("domain", value);
        }
    }

    /// <summary>
    /// Whether this is the default environment
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isDefault");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isDefault", value);
        }
    }

    /// <summary>
    /// Human-readable environment name
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
    /// URL-safe environment identifier
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
    /// Environment status
    /// </summary>
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

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Domain;
        _ = this.IsDefault;
        _ = this.Name;
        _ = this.Slug;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public Environment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Environment(global::Casedev.Models.Compute.V1.Environments.Environment environment)
        : base(environment) { }
#pragma warning restore CS8618

    public Environment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Environment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentFromRaw.FromRawUnchecked"/>
    public static global::Casedev.Models.Compute.V1.Environments.Environment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentFromRaw : IFromRawJson<global::Casedev.Models.Compute.V1.Environments.Environment>
{
    /// <inheritdoc/>
    public global::Casedev.Models.Compute.V1.Environments.Environment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Casedev.Models.Compute.V1.Environments.Environment.FromRawUnchecked(rawData);
}
