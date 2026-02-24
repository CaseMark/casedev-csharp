using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Compute.V1.Environments;

[JsonConverter(
    typeof(JsonModelConverter<EnvironmentDeleteResponse, EnvironmentDeleteResponseFromRaw>)
)]
public sealed record class EnvironmentDeleteResponse : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public EnvironmentDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvironmentDeleteResponse(EnvironmentDeleteResponse environmentDeleteResponse)
        : base(environmentDeleteResponse) { }
#pragma warning restore CS8618

    public EnvironmentDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentDeleteResponseFromRaw.FromRawUnchecked"/>
    public static EnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentDeleteResponseFromRaw : IFromRawJson<EnvironmentDeleteResponse>
{
    /// <inheritdoc/>
    public EnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentDeleteResponse.FromRawUnchecked(rawData);
}
