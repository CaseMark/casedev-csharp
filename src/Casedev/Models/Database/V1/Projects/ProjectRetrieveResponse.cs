using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Database.V1.Projects;

[JsonConverter(typeof(JsonModelConverter<ProjectRetrieveResponse, ProjectRetrieveResponseFromRaw>))]
public sealed record class ProjectRetrieveResponse : JsonModel
{
    /// <summary>
    /// Project ID
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
    /// All branches in this project
    /// </summary>
    public required IReadOnlyList<Branch> Branches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Branch>>("branches");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Branch>>(
                "branches",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total compute time consumed in seconds
    /// </summary>
    public required double ComputeTimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("computeTimeSeconds");
        }
        init { this._rawData.Set("computeTimeSeconds", value); }
    }

    /// <summary>
    /// Database connection hostname (masked for security)
    /// </summary>
    public required string ConnectionHost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connectionHost");
        }
        init { this._rawData.Set("connectionHost", value); }
    }

    /// <summary>
    /// Project creation timestamp
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Databases in the default branch
    /// </summary>
    public required IReadOnlyList<ProjectRetrieveResponseDatabase> Databases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProjectRetrieveResponseDatabase>>(
                "databases"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProjectRetrieveResponseDatabase>>(
                "databases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Linked deployments using this database
    /// </summary>
    public required IReadOnlyList<LinkedDeployment> LinkedDeployments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LinkedDeployment>>(
                "linkedDeployments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<LinkedDeployment>>(
                "linkedDeployments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Project name
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
    /// PostgreSQL major version
    /// </summary>
    public required long PgVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pgVersion");
        }
        init { this._rawData.Set("pgVersion", value); }
    }

    /// <summary>
    /// AWS region
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Project status
    /// </summary>
    public required ApiEnum<string, ProjectRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProjectRetrieveResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Current storage usage in bytes
    /// </summary>
    public required double StorageSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("storageSizeBytes");
        }
        init { this._rawData.Set("storageSizeBytes", value); }
    }

    /// <summary>
    /// Project last update timestamp
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Branches)
        {
            item.Validate();
        }
        _ = this.ComputeTimeSeconds;
        _ = this.ConnectionHost;
        _ = this.CreatedAt;
        foreach (var item in this.Databases)
        {
            item.Validate();
        }
        foreach (var item in this.LinkedDeployments)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.PgVersion;
        _ = this.Region;
        this.Status.Validate();
        _ = this.StorageSizeBytes;
        _ = this.UpdatedAt;
        _ = this.Description;
    }

    public ProjectRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectRetrieveResponse(ProjectRetrieveResponse projectRetrieveResponse)
        : base(projectRetrieveResponse) { }
#pragma warning restore CS8618

    public ProjectRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProjectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectRetrieveResponseFromRaw : IFromRawJson<ProjectRetrieveResponse>
{
    /// <inheritdoc/>
    public ProjectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Branch, BranchFromRaw>))]
public sealed record class Branch : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.IsDefault;
        _ = this.Name;
        _ = this.Status;
    }

    public Branch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Branch(Branch branch)
        : base(branch) { }
#pragma warning restore CS8618

    public Branch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Branch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BranchFromRaw.FromRawUnchecked"/>
    public static Branch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BranchFromRaw : IFromRawJson<Branch>
{
    /// <inheritdoc/>
    public Branch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Branch.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ProjectRetrieveResponseDatabase,
        ProjectRetrieveResponseDatabaseFromRaw
    >)
)]
public sealed record class ProjectRetrieveResponseDatabase : JsonModel
{
    /// <summary>
    /// Database ID
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
    /// Database name
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
    /// Database owner role name
    /// </summary>
    public string? OwnerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ownerName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownerName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.OwnerName;
    }

    public ProjectRetrieveResponseDatabase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectRetrieveResponseDatabase(
        ProjectRetrieveResponseDatabase projectRetrieveResponseDatabase
    )
        : base(projectRetrieveResponseDatabase) { }
#pragma warning restore CS8618

    public ProjectRetrieveResponseDatabase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectRetrieveResponseDatabase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectRetrieveResponseDatabaseFromRaw.FromRawUnchecked"/>
    public static ProjectRetrieveResponseDatabase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectRetrieveResponseDatabaseFromRaw : IFromRawJson<ProjectRetrieveResponseDatabase>
{
    /// <inheritdoc/>
    public ProjectRetrieveResponseDatabase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectRetrieveResponseDatabase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LinkedDeployment, LinkedDeploymentFromRaw>))]
public sealed record class LinkedDeployment : JsonModel
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
    /// Environment variable name for connection string
    /// </summary>
    public string? EnvVarName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("envVarName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("envVarName", value);
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
    /// Deployment type
    /// </summary>
    public ApiEnum<string, global::Casedev.Models.Database.V1.Projects.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Casedev.Models.Database.V1.Projects.Type>
            >("type");
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
    /// Deployment URL
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
        _ = this.EnvVarName;
        _ = this.Name;
        this.Type?.Validate();
        _ = this.Url;
    }

    public LinkedDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedDeployment(LinkedDeployment linkedDeployment)
        : base(linkedDeployment) { }
#pragma warning restore CS8618

    public LinkedDeployment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedDeploymentFromRaw.FromRawUnchecked"/>
    public static LinkedDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedDeploymentFromRaw : IFromRawJson<LinkedDeployment>
{
    /// <inheritdoc/>
    public LinkedDeployment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkedDeployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Deployment type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Thurgood,
    Compute,
}

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Database.V1.Projects.Type>
{
    public override global::Casedev.Models.Database.V1.Projects.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thurgood" => global::Casedev.Models.Database.V1.Projects.Type.Thurgood,
            "compute" => global::Casedev.Models.Database.V1.Projects.Type.Compute,
            _ => (global::Casedev.Models.Database.V1.Projects.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Database.V1.Projects.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Database.V1.Projects.Type.Thurgood => "thurgood",
                global::Casedev.Models.Database.V1.Projects.Type.Compute => "compute",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Project status
/// </summary>
[JsonConverter(typeof(ProjectRetrieveResponseStatusConverter))]
public enum ProjectRetrieveResponseStatus
{
    Active,
    Suspended,
    Deleted,
}

sealed class ProjectRetrieveResponseStatusConverter : JsonConverter<ProjectRetrieveResponseStatus>
{
    public override ProjectRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ProjectRetrieveResponseStatus.Active,
            "suspended" => ProjectRetrieveResponseStatus.Suspended,
            "deleted" => ProjectRetrieveResponseStatus.Deleted,
            _ => (ProjectRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectRetrieveResponseStatus.Active => "active",
                ProjectRetrieveResponseStatus.Suspended => "suspended",
                ProjectRetrieveResponseStatus.Deleted => "deleted",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
