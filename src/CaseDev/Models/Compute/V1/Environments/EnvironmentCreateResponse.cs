using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Compute.V1.Environments;

[JsonConverter(typeof(ModelConverter<EnvironmentCreateResponse, EnvironmentCreateResponseFromRaw>))]
public sealed record class EnvironmentCreateResponse : ModelBase
{
    /// <summary>
    /// Unique environment identifier
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Environment creation timestamp
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Unique domain for this environment
    /// </summary>
    public string? Domain
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "domain"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "domain", value);
        }
    }

    /// <summary>
    /// Whether this is the default environment
    /// </summary>
    public bool? IsDefault
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "isDefault"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "isDefault", value);
        }
    }

    /// <summary>
    /// Environment name
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// URL-friendly slug derived from name
    /// </summary>
    public string? Slug
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "slug"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "slug", value);
        }
    }

    /// <summary>
    /// Environment status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
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
        this.Status?.Validate();
    }

    public EnvironmentCreateResponse() { }

    public EnvironmentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentCreateResponseFromRaw.FromRawUnchecked"/>
    public static EnvironmentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentCreateResponseFromRaw : IFromRaw<EnvironmentCreateResponse>
{
    /// <inheritdoc/>
    public EnvironmentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Environment status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "inactive" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Inactive => "inactive",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
