using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V2.Execute;

/// <summary>
/// Creates an ephemeral agent and immediately executes a v2 run on the Daytona runtime.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExecuteCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Prompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("prompt");
        }
        init { this._rawBodyData.Set("prompt", value); }
    }

    public IReadOnlyList<string>? DisabledTools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("disabledTools");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "disabledTools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? EnabledTools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("enabledTools");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "enabledTools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Guidance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("guidance");
        }
        init { this._rawBodyData.Set("guidance", value); }
    }

    public string? Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instructions", value);
        }
    }

    public string? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    public IReadOnlyList<string>? ObjectIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("objectIds");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "objectIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Sandbox? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Sandbox>("sandbox");
        }
        init { this._rawBodyData.Set("sandbox", value); }
    }

    public IReadOnlyList<string>? VaultIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("vaultIds");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "vaultIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ExecuteCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecuteCreateParams(ExecuteCreateParams executeCreateParams)
        : base(executeCreateParams)
    {
        this._rawBodyData = new(executeCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExecuteCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecuteCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExecuteCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExecuteCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/agent/v2/execute")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<Sandbox, SandboxFromRaw>))]
public sealed record class Sandbox : JsonModel
{
    public long? Cpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cpu", value);
        }
    }

    public long? MemoryMiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("memoryMiB");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memoryMiB", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cpu;
        _ = this.MemoryMiB;
    }

    public Sandbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sandbox(Sandbox sandbox)
        : base(sandbox) { }
#pragma warning restore CS8618

    public Sandbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Sandbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxFromRaw.FromRawUnchecked"/>
    public static Sandbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SandboxFromRaw : IFromRawJson<Sandbox>
{
    /// <inheritdoc/>
    public Sandbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Sandbox.FromRawUnchecked(rawData);
}
