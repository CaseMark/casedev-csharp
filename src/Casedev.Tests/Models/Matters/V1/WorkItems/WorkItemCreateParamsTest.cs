using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using WorkItems = Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItems::WorkItemCreateParams
        {
            ID = "id",
            Title = "title",
            AssigneeID = "assignee_id",
            Description = "description",
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExitCriteria = ["string"],
            Instructions = "instructions",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItems::Priority.Low,
            Type = WorkItems::Type.Task,
        };

        string expectedID = "id";
        string expectedTitle = "title";
        string expectedAssigneeID = "assignee_id";
        string expectedDescription = "description";
        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedExitCriteria = ["string"];
        string expectedInstructions = "instructions";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, WorkItems::Priority> expectedPriority = WorkItems::Priority.Low;
        ApiEnum<string, WorkItems::Type> expectedType = WorkItems::Type.Task;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedAssigneeID, parameters.AssigneeID);
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
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItems::WorkItemCreateParams { ID = "id", Title = "title" };

        Assert.Null(parameters.AssigneeID);
        Assert.False(parameters.RawBodyData.ContainsKey("assignee_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DueAt);
        Assert.False(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkItems::WorkItemCreateParams
        {
            ID = "id",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            AssigneeID = null,
            Description = null,
            DueAt = null,
            ExitCriteria = null,
            Instructions = null,
            Metadata = null,
            Priority = null,
            Type = null,
        };

        Assert.Null(parameters.AssigneeID);
        Assert.False(parameters.RawBodyData.ContainsKey("assignee_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DueAt);
        Assert.False(parameters.RawBodyData.ContainsKey("due_at"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkItems::WorkItemCreateParams parameters = new() { ID = "id", Title = "title" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/id/work-items"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItems::WorkItemCreateParams
        {
            ID = "id",
            Title = "title",
            AssigneeID = "assignee_id",
            Description = "description",
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExitCriteria = ["string"],
            Instructions = "instructions",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Priority = WorkItems::Priority.Low,
            Type = WorkItems::Type.Task,
        };

        WorkItems::WorkItemCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PriorityTest : TestBase
{
    [Theory]
    [InlineData(WorkItems::Priority.Low)]
    [InlineData(WorkItems::Priority.Normal)]
    [InlineData(WorkItems::Priority.High)]
    [InlineData(WorkItems::Priority.Urgent)]
    public void Validation_Works(WorkItems::Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItems::Priority> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkItems::Priority.Low)]
    [InlineData(WorkItems::Priority.Normal)]
    [InlineData(WorkItems::Priority.High)]
    [InlineData(WorkItems::Priority.Urgent)]
    public void SerializationRoundtrip_Works(WorkItems::Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItems::Priority> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(WorkItems::Type.Task)]
    [InlineData(WorkItems::Type.Deadline)]
    [InlineData(WorkItems::Type.Review)]
    [InlineData(WorkItems::Type.Filing)]
    [InlineData(WorkItems::Type.Communication)]
    [InlineData(WorkItems::Type.Research)]
    [InlineData(WorkItems::Type.Drafting)]
    [InlineData(WorkItems::Type.Collection)]
    [InlineData(WorkItems::Type.Intake)]
    public void Validation_Works(WorkItems::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItems::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkItems::Type.Task)]
    [InlineData(WorkItems::Type.Deadline)]
    [InlineData(WorkItems::Type.Review)]
    [InlineData(WorkItems::Type.Filing)]
    [InlineData(WorkItems::Type.Communication)]
    [InlineData(WorkItems::Type.Research)]
    [InlineData(WorkItems::Type.Drafting)]
    [InlineData(WorkItems::Type.Collection)]
    [InlineData(WorkItems::Type.Intake)]
    public void SerializationRoundtrip_Works(WorkItems::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkItems::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkItems::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
