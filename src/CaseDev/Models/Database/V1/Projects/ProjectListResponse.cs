using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;
using System = System;

namespace CaseDev.Models.Database.V1.Projects;

[JsonConverter(typeof(JsonModelConverter<ProjectListResponse, ProjectListResponseFromRaw>))]
public sealed record class ProjectListResponse : JsonModel
{
    public required IReadOnlyList<Project> Projects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Project>>("projects");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Project>>(
                "projects",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Projects)
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

    [SetsRequiredMembers]
    public ProjectListResponse(IReadOnlyList<Project> projects)
        : this()
    {
        this.Projects = projects;
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
    /// <summary>
    /// Project ID
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
    /// Total compute time consumed in seconds
    /// </summary>
    public double? ComputeTimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("computeTimeSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("computeTimeSeconds", value);
        }
    }

    /// <summary>
    /// Project creation timestamp
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
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
    /// Project description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Linked application deployments using this database
    /// </summary>
    public IReadOnlyList<ProjectLinkedDeployment>? LinkedDeployments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProjectLinkedDeployment>>(
                "linkedDeployments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProjectLinkedDeployment>?>(
                "linkedDeployments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Project name
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
    /// PostgreSQL major version
    /// </summary>
    public long? PgVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pgVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pgVersion", value);
        }
    }

    /// <summary>
    /// AWS region where database is deployed
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Current project status
    /// </summary>
    public ApiEnum<string, ProjectStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProjectStatus>>("status");
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
    /// Current storage usage in bytes
    /// </summary>
    public double? StorageSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("storageSizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storageSizeBytes", value);
        }
    }

    /// <summary>
    /// Project last update timestamp
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
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
        _ = this.ComputeTimeSeconds;
        _ = this.CreatedAt;
        _ = this.Description;
        foreach (var item in this.LinkedDeployments ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.PgVersion;
        _ = this.Region;
        this.Status?.Validate();
        _ = this.StorageSizeBytes;
        _ = this.UpdatedAt;
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

[JsonConverter(typeof(JsonModelConverter<ProjectLinkedDeployment, ProjectLinkedDeploymentFromRaw>))]
public sealed record class ProjectLinkedDeployment : JsonModel
{
    /// <summary>
    /// Deployment ID
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
    /// Deployment name
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
    /// Type of deployment
    /// </summary>
    public ApiEnum<string, ProjectLinkedDeploymentType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProjectLinkedDeploymentType>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Deployment URL (for Thurgood apps)
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Type?.Validate();
        _ = this.Url;
    }

    public ProjectLinkedDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectLinkedDeployment(ProjectLinkedDeployment projectLinkedDeployment)
        : base(projectLinkedDeployment) { }
#pragma warning restore CS8618

    public ProjectLinkedDeployment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectLinkedDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectLinkedDeploymentFromRaw.FromRawUnchecked"/>
    public static ProjectLinkedDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectLinkedDeploymentFromRaw : IFromRawJson<ProjectLinkedDeployment>
{
    /// <inheritdoc/>
    public ProjectLinkedDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectLinkedDeployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of deployment
/// </summary>
[JsonConverter(typeof(ProjectLinkedDeploymentTypeConverter))]
public enum ProjectLinkedDeploymentType
{
    Thurgood,
    Compute,
}

sealed class ProjectLinkedDeploymentTypeConverter : JsonConverter<ProjectLinkedDeploymentType>
{
    public override ProjectLinkedDeploymentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thurgood" => ProjectLinkedDeploymentType.Thurgood,
            "compute" => ProjectLinkedDeploymentType.Compute,
            _ => (ProjectLinkedDeploymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectLinkedDeploymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectLinkedDeploymentType.Thurgood => "thurgood",
                ProjectLinkedDeploymentType.Compute => "compute",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current project status
/// </summary>
[JsonConverter(typeof(ProjectStatusConverter))]
public enum ProjectStatus
{
    Active,
    Suspended,
    Deleted,
}

sealed class ProjectStatusConverter : JsonConverter<ProjectStatus>
{
    public override ProjectStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ProjectStatus.Active,
            "suspended" => ProjectStatus.Suspended,
            "deleted" => ProjectStatus.Deleted,
            _ => (ProjectStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectStatus.Active => "active",
                ProjectStatus.Suspended => "suspended",
                ProjectStatus.Deleted => "deleted",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
