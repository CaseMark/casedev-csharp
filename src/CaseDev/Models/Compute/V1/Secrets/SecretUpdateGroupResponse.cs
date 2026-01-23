using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Secrets;

[JsonConverter(
    typeof(JsonModelConverter<SecretUpdateGroupResponse, SecretUpdateGroupResponseFromRaw>)
)]
public sealed record class SecretUpdateGroupResponse : JsonModel
{
    /// <summary>
    /// Number of new secrets created
    /// </summary>
    public double? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    /// <summary>
    /// Name of the secret group
    /// </summary>
    public string? Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

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

    /// <summary>
    /// Number of existing secrets updated
    /// </summary>
    public double? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Group;
        _ = this.Message;
        _ = this.Success;
        _ = this.Updated;
    }

    public SecretUpdateGroupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretUpdateGroupResponse(SecretUpdateGroupResponse secretUpdateGroupResponse)
        : base(secretUpdateGroupResponse) { }
#pragma warning restore CS8618

    public SecretUpdateGroupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretUpdateGroupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretUpdateGroupResponseFromRaw.FromRawUnchecked"/>
    public static SecretUpdateGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecretUpdateGroupResponseFromRaw : IFromRawJson<SecretUpdateGroupResponse>
{
    /// <inheritdoc/>
    public SecretUpdateGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecretUpdateGroupResponse.FromRawUnchecked(rawData);
}
