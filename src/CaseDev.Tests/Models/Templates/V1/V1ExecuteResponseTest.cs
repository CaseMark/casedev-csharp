using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1ExecuteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Completed,
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
            WorkflowName = "workflow_name",
        };

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        Usage expectedUsage = new()
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };
        string expectedWorkflowName = "workflow_name";

        Assert.NotNull(model.Result);
        Assert.True(JsonElement.DeepEquals(expectedResult, model.Result.Value));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedWorkflowName, model.WorkflowName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ExecuteResponse
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Completed,
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
            WorkflowName = "workflow_name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ExecuteResponse
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Completed,
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
            WorkflowName = "workflow_name",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ExecuteResponse>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        Usage expectedUsage = new()
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };
        string expectedWorkflowName = "workflow_name";

        Assert.NotNull(deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedResult, deserialized.Result.Value));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedWorkflowName, deserialized.WorkflowName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ExecuteResponse
        {
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = Status.Completed,
            Usage = new()
            {
                CompletionTokens = 0,
                Cost = 0,
                PromptTokens = 0,
                TotalTokens = 0,
            },
            WorkflowName = "workflow_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ExecuteResponse { };

        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.WorkflowName);
        Assert.False(model.RawData.ContainsKey("workflow_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ExecuteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ExecuteResponse
        {
            // Null should be interpreted as omitted for these properties
            Result = null,
            Status = null,
            Usage = null,
            WorkflowName = null,
        };

        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.WorkflowName);
        Assert.False(model.RawData.ContainsKey("workflow_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ExecuteResponse
        {
            // Null should be interpreted as omitted for these properties
            Result = null,
            Status = null,
            Usage = null,
            WorkflowName = null,
        };

        model.Validate();
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

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        long expectedCompletionTokens = 0;
        double expectedCost = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCompletionTokens, model.CompletionTokens);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Usage>(element);
        Assert.NotNull(deserialized);

        long expectedCompletionTokens = 0;
        double expectedCost = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedCompletionTokens, deserialized.CompletionTokens);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            CompletionTokens = 0,
            Cost = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { };

        Assert.Null(model.CompletionTokens);
        Assert.False(model.RawData.ContainsKey("completion_tokens"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CompletionTokens = null,
            Cost = null,
            PromptTokens = null,
            TotalTokens = null,
        };

        Assert.Null(model.CompletionTokens);
        Assert.False(model.RawData.ContainsKey("completion_tokens"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CompletionTokens = null,
            Cost = null,
            PromptTokens = null,
            TotalTokens = null,
        };

        model.Validate();
    }
}
