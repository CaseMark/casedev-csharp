using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1UpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Name = "name",
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = V1UpdateParamsTriggerType.Manual,
            Visibility = V1UpdateParamsVisibility.Private,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        List<JsonElement> expectedEdges = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedName = "name";
        List<JsonElement> expectedNodes = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedTriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, V1UpdateParamsTriggerType> expectedTriggerType =
            V1UpdateParamsTriggerType.Manual;
        ApiEnum<string, V1UpdateParamsVisibility> expectedVisibility =
            V1UpdateParamsVisibility.Private;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Edges);
        Assert.Equal(expectedEdges.Count, parameters.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEdges[i], parameters.Edges[i]));
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Nodes);
        Assert.Equal(expectedNodes.Count, parameters.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedNodes[i], parameters.Nodes[i]));
        }
        Assert.NotNull(parameters.TriggerConfig);
        Assert.True(JsonElement.DeepEquals(expectedTriggerConfig, parameters.TriggerConfig.Value));
        Assert.Equal(expectedTriggerType, parameters.TriggerType);
        Assert.Equal(expectedVisibility, parameters.Visibility);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1UpdateParams { ID = "id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Nodes);
        Assert.False(parameters.RawBodyData.ContainsKey("nodes"));
        Assert.Null(parameters.TriggerConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerConfig"));
        Assert.Null(parameters.TriggerType);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerType"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawBodyData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Edges = null,
            Name = null,
            Nodes = null,
            TriggerConfig = null,
            TriggerType = null,
            Visibility = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Nodes);
        Assert.False(parameters.RawBodyData.ContainsKey("nodes"));
        Assert.Null(parameters.TriggerConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerConfig"));
        Assert.Null(parameters.TriggerType);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerType"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawBodyData.ContainsKey("visibility"));
    }

    [Fact]
    public void Url_Works()
    {
        V1UpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/workflows/v1/id"), url);
    }
}

public class V1UpdateParamsTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(V1UpdateParamsTriggerType.Manual)]
    [InlineData(V1UpdateParamsTriggerType.Webhook)]
    [InlineData(V1UpdateParamsTriggerType.Schedule)]
    [InlineData(V1UpdateParamsTriggerType.VaultUpload)]
    public void Validation_Works(V1UpdateParamsTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1UpdateParamsTriggerType.Manual)]
    [InlineData(V1UpdateParamsTriggerType.Webhook)]
    [InlineData(V1UpdateParamsTriggerType.Schedule)]
    [InlineData(V1UpdateParamsTriggerType.VaultUpload)]
    public void SerializationRoundtrip_Works(V1UpdateParamsTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1UpdateParamsVisibilityTest : TestBase
{
    [Theory]
    [InlineData(V1UpdateParamsVisibility.Private)]
    [InlineData(V1UpdateParamsVisibility.Org)]
    [InlineData(V1UpdateParamsVisibility.Public)]
    public void Validation_Works(V1UpdateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1UpdateParamsVisibility.Private)]
    [InlineData(V1UpdateParamsVisibility.Org)]
    [InlineData(V1UpdateParamsVisibility.Public)]
    public void SerializationRoundtrip_Works(V1UpdateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
