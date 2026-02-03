using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;

namespace CaseDev.Models.Applications.V1.Projects;

[JsonConverter(typeof(JsonModelConverter<ProjectListResponse, ProjectListResponseFromRaw>))]
public sealed record class ProjectListResponse : JsonModel
{
    public IReadOnlyList<Project>? Projects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Project>>("projects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Project>?>(
                "projects",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Projects ?? [])
        {
            item.Validate();
        }
    }

    public ProjectListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectListResponse(ProjectListResponse projectListResponse)
        : base(projectListResponse) { }
#pragma warning restore CS8618

    public ProjectListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectListResponseFromRaw.FromRawUnchecked"/>
    public static ProjectListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectListResponseFromRaw : IFromRawJson<ProjectListResponse>
{
    /// <inheritdoc/>
    public ProjectListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProjectListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Project, ProjectFromRaw>))]
public sealed record class Project : JsonModel
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

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
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

    public IReadOnlyList<Domain>? Domains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Domain>>("domains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Domain>?>(
                "domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Framework
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("framework");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("framework", value);
        }
    }

    public string? GitBranch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gitBranch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gitBranch", value);
        }
    }

    public string? GitRepo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gitRepo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gitRepo", value);
        }
    }

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

    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updatedAt");
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

    public string? VercelProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vercelProjectId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vercelProjectId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.Domains ?? [])
        {
            item.Validate();
        }
        _ = this.Framework;
        _ = this.GitBranch;
        _ = this.GitRepo;
        _ = this.Name;
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.VercelProjectID;
    }

    public Project() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Project(Project project)
        : base(project) { }
#pragma warning restore CS8618

    public Project(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Project(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectFromRaw.FromRawUnchecked"/>
    public static Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectFromRaw : IFromRawJson<Project>
{
    /// <inheritdoc/>
    public Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Project.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Domain, DomainFromRaw>))]
public sealed record class Domain : JsonModel
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

    public string? DomainValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("domain", value);
        }
    }

    public bool? IsPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPrimary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPrimary", value);
        }
    }

    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DomainValue;
        _ = this.IsPrimary;
        _ = this.IsVerified;
    }

    public Domain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Domain(Domain domain)
        : base(domain) { }
#pragma warning restore CS8618

    public Domain(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Domain(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DomainFromRaw.FromRawUnchecked"/>
    public static Domain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DomainFromRaw : IFromRawJson<Domain>
{
    /// <inheritdoc/>
    public Domain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Domain.FromRawUnchecked(rawData);
}
