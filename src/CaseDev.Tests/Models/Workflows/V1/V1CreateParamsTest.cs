using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "Document Processor",
            Description = "description",
            Edges = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Nodes = [JsonSerializer.Deserialize<JsonElement>("{}")],
            TriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            TriggerType = TriggerType.Manual,
            Visibility = Visibility.Private,
        };

        string expectedName = "Document Processor";
        string expectedDescription = "description";
        List<JsonElement> expectedEdges = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedNodes = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedTriggerConfig = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, TriggerType> expectedTriggerType = TriggerType.Manual;
        ApiEnum<string, Visibility> expectedVisibility = Visibility.Private;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Edges);
        Assert.Equal(expectedEdges.Count, parameters.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEdges[i], parameters.Edges[i]));
        }
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
        var parameters = new V1CreateParams { Name = "Document Processor" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
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
        var parameters = new V1CreateParams
        {
            Name = "Document Processor",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Edges = null,
            Nodes = null,
            TriggerConfig = null,
            TriggerType = null,
            Visibility = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Edges);
        Assert.False(parameters.RawBodyData.ContainsKey("edges"));
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
        V1CreateParams parameters = new() { Name = "Document Processor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/workflows/v1"), url);
    }
}

public class TriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(TriggerType.Manual)]
    [InlineData(TriggerType.Webhook)]
    [InlineData(TriggerType.Schedule)]
    [InlineData(TriggerType.VaultUpload)]
    public void Validation_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerType.Manual)]
    [InlineData(TriggerType.Webhook)]
    [InlineData(TriggerType.Schedule)]
    [InlineData(TriggerType.VaultUpload)]
    public void SerializationRoundtrip_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VisibilityTest : TestBase
{
    [Theory]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    [InlineData(Visibility.Public)]
    public void Validation_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    [InlineData(Visibility.Public)]
    public void SerializationRoundtrip_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
