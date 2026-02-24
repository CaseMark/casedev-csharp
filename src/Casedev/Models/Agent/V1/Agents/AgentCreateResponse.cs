using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V1.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentCreateResponse, AgentCreateResponseFromRaw>))]
public sealed record class AgentCreateResponse : JsonModel
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

    public IReadOnlyList<string>? DisabledTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("disabledTools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "disabledTools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? EnabledTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("enabledTools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "enabledTools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instructions", value);
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

    public JsonElement? Sandbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("sandbox");
        }
        init { this._rawData.Set("sandbox", value); }
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
        _ = this.DisabledTools;
        _ = this.EnabledTools;
        _ = this.Instructions;
        _ = this.Model;
        _ = this.Name;
        _ = this.Sandbox;
        _ = this.UpdatedAt;
        _ = this.VaultIds;
    }

    public AgentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentCreateResponse(AgentCreateResponse agentCreateResponse)
        : base(agentCreateResponse) { }
#pragma warning restore CS8618

    public AgentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentCreateResponseFromRaw.FromRawUnchecked"/>
    public static AgentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentCreateResponseFromRaw : IFromRawJson<AgentCreateResponse>
{
    /// <inheritdoc/>
    public AgentCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentCreateResponse.FromRawUnchecked(rawData);
}
