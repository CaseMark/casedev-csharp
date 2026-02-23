using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Llm.V1;

namespace Router.Tests.Models.Llm.V1;

public class V1CreateEmbeddingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateEmbeddingParams
        {
            Input = "string",
            Model = "model",
            Dimensions = 0,
            EncodingFormat = EncodingFormat.Float,
            User = "user",
        };

        Input expectedInput = "string";
        string expectedModel = "model";
        long expectedDimensions = 0;
        ApiEnum<string, EncodingFormat> expectedEncodingFormat = EncodingFormat.Float;
        string expectedUser = "user";

        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedDimensions, parameters.Dimensions);
        Assert.Equal(expectedEncodingFormat, parameters.EncodingFormat);
        Assert.Equal(expectedUser, parameters.User);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateEmbeddingParams { Input = "string", Model = "model" };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.EncodingFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("encoding_format"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateEmbeddingParams
        {
            Input = "string",
            Model = "model",

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            EncodingFormat = null,
            User = null,
        };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.EncodingFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("encoding_format"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateEmbeddingParams parameters = new() { Input = "string", Model = "model" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/llm/v1/embeddings"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateEmbeddingParams
        {
            Input = "string",
            Model = "model",
            Dimensions = 0,
            EncodingFormat = EncodingFormat.Float,
            User = "user",
        };

        V1CreateEmbeddingParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Input value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Input value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Input value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Input value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EncodingFormatTest : TestBase
{
    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void Validation_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void SerializationRoundtrip_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
