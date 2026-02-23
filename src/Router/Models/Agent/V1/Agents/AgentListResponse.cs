using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Agent.V1.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentListResponse, AgentListResponseFromRaw>))]
public sealed record class AgentListResponse : JsonModel
{
    public IReadOnlyList<AgentListResponseAgent>? Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AgentListResponseAgent>>(
                "agents"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentListResponseAgent>?>(
                "agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agents ?? [])
        {
            item.Validate();
        }
    }

    public AgentListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentListResponse(AgentListResponse agentListResponse)
        : base(agentListResponse) { }
#pragma warning restore CS8618

    public AgentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentListResponseFromRaw.FromRawUnchecked"/>
    public static AgentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentListResponseFromRaw : IFromRawJson<AgentListResponse>
{
    /// <inheritdoc/>
    public AgentListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AgentListResponseAgent, AgentListResponseAgentFromRaw>))]
public sealed record class AgentListResponseAgent : JsonModel
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isActive", value);
        }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
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

    public IReadOnlyList<string>? VaultIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("vaultIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "vaultIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.IsActive;
        _ = this.Model;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.VaultIds;
    }

    public AgentListResponseAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentListResponseAgent(AgentListResponseAgent agentListResponseAgent)
        : base(agentListResponseAgent) { }
#pragma warning restore CS8618

    public AgentListResponseAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentListResponseAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentListResponseAgentFromRaw.FromRawUnchecked"/>
    public static AgentListResponseAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentListResponseAgentFromRaw : IFromRawJson<AgentListResponseAgent>
{
    /// <inheritdoc/>
    public AgentListResponseAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentListResponseAgent.FromRawUnchecked(rawData);
}
