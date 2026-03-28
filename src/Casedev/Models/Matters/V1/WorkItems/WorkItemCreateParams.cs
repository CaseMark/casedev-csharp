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
/// Create an active work item on a matter.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkItemCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required string Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("title");
        }
        init { this._rawBodyData.Set("title", value); }
    }

    public string? AssigneeID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("assignee_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("assignee_id", value);
        }
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("due_at", value);
        }
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instructions", value);
        }
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

    public ApiEnum<string, Priority>? Priority
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Priority>>("priority");
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

    public ApiEnum<string, global::Casedev.Models.Matters.V1.WorkItems.Type>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, global::Casedev.Models.Matters.V1.WorkItems.Type>
            >("type");
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

    public WorkItemCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkItemCreateParams(WorkItemCreateParams workItemCreateParams)
        : base(workItemCreateParams)
    {
        this.ID = workItemCreateParams.ID;

        this._rawBodyData = new(workItemCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WorkItemCreateParams(
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
    WorkItemCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkItemCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(WorkItemCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/matters/v1/{0}/work-items", this.ID)
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

[JsonConverter(typeof(PriorityConverter))]
public enum Priority
{
    Low,
    Normal,
    High,
    Urgent,
}

sealed class PriorityConverter : JsonConverter<Priority>
{
    public override Priority Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => Priority.Low,
            "normal" => Priority.Normal,
            "high" => Priority.High,
            "urgent" => Priority.Urgent,
            _ => (Priority)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Priority value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Priority.Low => "low",
                Priority.Normal => "normal",
                Priority.High => "high",
                Priority.Urgent => "urgent",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
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

sealed class TypeConverter : JsonConverter<global::Casedev.Models.Matters.V1.WorkItems.Type>
{
    public override global::Casedev.Models.Matters.V1.WorkItems.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "task" => global::Casedev.Models.Matters.V1.WorkItems.Type.Task,
            "deadline" => global::Casedev.Models.Matters.V1.WorkItems.Type.Deadline,
            "review" => global::Casedev.Models.Matters.V1.WorkItems.Type.Review,
            "filing" => global::Casedev.Models.Matters.V1.WorkItems.Type.Filing,
            "communication" => global::Casedev.Models.Matters.V1.WorkItems.Type.Communication,
            "research" => global::Casedev.Models.Matters.V1.WorkItems.Type.Research,
            "drafting" => global::Casedev.Models.Matters.V1.WorkItems.Type.Drafting,
            "collection" => global::Casedev.Models.Matters.V1.WorkItems.Type.Collection,
            "intake" => global::Casedev.Models.Matters.V1.WorkItems.Type.Intake,
            _ => (global::Casedev.Models.Matters.V1.WorkItems.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Casedev.Models.Matters.V1.WorkItems.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Casedev.Models.Matters.V1.WorkItems.Type.Task => "task",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Deadline => "deadline",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Review => "review",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Filing => "filing",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Communication => "communication",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Research => "research",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Drafting => "drafting",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Collection => "collection",
                global::Casedev.Models.Matters.V1.WorkItems.Type.Intake => "intake",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
