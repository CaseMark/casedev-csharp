using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1.Environments;

[JsonConverter(typeof(ModelConverter<EnvironmentDeleteResponse, EnvironmentDeleteResponseFromRaw>))]
public sealed record class EnvironmentDeleteResponse : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public required bool Success
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "success"); }
        init { ModelBase.Set(this._rawData, "success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public EnvironmentDeleteResponse() { }

    public EnvironmentDeleteResponse(EnvironmentDeleteResponse environmentDeleteResponse)
        : base(environmentDeleteResponse) { }

    public EnvironmentDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class EnvironmentDeleteResponseFromRaw : IFromRaw<EnvironmentDeleteResponse>
{
    /// <inheritdoc/>
    public EnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentDeleteResponse.FromRawUnchecked(rawData);
}
