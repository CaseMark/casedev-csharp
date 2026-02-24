using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Database.V1.Projects;

[JsonConverter(
    typeof(JsonModelConverter<ProjectListBranchesResponse, ProjectListBranchesResponseFromRaw>)
)]
public sealed record class ProjectListBranchesResponse : JsonModel
{
    public required IReadOnlyList<ProjectListBranchesResponseBranch> Branches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ProjectListBranchesResponseBranch>
            >("branches");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProjectListBranchesResponseBranch>>(
                "branches",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Branches)
        {
            item.Validate();
        }
    }

    public ProjectListBranchesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectListBranchesResponse(ProjectListBranchesResponse projectListBranchesResponse)
        : base(projectListBranchesResponse) { }
#pragma warning restore CS8618

    public ProjectListBranchesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectListBranchesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectListBranchesResponseFromRaw.FromRawUnchecked"/>
    public static ProjectListBranchesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProjectListBranchesResponse(IReadOnlyList<ProjectListBranchesResponseBranch> branches)
        : this()
    {
        this.Branches = branches;
    }
}

class ProjectListBranchesResponseFromRaw : IFromRawJson<ProjectListBranchesResponse>
{
    /// <inheritdoc/>
    public ProjectListBranchesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectListBranchesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProjectListBranchesResponseBranch,
        ProjectListBranchesResponseBranchFromRaw
    >)
)]
public sealed record class ProjectListBranchesResponseBranch : JsonModel
{
    /// <summary>
    /// Branch ID
    /// </summary>
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

    /// <summary>
    /// Branch creation timestamp
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Whether this is the default branch
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isDefault");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isDefault", value);
        }
    }

    /// <summary>
    /// Branch name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Parent branch ID (null for default branch)
    /// </summary>
    public string? ParentBranchID
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

    /// <summary>
    /// Branch last update timestamp
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
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
        _ = this.UpdatedAt;
    }

    public ProjectListBranchesResponseBranch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectListBranchesResponseBranch(
        ProjectListBranchesResponseBranch projectListBranchesResponseBranch
    )
        : base(projectListBranchesResponseBranch) { }
#pragma warning restore CS8618

    public ProjectListBranchesResponseBranch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectListBranchesResponseBranch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectListBranchesResponseBranchFromRaw.FromRawUnchecked"/>
    public static ProjectListBranchesResponseBranch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectListBranchesResponseBranchFromRaw : IFromRawJson<ProjectListBranchesResponseBranch>
{
    /// <inheritdoc/>
    public ProjectListBranchesResponseBranch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectListBranchesResponseBranch.FromRawUnchecked(rawData);
}
