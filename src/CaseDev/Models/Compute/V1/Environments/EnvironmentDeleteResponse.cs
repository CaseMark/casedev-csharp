using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Compute.V1.Environments;

[JsonConverter(typeof(ModelConverter<EnvironmentDeleteResponse, EnvironmentDeleteResponseFromRaw>))]
public sealed record class EnvironmentDeleteResponse : ModelBase
{
    public required string Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CasedevInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
                );
        }
        init
        {
            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool Success
    {
        get
        {
            if (!this._rawData.TryGetValue("success", out JsonElement element))
                throw new CasedevInvalidDataException(
                    "'success' cannot be null",
                    new ArgumentOutOfRangeException("success", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["success"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public EnvironmentDeleteResponse() { }

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

    public static EnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentDeleteResponseFromRaw : IFromRaw<EnvironmentDeleteResponse>
{
    public EnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentDeleteResponse.FromRawUnchecked(rawData);
}
