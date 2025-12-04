using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Compute.V1;

[JsonConverter(typeof(ModelConverter<V1DeployResponse, V1DeployResponseFromRaw>))]
public sealed record class V1DeployResponse : ModelBase
{
    /// <summary>
    /// Deployment timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Unique deployment identifier
    /// </summary>
    public string? DeploymentID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "deploymentId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "deploymentId", value);
        }
    }

    /// <summary>
    /// Environment name
    /// </summary>
    public string? Environment
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "environment"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "environment", value);
        }
    }

    /// <summary>
    /// Runtime used
    /// </summary>
    public string? Runtime
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "runtime"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "runtime", value);
        }
    }

    /// <summary>
    /// Deployment status
    /// </summary>
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Service endpoint URL (for web services)
    /// </summary>
    public string? URL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.DeploymentID;
        _ = this.Environment;
        _ = this.Runtime;
        _ = this.Status;
        _ = this.URL;
    }

    public V1DeployResponse() { }

    public V1DeployResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeployResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DeployResponseFromRaw.FromRawUnchecked"/>
    public static V1DeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DeployResponseFromRaw : IFromRaw<V1DeployResponse>
{
    /// <inheritdoc/>
    public V1DeployResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeployResponse.FromRawUnchecked(rawData);
}
