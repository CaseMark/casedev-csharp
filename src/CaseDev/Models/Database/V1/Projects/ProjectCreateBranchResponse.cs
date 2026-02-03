using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Database.V1.Projects;

[JsonConverter(
    typeof(JsonModelConverter<ProjectCreateBranchResponse, ProjectCreateBranchResponseFromRaw>)
)]
public sealed record class ProjectCreateBranchResponse : JsonModel
{
    /// <summary>
    /// Branch ID
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Branch creation timestamp
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Whether this is the default branch (always false for new branches)
    /// </summary>
    public required bool IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isDefault");
        }
        init { this._rawData.Set("isDefault", value); }
    }

    /// <summary>
    /// Branch name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Parent branch ID
    /// </summary>
    public required string? ParentBranchID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parentBranchId");
        }
        init { this._rawData.Set("parentBranchId", value); }
    }

    /// <summary>
    /// Branch status
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.IsDefault;
        _ = this.Name;
        _ = this.ParentBranchID;
        _ = this.Status;
    }

    public ProjectCreateBranchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateBranchResponse(ProjectCreateBranchResponse projectCreateBranchResponse)
        : base(projectCreateBranchResponse) { }
#pragma warning restore CS8618

    public ProjectCreateBranchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectCreateBranchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectCreateBranchResponseFromRaw.FromRawUnchecked"/>
    public static ProjectCreateBranchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectCreateBranchResponseFromRaw : IFromRawJson<ProjectCreateBranchResponse>
{
    /// <inheritdoc/>
    public ProjectCreateBranchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectCreateBranchResponse.FromRawUnchecked(rawData);
}
