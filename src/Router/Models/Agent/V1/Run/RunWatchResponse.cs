using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Agent.V1.Run;

[JsonConverter(typeof(JsonModelConverter<RunWatchResponse, RunWatchResponseFromRaw>))]
public sealed record class RunWatchResponse : JsonModel
{
    public string? CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callbackUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callbackUrl", value);
        }
    }

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
        _ = this.CallbackUrl;
        _ = this.Ok;
    }

    public RunWatchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunWatchResponse(RunWatchResponse runWatchResponse)
        : base(runWatchResponse) { }
#pragma warning restore CS8618

    public RunWatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunWatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunWatchResponseFromRaw.FromRawUnchecked"/>
    public static RunWatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunWatchResponseFromRaw : IFromRawJson<RunWatchResponse>
{
    /// <inheritdoc/>
    public RunWatchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunWatchResponse.FromRawUnchecked(rawData);
}
