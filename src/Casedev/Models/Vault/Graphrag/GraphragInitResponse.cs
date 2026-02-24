using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Vault.Graphrag;

[JsonConverter(typeof(JsonModelConverter<GraphragInitResponse, GraphragInitResponseFromRaw>))]
public sealed record class GraphragInitResponse : JsonModel
{
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
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

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    public string? VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vault_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vault_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Status;
        _ = this.Success;
        _ = this.VaultID;
    }

    public GraphragInitResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GraphragInitResponse(GraphragInitResponse graphragInitResponse)
        : base(graphragInitResponse) { }
#pragma warning restore CS8618

    public GraphragInitResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GraphragInitResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GraphragInitResponseFromRaw.FromRawUnchecked"/>
    public static GraphragInitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GraphragInitResponseFromRaw : IFromRawJson<GraphragInitResponse>
{
    /// <inheritdoc/>
    public GraphragInitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GraphragInitResponse.FromRawUnchecked(rawData);
}
