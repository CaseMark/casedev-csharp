using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Database.V1.Projects;

[JsonConverter(typeof(JsonModelConverter<ProjectDeleteResponse, ProjectDeleteResponseFromRaw>))]
public sealed record class ProjectDeleteResponse : JsonModel
{
    /// <summary>
    /// Confirmation message
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Deletion success indicator
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public ProjectDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectDeleteResponse(ProjectDeleteResponse projectDeleteResponse)
        : base(projectDeleteResponse) { }
#pragma warning restore CS8618

    public ProjectDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ProjectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectDeleteResponseFromRaw : IFromRawJson<ProjectDeleteResponse>
{
    /// <inheritdoc/>
    public ProjectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectDeleteResponse.FromRawUnchecked(rawData);
}
