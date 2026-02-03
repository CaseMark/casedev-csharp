using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Legal.V1;

[JsonConverter(
    typeof(JsonModelConverter<V1ListJurisdictionsResponse, V1ListJurisdictionsResponseFromRaw>)
)]
public sealed record class V1ListJurisdictionsResponse : JsonModel
{
    /// <summary>
    /// Number of matching jurisdictions
    /// </summary>
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
    /// Usage guidance
    /// </summary>
    public string? Hint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hint", value);
        }
    }

    public IReadOnlyList<Jurisdiction>? Jurisdictions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Jurisdiction>>("jurisdictions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Jurisdiction>?>(
                "jurisdictions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original search query
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Found;
        _ = this.Hint;
        foreach (var item in this.Jurisdictions ?? [])
        {
            item.Validate();
        }
        _ = this.Query;
    }

    public V1ListJurisdictionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListJurisdictionsResponse(V1ListJurisdictionsResponse v1ListJurisdictionsResponse)
        : base(v1ListJurisdictionsResponse) { }
#pragma warning restore CS8618

    public V1ListJurisdictionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListJurisdictionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListJurisdictionsResponseFromRaw.FromRawUnchecked"/>
    public static V1ListJurisdictionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListJurisdictionsResponseFromRaw : IFromRawJson<V1ListJurisdictionsResponse>
{
    /// <inheritdoc/>
    public V1ListJurisdictionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1ListJurisdictionsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Jurisdiction, JurisdictionFromRaw>))]
public sealed record class Jurisdiction : JsonModel
{
    /// <summary>
    /// Jurisdiction ID to use in other endpoints
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
    /// Jurisdiction level
    /// </summary>
    public ApiEnum<string, Level>? Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Level>>("level");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("level", value);
        }
    }

    /// <summary>
    /// Full jurisdiction name
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
    /// State abbreviation (if applicable)
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Level?.Validate();
        _ = this.Name;
        _ = this.State;
    }

    public Jurisdiction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Jurisdiction(Jurisdiction jurisdiction)
        : base(jurisdiction) { }
#pragma warning restore CS8618

    public Jurisdiction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Jurisdiction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JurisdictionFromRaw.FromRawUnchecked"/>
    public static Jurisdiction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JurisdictionFromRaw : IFromRawJson<Jurisdiction>
{
    /// <inheritdoc/>
    public Jurisdiction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Jurisdiction.FromRawUnchecked(rawData);
}

/// <summary>
/// Jurisdiction level
/// </summary>
[JsonConverter(typeof(LevelConverter))]
public enum Level
{
    Federal,
    State,
    County,
    Municipal,
}

sealed class LevelConverter : JsonConverter<Level>
{
    public override Level Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "federal" => Level.Federal,
            "state" => Level.State,
            "county" => Level.County,
            "municipal" => Level.Municipal,
            _ => (Level)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Level.Federal => "federal",
                Level.State => "state",
                Level.County => "county",
                Level.Municipal => "municipal",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
