using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Projects.V1;

[JsonConverter(typeof(JsonModelConverter<V1ListResponse, V1ListResponseFromRaw>))]
public sealed record class V1ListResponse : JsonModel
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

    public V1ListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1ListResponse(V1ListResponse v1ListResponse)
        : base(v1ListResponse) { }
#pragma warning restore CS8618

    public V1ListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1ListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1ListResponseFromRaw.FromRawUnchecked"/>
    public static V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V1ListResponseFromRaw : IFromRawJson<V1ListResponse>
{
    /// <inheritdoc/>
    public V1ListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V1ListResponse.FromRawUnchecked(rawData);
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

    public string? Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slug");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    public ApiEnum<string, ProjectSourceType>? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProjectSourceType>>("sourceType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Framework;
        _ = this.Name;
        _ = this.Slug;
        this.SourceType?.Validate();
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

[JsonConverter(typeof(ProjectSourceTypeConverter))]
public enum ProjectSourceType
{
    GitHub,
    Thurgood,
}

sealed class ProjectSourceTypeConverter : JsonConverter<ProjectSourceType>
{
    public override ProjectSourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github" => ProjectSourceType.GitHub,
            "thurgood" => ProjectSourceType.Thurgood,
            _ => (ProjectSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProjectSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProjectSourceType.GitHub => "github",
                ProjectSourceType.Thurgood => "thurgood",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
