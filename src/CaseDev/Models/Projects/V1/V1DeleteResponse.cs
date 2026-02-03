using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Projects.V1;

[JsonConverter(typeof(JsonModelConverter<V1DeleteResponse, V1DeleteResponseFromRaw>))]
public sealed record class V1DeleteResponse : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public double? DeploymentsDeleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("deploymentsDeleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deploymentsDeleted", value);
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

    public ResourcesDeleted? ResourcesDeleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResourcesDeleted>("resourcesDeleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resourcesDeleted", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DeploymentsDeleted;
        _ = this.Message;
        this.ResourcesDeleted?.Validate();
        _ = this.Status;
    }

    public V1DeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1DeleteResponse(V1DeleteResponse v1DeleteResponse)
        : base(v1DeleteResponse) { }
#pragma warning restore CS8618

    public V1DeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1DeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1DeleteResponseFromRaw.FromRawUnchecked"/>
    public static V1DeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1DeleteResponseFromRaw : IFromRawJson<V1DeleteResponse>
{
    /// <inheritdoc/>
    public V1DeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1DeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ResourcesDeleted, ResourcesDeletedFromRaw>))]
public sealed record class ResourcesDeleted : JsonModel
{
    public double? Bundles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bundles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bundles", value);
        }
    }

    public double? CodeBuild
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("codeBuild");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("codeBuild", value);
        }
    }

    public double? RoutingEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("routingEntries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("routingEntries", value);
        }
    }

    public double? S3Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("s3Sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3Sources", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bundles;
        _ = this.CodeBuild;
        _ = this.RoutingEntries;
        _ = this.S3Sources;
    }

    public ResourcesDeleted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResourcesDeleted(ResourcesDeleted resourcesDeleted)
        : base(resourcesDeleted) { }
#pragma warning restore CS8618

    public ResourcesDeleted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResourcesDeleted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResourcesDeletedFromRaw.FromRawUnchecked"/>
    public static ResourcesDeleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResourcesDeletedFromRaw : IFromRawJson<ResourcesDeleted>
{
    /// <inheritdoc/>
    public ResourcesDeleted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResourcesDeleted.FromRawUnchecked(rawData);
}
