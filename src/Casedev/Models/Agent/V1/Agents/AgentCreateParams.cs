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

namespace Casedev.Models.Agent.V1.Agents;

/// <summary>
/// Creates a new agent definition with a scoped API key. The agent can then be used
/// to create and execute runs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// System instructions that define agent behavior
    /// </summary>
    public required string Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("instructions");
        }
        init { this._rawBodyData.Set("instructions", value); }
    }

    /// <summary>
    /// Display name for the agent
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Optional description of the agent
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Denylist of tools the agent cannot use
    /// </summary>
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

    /// <summary>
    /// Allowlist of tools the agent can use
    /// </summary>
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

    /// <summary>
    /// LLM model identifier (e.g. anthropic/claude-sonnet-4.6). Defaults to anthropic/claude-sonnet-4.6
    /// </summary>
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

    /// <summary>
    /// Custom sandbox configuration (cpu, memoryMiB)
    /// </summary>
    public Sandbox? Sandbox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Sandbox>("sandbox");
        }
        init { this._rawBodyData.Set("sandbox", value); }
    }

    /// <summary>
    /// Restrict agent to specific vault IDs
    /// </summary>
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

    public AgentCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentCreateParams(AgentCreateParams agentCreateParams)
        : base(agentCreateParams)
    {
        this._rawBodyData = new(agentCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentCreateParams(
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
    AgentCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AgentCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AgentCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/agent/v1/agents")
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

/// <summary>
/// Custom sandbox configuration (cpu, memoryMiB)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sandbox, SandboxFromRaw>))]
public sealed record class Sandbox : JsonModel
{
    /// <summary>
    /// Number of CPUs
    /// </summary>
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

    /// <summary>
    /// Memory in MiB
    /// </summary>
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
