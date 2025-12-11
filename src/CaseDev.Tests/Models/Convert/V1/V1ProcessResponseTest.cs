using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1ProcessResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ProcessResponse
        {
            JobID = "job_id",
            Message = "message",
            Status = V1ProcessResponseStatus.Queued,
        };

        string expectedJobID = "job_id";
        string expectedMessage = "message";
        ApiEnum<string, V1ProcessResponseStatus> expectedStatus = V1ProcessResponseStatus.Queued;

        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ProcessResponse
        {
            JobID = "job_id",
            Message = "message",
            Status = V1ProcessResponseStatus.Queued,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ProcessResponse
        {
            JobID = "job_id",
            Message = "message",
            Status = V1ProcessResponseStatus.Queued,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(json);
        Assert.NotNull(deserialized);

        string expectedJobID = "job_id";
        string expectedMessage = "message";
        ApiEnum<string, V1ProcessResponseStatus> expectedStatus = V1ProcessResponseStatus.Queued;

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ProcessResponse
        {
            JobID = "job_id",
            Message = "message",
            Status = V1ProcessResponseStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ProcessResponse { };

        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ProcessResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ProcessResponse
        {
            // Null should be interpreted as omitted for these properties
            JobID = null,
            Message = null,
            Status = null,
        };

        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("job_id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ProcessResponse
        {
            // Null should be interpreted as omitted for these properties
            JobID = null,
            Message = null,
            Status = null,
        };

        model.Validate();
    }
}

public class V1ProcessResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(V1ProcessResponseStatus.Queued)]
    [InlineData(V1ProcessResponseStatus.Processing)]
    [InlineData(V1ProcessResponseStatus.Completed)]
    [InlineData(V1ProcessResponseStatus.Failed)]
    public void Validation_Works(V1ProcessResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ProcessResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ProcessResponseStatus.Queued)]
    [InlineData(V1ProcessResponseStatus.Processing)]
    [InlineData(V1ProcessResponseStatus.Completed)]
    [InlineData(V1ProcessResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(V1ProcessResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ProcessResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
