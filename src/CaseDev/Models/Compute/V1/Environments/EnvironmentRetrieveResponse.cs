using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Environments;

[JsonConverter(
    typeof(JsonModelConverter<EnvironmentRetrieveResponse, EnvironmentRetrieveResponseFromRaw>)
)]
public sealed record class EnvironmentRetrieveResponse : JsonModel
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
    /// Environment domain URL
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
    /// Environment name
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
    /// URL-safe environment slug
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
    /// Environment status (active, inactive, etc.)
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
    /// Environment last update timestamp
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

    public EnvironmentRetrieveResponse() { }

    public EnvironmentRetrieveResponse(EnvironmentRetrieveResponse environmentRetrieveResponse)
        : base(environmentRetrieveResponse) { }

    public EnvironmentRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EnvironmentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentRetrieveResponseFromRaw : IFromRawJson<EnvironmentRetrieveResponse>
{
    /// <inheritdoc/>
    public EnvironmentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentRetrieveResponse.FromRawUnchecked(rawData);
}
