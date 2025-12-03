using System.Text.Json;
using CaseDev.Core;
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
