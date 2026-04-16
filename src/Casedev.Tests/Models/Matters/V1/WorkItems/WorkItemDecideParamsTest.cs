using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Tests.Models.Matters.V1.WorkItems;

public class WorkItemDecideParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            AgentTypeID = "agent_type_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Reason = "reason",
        };

        string expectedID = "id";
        string expectedWorkItemID = "workItemId";
        ApiEnum<string, Decision> expectedDecision = Decision.Approve;
        string expectedAgentTypeID = "agent_type_id";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedReason = "reason";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedWorkItemID, parameters.WorkItemID);
        Assert.Equal(expectedDecision, parameters.Decision);
        Assert.Equal(expectedAgentTypeID, parameters.AgentTypeID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            AgentTypeID = "agent_type_id",
            Reason = "reason",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            AgentTypeID = "agent_type_id",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(parameters.AgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_type_id"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            AgentTypeID = null,
            Reason = null,
        };

        Assert.Null(parameters.AgentTypeID);
        Assert.True(parameters.RawBodyData.ContainsKey("agent_type_id"));
        Assert.Null(parameters.Reason);
        Assert.True(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkItemDecideParams parameters = new()
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/matters/v1/id/work-items/workItemId/decision"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkItemDecideParams
        {
            ID = "id",
            WorkItemID = "workItemId",
            Decision = Decision.Approve,
            AgentTypeID = "agent_type_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Reason = "reason",
        };

        WorkItemDecideParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DecisionTest : TestBase
{
    [Theory]
    [InlineData(Decision.Approve)]
    [InlineData(Decision.Revise)]
    [InlineData(Decision.Block)]
    [InlineData(Decision.Reassign)]
    public void Validation_Works(Decision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Decision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Decision.Approve)]
    [InlineData(Decision.Revise)]
    [InlineData(Decision.Block)]
    [InlineData(Decision.Reassign)]
    public void SerializationRoundtrip_Works(Decision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Decision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Decision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
