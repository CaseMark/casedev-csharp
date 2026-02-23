using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Agent.V1.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentDeleteResponse, AgentDeleteResponseFromRaw>))]
public sealed record class AgentDeleteResponse : JsonModel
{
    public bool? Ok
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("ok");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ok", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ok;
    }

    public AgentDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDeleteResponse(AgentDeleteResponse agentDeleteResponse)
        : base(agentDeleteResponse) { }
#pragma warning restore CS8618

    public AgentDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AgentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDeleteResponseFromRaw : IFromRawJson<AgentDeleteResponse>
{
    /// <inheritdoc/>
    public AgentDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentDeleteResponse.FromRawUnchecked(rawData);
}
