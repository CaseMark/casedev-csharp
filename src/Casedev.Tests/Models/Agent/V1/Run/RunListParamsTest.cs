using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Tests.Models.Agent.V1.Run;

public class RunListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunListParams
        {
            AgentID = "agentId",
            Cursor = "cursor",
            Limit = 1,
            Status = Status.Queued,
        };

        string expectedAgentID = "agentId";
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        ApiEnum<string, Status> expectedStatus = Status.Queued;

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RunListParams { };

        Assert.Null(parameters.AgentID);
        Assert.False(parameters.RawQueryData.ContainsKey("agentId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RunListParams
        {
            // Null should be interpreted as omitted for these properties
            AgentID = null,
            Cursor = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.AgentID);
        Assert.False(parameters.RawQueryData.ContainsKey("agentId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        RunListParams parameters = new()
        {
            AgentID = "agentId",
            Cursor = "cursor",
            Limit = 1,
            Status = Status.Queued,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/agent/v1/run?agentId=agentId&cursor=cursor&limit=1&status=queued"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunListParams
        {
            AgentID = "agentId",
            Cursor = "cursor",
            Limit = 1,
            Status = Status.Queued,
        };

        RunListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
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
    [InlineData(Status.Queued)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
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
