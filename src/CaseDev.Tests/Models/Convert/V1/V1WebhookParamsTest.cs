using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1WebhookParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1WebhookParams
        {
            JobID = "job_id",
            Status = Status.Completed,
            Error = "error",
            Result = new()
            {
                DurationSeconds = 0,
                FileSizeBytes = 0,
                StoredFilename = "stored_filename",
            },
        };

        string expectedJobID = "job_id";
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        string expectedError = "error";
        Result expectedResult = new()
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        Assert.Equal(expectedJobID, parameters.JobID);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedError, parameters.Error);
        Assert.Equal(expectedResult, parameters.Result);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1WebhookParams { JobID = "job_id", Status = Status.Completed };

        Assert.Null(parameters.Error);
        Assert.False(parameters.RawBodyData.ContainsKey("error"));
        Assert.Null(parameters.Result);
        Assert.False(parameters.RawBodyData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1WebhookParams
        {
            JobID = "job_id",
            Status = Status.Completed,

            // Null should be interpreted as omitted for these properties
            Error = null,
            Result = null,
        };

        Assert.Null(parameters.Error);
        Assert.False(parameters.RawBodyData.ContainsKey("error"));
        Assert.Null(parameters.Result);
        Assert.False(parameters.RawBodyData.ContainsKey("result"));
    }

    [Fact]
    public void Url_Works()
    {
        V1WebhookParams parameters = new() { JobID = "job_id", Status = Status.Completed };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/webhook"), url);
    }
}

public class StatusTest : TestBase
{
    [Theory]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        double expectedDurationSeconds = 0;
        long expectedFileSizeBytes = 0;
        string expectedStoredFilename = "stored_filename";

        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedFileSizeBytes, model.FileSizeBytes);
        Assert.Equal(expectedStoredFilename, model.StoredFilename);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(element);
        Assert.NotNull(deserialized);

        double expectedDurationSeconds = 0;
        long expectedFileSizeBytes = 0;
        string expectedStoredFilename = "stored_filename";

        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedFileSizeBytes, deserialized.FileSizeBytes);
        Assert.Equal(expectedStoredFilename, deserialized.StoredFilename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { };

        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.FileSizeBytes);
        Assert.False(model.RawData.ContainsKey("file_size_bytes"));
        Assert.Null(model.StoredFilename);
        Assert.False(model.RawData.ContainsKey("stored_filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            DurationSeconds = null,
            FileSizeBytes = null,
            StoredFilename = null,
        };

        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.FileSizeBytes);
        Assert.False(model.RawData.ContainsKey("file_size_bytes"));
        Assert.Null(model.StoredFilename);
        Assert.False(model.RawData.ContainsKey("stored_filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            DurationSeconds = null,
            FileSizeBytes = null,
            StoredFilename = null,
        };

        model.Validate();
    }
}
