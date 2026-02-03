using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Database.V1.Projects;

[JsonConverter(
    typeof(JsonModelConverter<ProjectGetConnectionResponse, ProjectGetConnectionResponseFromRaw>)
)]
public sealed record class ProjectGetConnectionResponse : JsonModel
{
    /// <summary>
    /// Branch name for this connection
    /// </summary>
    public required string Branch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("branch");
        }
        init { this._rawData.Set("branch", value); }
    }

    /// <summary>
    /// PostgreSQL connection string (includes credentials)
    /// </summary>
    public required string ConnectionUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connectionUri");
        }
        init { this._rawData.Set("connectionUri", value); }
    }

    /// <summary>
    /// Whether this is a pooled connection
    /// </summary>
    public required bool Pooled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("pooled");
        }
        init { this._rawData.Set("pooled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Branch;
        _ = this.ConnectionUri;
        _ = this.Pooled;
    }

    public ProjectGetConnectionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectGetConnectionResponse(ProjectGetConnectionResponse projectGetConnectionResponse)
        : base(projectGetConnectionResponse) { }
#pragma warning restore CS8618

    public ProjectGetConnectionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectGetConnectionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectGetConnectionResponseFromRaw.FromRawUnchecked"/>
    public static ProjectGetConnectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectGetConnectionResponseFromRaw : IFromRawJson<ProjectGetConnectionResponse>
{
    /// <inheritdoc/>
    public ProjectGetConnectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectGetConnectionResponse.FromRawUnchecked(rawData);
}
