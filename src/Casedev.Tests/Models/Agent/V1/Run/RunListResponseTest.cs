using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            NextCursor = "nextCursor",
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";
        List<RunListResponseRun> expectedRuns =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Model = "model",
                Prompt = "prompt",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = RunListResponseRunStatus.Queued,
            },
        ];

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.NotNull(model.Runs);
        Assert.Equal(expectedRuns.Count, model.Runs.Count);
        for (int i = 0; i < expectedRuns.Count; i++)
        {
            Assert.Equal(expectedRuns[i], model.Runs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            NextCursor = "nextCursor",
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            NextCursor = "nextCursor",
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";
        List<RunListResponseRun> expectedRuns =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Model = "model",
                Prompt = "prompt",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = RunListResponseRunStatus.Queued,
            },
        ];

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.NotNull(deserialized.Runs);
        Assert.Equal(expectedRuns.Count, deserialized.Runs.Count);
        for (int i = 0; i < expectedRuns.Count; i++)
        {
            Assert.Equal(expectedRuns[i], deserialized.Runs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            NextCursor = "nextCursor",
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunListResponse { NextCursor = "nextCursor" };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("hasMore"));
        Assert.Null(model.Runs);
        Assert.False(model.RawData.ContainsKey("runs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunListResponse { NextCursor = "nextCursor" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunListResponse
        {
            NextCursor = "nextCursor",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Runs = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("hasMore"));
        Assert.Null(model.Runs);
        Assert.False(model.RawData.ContainsKey("runs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunListResponse
        {
            NextCursor = "nextCursor",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
            Runs = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunListResponse
        {
            HasMore = true,
            NextCursor = "nextCursor",
            Runs =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Model = "model",
                    Prompt = "prompt",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = RunListResponseRunStatus.Queued,
                },
            ],
        };

        RunListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunListResponseRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            Prompt = "prompt",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunListResponseRunStatus.Queued,
        };

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RunListResponseRunStatus> expectedStatus = RunListResponseRunStatus.Queued;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPrompt, model.Prompt);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            Prompt = "prompt",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunListResponseRunStatus.Queued,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunListResponseRun>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            Prompt = "prompt",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunListResponseRunStatus.Queued,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunListResponseRun>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RunListResponseRunStatus> expectedStatus = RunListResponseRunStatus.Queued;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPrompt, deserialized.Prompt);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            Prompt = "prompt",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunListResponseRunStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunListResponseRun
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunListResponseRun
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunListResponseRun
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentID = null,
            CreatedAt = null,
            Prompt = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentID);
        Assert.False(model.RawData.ContainsKey("agentId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunListResponseRun
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentID = null,
            CreatedAt = null,
            Prompt = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = RunListResponseRunStatus.Queued,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = RunListResponseRunStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = RunListResponseRunStatus.Queued,

            CompletedAt = null,
            Model = null,
            StartedAt = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prompt = "prompt",
            Status = RunListResponseRunStatus.Queued,

            CompletedAt = null,
            Model = null,
            StartedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunListResponseRun
        {
            ID = "id",
            AgentID = "agentId",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = "model",
            Prompt = "prompt",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = RunListResponseRunStatus.Queued,
        };

        RunListResponseRun copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunListResponseRunStatusTest : TestBase
{
    [Theory]
    [InlineData(RunListResponseRunStatus.Queued)]
    [InlineData(RunListResponseRunStatus.Running)]
    [InlineData(RunListResponseRunStatus.Completed)]
    [InlineData(RunListResponseRunStatus.Failed)]
    [InlineData(RunListResponseRunStatus.Cancelled)]
    public void Validation_Works(RunListResponseRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunListResponseRunStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunListResponseRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RunListResponseRunStatus.Queued)]
    [InlineData(RunListResponseRunStatus.Running)]
    [InlineData(RunListResponseRunStatus.Completed)]
    [InlineData(RunListResponseRunStatus.Failed)]
    [InlineData(RunListResponseRunStatus.Cancelled)]
    public void SerializationRoundtrip_Works(RunListResponseRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunListResponseRunStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunListResponseRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunListResponseRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunListResponseRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
