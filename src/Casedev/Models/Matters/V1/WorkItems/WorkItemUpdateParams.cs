using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;
using System = System;

namespace Casedev.Models.Matters.V1.WorkItems;

/// <summary>
/// Update a matter work item.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkItemUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public string? WorkItemID { get; init; }

    public string? AssigneeID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("assignee_id");
        }
        init { this._rawBodyData.Set("assignee_id", value); }
    }

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("completed_at");
        }
        init { this._rawBodyData.Set("completed_at", value); }
    }

    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    public System::DateTimeOffset? DueAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("due_at");
        }
        init { this._rawBodyData.Set("due_at", value); }
    }

    public IReadOnlyList<string>? ExitCriteria
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("exit_criteria");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "exit_criteria",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instructions");
        }
        init { this._rawBodyData.Set("instructions", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, WorkItemUpdateParamsPriority>? Priority
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, WorkItemUpdateParamsPriority>
            >("priority");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("priority", value);
        }
    }

    public System::DateTimeOffset? StartedAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("started_at");
        }
        init { this._rawBodyData.Set("started_at", value); }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("title", value);
        }
    }

    public ApiEnum<string, WorkItemUpdateParamsType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WorkItemUpdateParamsType>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    public WorkItemUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkItemUpdateParams(WorkItemUpdateParams workItemUpdateParams)
        : base(workItemUpdateParams)
    {
        this.ID = workItemUpdateParams.ID;
        this.WorkItemID = workItemUpdateParams.WorkItemID;

        this._rawBodyData = new(workItemUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkItemUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkItemUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id,
        string workItemID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
        this.WorkItemID = workItemID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkItemUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id,
        string workItemID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id,
            workItemID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["WorkItemID"] = JsonSerializer.SerializeToElement(this.WorkItemID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WorkItemUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.WorkItemID?.Equals(other.WorkItemID) ?? other.WorkItemID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/matters/v1/{0}/work-items/{1}", this.ID, this.WorkItemID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(WorkItemUpdateParamsPriorityConverter))]
public enum WorkItemUpdateParamsPriority
{
    Low,
    Normal,
    High,
    Urgent,
}

sealed class WorkItemUpdateParamsPriorityConverter : JsonConverter<WorkItemUpdateParamsPriority>
{
    public override WorkItemUpdateParamsPriority Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => WorkItemUpdateParamsPriority.Low,
            "normal" => WorkItemUpdateParamsPriority.Normal,
            "high" => WorkItemUpdateParamsPriority.High,
            "urgent" => WorkItemUpdateParamsPriority.Urgent,
            _ => (WorkItemUpdateParamsPriority)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkItemUpdateParamsPriority value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkItemUpdateParamsPriority.Low => "low",
                WorkItemUpdateParamsPriority.Normal => "normal",
                WorkItemUpdateParamsPriority.High => "high",
                WorkItemUpdateParamsPriority.Urgent => "urgent",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Queued,
    InProgress,
    Blocked,
    InReview,
    AwaitingHuman,
    Done,
    Canceled,
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
            "draft" => Status.Draft,
            "queued" => Status.Queued,
            "in_progress" => Status.InProgress,
            "blocked" => Status.Blocked,
            "in_review" => Status.InReview,
            "awaiting_human" => Status.AwaitingHuman,
            "done" => Status.Done,
            "canceled" => Status.Canceled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Queued => "queued",
                Status.InProgress => "in_progress",
                Status.Blocked => "blocked",
                Status.InReview => "in_review",
                Status.AwaitingHuman => "awaiting_human",
                Status.Done => "done",
                Status.Canceled => "canceled",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(WorkItemUpdateParamsTypeConverter))]
public enum WorkItemUpdateParamsType
{
    Task,
    Deadline,
    Review,
    Filing,
    Communication,
    Research,
    Drafting,
    Collection,
    Intake,
}

sealed class WorkItemUpdateParamsTypeConverter : JsonConverter<WorkItemUpdateParamsType>
{
    public override WorkItemUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "task" => WorkItemUpdateParamsType.Task,
            "deadline" => WorkItemUpdateParamsType.Deadline,
            "review" => WorkItemUpdateParamsType.Review,
            "filing" => WorkItemUpdateParamsType.Filing,
            "communication" => WorkItemUpdateParamsType.Communication,
            "research" => WorkItemUpdateParamsType.Research,
            "drafting" => WorkItemUpdateParamsType.Drafting,
            "collection" => WorkItemUpdateParamsType.Collection,
            "intake" => WorkItemUpdateParamsType.Intake,
            _ => (WorkItemUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkItemUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkItemUpdateParamsType.Task => "task",
                WorkItemUpdateParamsType.Deadline => "deadline",
                WorkItemUpdateParamsType.Review => "review",
                WorkItemUpdateParamsType.Filing => "filing",
                WorkItemUpdateParamsType.Communication => "communication",
                WorkItemUpdateParamsType.Research => "research",
                WorkItemUpdateParamsType.Drafting => "drafting",
                WorkItemUpdateParamsType.Collection => "collection",
                WorkItemUpdateParamsType.Intake => "intake",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
