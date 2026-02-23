using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Vault.Graphrag;

[JsonConverter(
    typeof(JsonModelConverter<GraphragProcessObjectResponse, GraphragProcessObjectResponseFromRaw>)
)]
public sealed record class GraphragProcessObjectResponse : JsonModel
{
    /// <summary>
    /// Number of communities detected
    /// </summary>
    public required long Communities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("communities");
        }
        init { this._rawData.Set("communities", value); }
    }

    /// <summary>
    /// Number of entities extracted
    /// </summary>
    public required long Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("entities");
        }
        init { this._rawData.Set("entities", value); }
    }

    /// <summary>
    /// ID of the indexed object
    /// </summary>
    public required string ObjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("objectId");
        }
        init { this._rawData.Set("objectId", value); }
    }

    /// <summary>
    /// Number of relationships extracted
    /// </summary>
    public required long Relationships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("relationships");
        }
        init { this._rawData.Set("relationships", value); }
    }

    /// <summary>
    /// Extraction statistics
    /// </summary>
    public required Stats Stats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Stats>("stats");
        }
        init { this._rawData.Set("stats", value); }
    }

    /// <summary>
    /// Status from GraphRAG service
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Whether indexing completed successfully
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// ID of the vault
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vaultId");
        }
        init { this._rawData.Set("vaultId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Communities;
        _ = this.Entities;
        _ = this.ObjectID;
        _ = this.Relationships;
        this.Stats.Validate();
        _ = this.Status;
        _ = this.Success;
        _ = this.VaultID;
    }

    public GraphragProcessObjectResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GraphragProcessObjectResponse(
        GraphragProcessObjectResponse graphragProcessObjectResponse
    )
        : base(graphragProcessObjectResponse) { }
#pragma warning restore CS8618

    public GraphragProcessObjectResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphragProcessObjectResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GraphragProcessObjectResponseFromRaw.FromRawUnchecked"/>
    public static GraphragProcessObjectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GraphragProcessObjectResponseFromRaw : IFromRawJson<GraphragProcessObjectResponse>
{
    /// <inheritdoc/>
    public GraphragProcessObjectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GraphragProcessObjectResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Extraction statistics
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Stats, StatsFromRaw>))]
public sealed record class Stats : JsonModel
{
    public long? CommunityCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("community_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("community_count", value);
        }
    }

    public long? EntityCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("entity_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entity_count", value);
        }
    }

    public long? RelationshipCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("relationship_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("relationship_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CommunityCount;
        _ = this.EntityCount;
        _ = this.RelationshipCount;
    }

    public Stats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Stats(Stats stats)
        : base(stats) { }
#pragma warning restore CS8618

    public Stats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Stats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatsFromRaw.FromRawUnchecked"/>
    public static Stats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatsFromRaw : IFromRawJson<Stats>
{
    /// <inheritdoc/>
    public Stats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Stats.FromRawUnchecked(rawData);
}
