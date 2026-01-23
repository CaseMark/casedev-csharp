using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Secrets;

[JsonConverter(
    typeof(JsonModelConverter<SecretDeleteGroupResponse, SecretDeleteGroupResponseFromRaw>)
)]
public sealed record class SecretDeleteGroupResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public SecretDeleteGroupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretDeleteGroupResponse(SecretDeleteGroupResponse secretDeleteGroupResponse)
        : base(secretDeleteGroupResponse) { }
#pragma warning restore CS8618

    public SecretDeleteGroupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretDeleteGroupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretDeleteGroupResponseFromRaw.FromRawUnchecked"/>
    public static SecretDeleteGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecretDeleteGroupResponseFromRaw : IFromRawJson<SecretDeleteGroupResponse>
{
    /// <inheritdoc/>
    public SecretDeleteGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecretDeleteGroupResponse.FromRawUnchecked(rawData);
}
