using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Agent.V1.Run;

namespace Router.Tests.Models.Agent.V1.Run;

public class RunCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunCancelResponse
        {
            ID = "id",
            Message = "message",
            Status = RunCancelResponseStatus.Cancelled,
        };

        string expectedID = "id";
        string expectedMessage = "message";
        ApiEnum<string, RunCancelResponseStatus> expectedStatus = RunCancelResponseStatus.Cancelled;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunCancelResponse
        {
            ID = "id",
            Message = "message",
            Status = RunCancelResponseStatus.Cancelled,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunCancelResponse
        {
            ID = "id",
            Message = "message",
            Status = RunCancelResponseStatus.Cancelled,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMessage = "message";
        ApiEnum<string, RunCancelResponseStatus> expectedStatus = RunCancelResponseStatus.Cancelled;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunCancelResponse
        {
            ID = "id",
            Message = "message",
            Status = RunCancelResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunCancelResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunCancelResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunCancelResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunCancelResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunCancelResponse
        {
            ID = "id",
            Message = "message",
            Status = RunCancelResponseStatus.Cancelled,
        };

        RunCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunCancelResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(RunCancelResponseStatus.Cancelled)]
    [InlineData(RunCancelResponseStatus.Completed)]
    [InlineData(RunCancelResponseStatus.Failed)]
    public void Validation_Works(RunCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunCancelResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RunCancelResponseStatus.Cancelled)]
    [InlineData(RunCancelResponseStatus.Completed)]
    [InlineData(RunCancelResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(RunCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RunCancelResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RunCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RunCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
