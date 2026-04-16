using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            AssigneeID = "assignee_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExitCriteria = ["string"],
            Instructions = "instructions",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItemUpdateParamsPriority.Low,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Draft,
            Title = "title",
            Type = WorkItemUpdateParamsType.Task,
        };

        string expectedID = "id";
        string expectedWorkItemID = "workItemId";
        string expectedAssigneeID = "assignee_id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedExitCriteria = ["string"];
        string expectedInstructions = "instructions";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, WorkItemUpdateParamsPriority> expectedPriority =
            WorkItemUpdateParamsPriority.Low;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedTitle = "title";
        ApiEnum<string, WorkItemUpdateParamsType> expectedType = WorkItemUpdateParamsType.Task;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
        Assert.Equal(expectedAssigneeID, parameters.AssigneeID);
        Assert.Equal(expectedCompletedAt, parameters.CompletedAt);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDueAt, parameters.DueAt);
        Assert.NotNull(parameters.ExitCriteria);
        Assert.Equal(expectedExitCriteria.Count, parameters.ExitCriteria.Count);
        for (int i = 0; i < expectedExitCriteria.Count; i++)
        {
            Assert.Equal(expectedExitCriteria[i], parameters.ExitCriteria[i]);
        }
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedPriority, parameters.Priority);
        Assert.Equal(expectedStartedAt, parameters.StartedAt);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            AssigneeID = "assignee_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            AssigneeID = "assignee_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Instructions = "instructions",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Description = null,
            ExitCriteria = null,
            Metadata = null,
            Priority = null,
            Status = null,
            Title = null,
            Type = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Description = "description",
            ExitCriteria = ["string"],
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItemUpdateParamsPriority.Low,
            Status = Status.Draft,
            Title = "title",
            Type = WorkItemUpdateParamsType.Task,
        };

        Assert.Null(parameters.AssigneeID);
        Assert.False(parameters.RawBodyData.ContainsKey("assignee_id"));
        Assert.Null(parameters.CompletedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("completed_at"));
        Assert.Null(parameters.DueAt);
        Assert.False(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.StartedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("started_at"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Description = "description",
            ExitCriteria = ["string"],
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItemUpdateParamsPriority.Low,
            Status = Status.Draft,
            Title = "title",
            Type = WorkItemUpdateParamsType.Task,

            AssigneeID = null,
            CompletedAt = null,
            DueAt = null,
            Instructions = null,
            StartedAt = null,
        };

        Assert.Null(parameters.AssigneeID);
        Assert.True(parameters.RawBodyData.ContainsKey("assignee_id"));
        Assert.Null(parameters.CompletedAt);
        Assert.True(parameters.RawBodyData.ContainsKey("completed_at"));
        Assert.Null(parameters.DueAt);
        Assert.True(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.Instructions);
        Assert.True(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.StartedAt);
        Assert.True(parameters.RawBodyData.ContainsKey("started_at"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkItemUpdateParams parameters = new() { ID = "id", WorkItemID = "workItemId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/matters/v1/id/work-items/workItemId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItemUpdateParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            AssigneeID = "assignee_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExitCriteria = ["string"],
            Instructions = "instructions",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItemUpdateParamsPriority.Low,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Draft,
            Title = "title",
            Type = WorkItemUpdateParamsType.Task,
        };

        WorkItemUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WorkItemUpdateParamsPriorityTest : TestBase
{
    [Theory]
    [InlineData(WorkItemUpdateParamsPriority.Low)]
    [InlineData(WorkItemUpdateParamsPriority.Normal)]
    [InlineData(WorkItemUpdateParamsPriority.High)]
    [InlineData(WorkItemUpdateParamsPriority.Urgent)]
    public void Validation_Works(WorkItemUpdateParamsPriority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItemUpdateParamsPriority> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsPriority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkItemUpdateParamsPriority.Low)]
    [InlineData(WorkItemUpdateParamsPriority.Normal)]
    [InlineData(WorkItemUpdateParamsPriority.High)]
    [InlineData(WorkItemUpdateParamsPriority.Urgent)]
    public void SerializationRoundtrip_Works(WorkItemUpdateParamsPriority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItemUpdateParamsPriority> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkItemUpdateParamsPriority>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsPriority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkItemUpdateParamsPriority>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Queued)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Blocked)]
    [InlineData(Status.InReview)]
    [InlineData(Status.AwaitingHuman)]
    [InlineData(Status.Done)]
    [InlineData(Status.Canceled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Queued)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Blocked)]
    [InlineData(Status.InReview)]
    [InlineData(Status.AwaitingHuman)]
    [InlineData(Status.Done)]
    [InlineData(Status.Canceled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WorkItemUpdateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(WorkItemUpdateParamsType.Task)]
    [InlineData(WorkItemUpdateParamsType.Deadline)]
    [InlineData(WorkItemUpdateParamsType.Review)]
    [InlineData(WorkItemUpdateParamsType.Filing)]
    [InlineData(WorkItemUpdateParamsType.Communication)]
    [InlineData(WorkItemUpdateParamsType.Research)]
    [InlineData(WorkItemUpdateParamsType.Drafting)]
    [InlineData(WorkItemUpdateParamsType.Collection)]
    [InlineData(WorkItemUpdateParamsType.Intake)]
    public void Validation_Works(WorkItemUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItemUpdateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkItemUpdateParamsType.Task)]
    [InlineData(WorkItemUpdateParamsType.Deadline)]
    [InlineData(WorkItemUpdateParamsType.Review)]
    [InlineData(WorkItemUpdateParamsType.Filing)]
    [InlineData(WorkItemUpdateParamsType.Communication)]
    [InlineData(WorkItemUpdateParamsType.Research)]
    [InlineData(WorkItemUpdateParamsType.Drafting)]
    [InlineData(WorkItemUpdateParamsType.Collection)]
    [InlineData(WorkItemUpdateParamsType.Intake)]
    public void SerializationRoundtrip_Works(WorkItemUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItemUpdateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItemUpdateParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
