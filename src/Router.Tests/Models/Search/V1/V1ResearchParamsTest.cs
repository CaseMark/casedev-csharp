using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Search.V1;

namespace Router.Tests.Models.Search.V1;

public class V1ResearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ResearchParams
        {
            Instructions = "instructions",
            Model = Model.Fast,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Query = "query",
        };

        string expectedInstructions = "instructions";
        ApiEnum<string, Model> expectedModel = Model.Fast;
        JsonElement expectedOutputSchema = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedQuery = "query";

        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.NotNull(parameters.OutputSchema);
        Assert.True(JsonElement.DeepEquals(expectedOutputSchema, parameters.OutputSchema.Value));
        Assert.Equal(expectedQuery, parameters.Query);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ResearchParams { Instructions = "instructions" };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.OutputSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("outputSchema"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ResearchParams
        {
            Instructions = "instructions",

            // Null should be interpreted as omitted for these properties
            Model = null,
            OutputSchema = null,
            Query = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.OutputSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("outputSchema"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ResearchParams parameters = new() { Instructions = "instructions" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/search/v1/research"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ResearchParams
        {
            Instructions = "instructions",
            Model = Model.Fast,
            OutputSchema = JsonSerializer.Deserialize<JsonElement>("{}"),
            Query = "query",
        };

        V1ResearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.Fast)]
    [InlineData(Model.Normal)]
    [InlineData(Model.Pro)]
    public void Validation_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Model.Fast)]
    [InlineData(Model.Normal)]
    [InlineData(Model.Pro)]
    public void SerializationRoundtrip_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
