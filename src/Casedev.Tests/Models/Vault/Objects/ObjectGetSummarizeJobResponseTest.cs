using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectGetSummarizeJobResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            JobID = "jobId",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedError = "error";
        string expectedJobID = "jobId";
        string expectedResultFilename = "resultFilename";
        string expectedResultObjectID = "resultObjectId";
        string expectedSourceObjectID = "sourceObjectId";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedWorkflowType = "workflowType";

        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedResultFilename, model.ResultFilename);
        Assert.Equal(expectedResultObjectID, model.ResultObjectID);
        Assert.Equal(expectedSourceObjectID, model.SourceObjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWorkflowType, model.WorkflowType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            JobID = "jobId",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetSummarizeJobResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            JobID = "jobId",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetSummarizeJobResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedError = "error";
        string expectedJobID = "jobId";
        string expectedResultFilename = "resultFilename";
        string expectedResultObjectID = "resultObjectId";
        string expectedSourceObjectID = "sourceObjectId";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedWorkflowType = "workflowType";

        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedResultFilename, deserialized.ResultFilename);
        Assert.Equal(expectedResultObjectID, deserialized.ResultObjectID);
        Assert.Equal(expectedSourceObjectID, deserialized.SourceObjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWorkflowType, deserialized.WorkflowType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            JobID = "jobId",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("jobId"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("sourceObjectId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkflowType);
        Assert.False(model.RawData.ContainsKey("workflowType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            JobID = null,
            SourceObjectID = null,
            Status = null,
            WorkflowType = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("jobId"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("sourceObjectId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkflowType);
        Assert.False(model.RawData.ContainsKey("workflowType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            JobID = null,
            SourceObjectID = null,
            Status = null,
            WorkflowType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            JobID = "jobId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ResultFilename);
        Assert.False(model.RawData.ContainsKey("resultFilename"));
        Assert.Null(model.ResultObjectID);
        Assert.False(model.RawData.ContainsKey("resultObjectId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            JobID = "jobId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            JobID = "jobId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",

            CompletedAt = null,
            Error = null,
            ResultFilename = null,
            ResultObjectID = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.ResultFilename);
        Assert.True(model.RawData.ContainsKey("resultFilename"));
        Assert.Null(model.ResultObjectID);
        Assert.True(model.RawData.ContainsKey("resultObjectId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            JobID = "jobId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",

            CompletedAt = null,
            Error = null,
            ResultFilename = null,
            ResultObjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetSummarizeJobResponse
        {
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error = "error",
            JobID = "jobId",
            ResultFilename = "resultFilename",
            ResultObjectID = "resultObjectId",
            SourceObjectID = "sourceObjectId",
            Status = Status.Pending,
            WorkflowType = "workflowType",
        };

        ObjectGetSummarizeJobResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
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
    [InlineData(Status.Pending)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
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
