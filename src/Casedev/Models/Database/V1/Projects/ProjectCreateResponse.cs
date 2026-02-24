using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Database.V1.Projects;

[JsonConverter(typeof(JsonModelConverter<ProjectCreateResponse, ProjectCreateResponseFromRaw>))]
public sealed record class ProjectCreateResponse : JsonModel
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
    /// Default 'main' branch details
    /// </summary>
    public required DefaultBranch DefaultBranch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DefaultBranch>("defaultBranch");
        }
        init { this._rawData.Set("defaultBranch", value); }
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.CreatedAt;
        this.DefaultBranch.Validate();
        _ = this.Name;
        _ = this.PgVersion;
        _ = this.Region;
        this.Status.Validate();
        _ = this.Description;
    }

    public ProjectCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectCreateResponse(ProjectCreateResponse projectCreateResponse)
        : base(projectCreateResponse) { }
#pragma warning restore CS8618

    public ProjectCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectCreateResponseFromRaw.FromRawUnchecked"/>
    public static ProjectCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectCreateResponseFromRaw : IFromRawJson<ProjectCreateResponse>
{
    /// <inheritdoc/>
    public ProjectCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Default 'main' branch details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DefaultBranch, DefaultBranchFromRaw>))]
public sealed record class DefaultBranch : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public DefaultBranch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultBranch(DefaultBranch defaultBranch)
        : base(defaultBranch) { }
#pragma warning restore CS8618

    public DefaultBranch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultBranch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultBranchFromRaw.FromRawUnchecked"/>
    public static DefaultBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultBranchFromRaw : IFromRawJson<DefaultBranch>
{
    /// <inheritdoc/>
    public DefaultBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DefaultBranch.FromRawUnchecked(rawData);
}

/// <summary>
/// Project status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Suspended,
    Deleted,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "suspended" => Status.Suspended,
            "deleted" => Status.Deleted,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Suspended => "suspended",
                Status.Deleted => "deleted",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
