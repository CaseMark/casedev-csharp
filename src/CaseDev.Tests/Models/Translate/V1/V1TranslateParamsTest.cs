using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Translate.V1;

namespace CaseDev.Tests.Models.Translate.V1;

public class V1TranslateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1TranslateParams
        {
            Q = "string",
            Target = "es",
            Format = V1TranslateParamsFormat.Text,
            Model = V1TranslateParamsModel.Nmt,
            Source = "en",
        };

        V1TranslateParamsQ expectedQ = "string";
        string expectedTarget = "es";
        ApiEnum<string, V1TranslateParamsFormat> expectedFormat = V1TranslateParamsFormat.Text;
        ApiEnum<string, V1TranslateParamsModel> expectedModel = V1TranslateParamsModel.Nmt;
        string expectedSource = "en";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedSource, parameters.Source);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1TranslateParams { Q = "string", Target = "es" };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1TranslateParams
        {
            Q = "string",
            Target = "es",

            // Null should be interpreted as omitted for these properties
            Format = null,
            Model = null,
            Source = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void Url_Works()
    {
        V1TranslateParams parameters = new() { Q = "string", Target = "es" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/translate/v1/translate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1TranslateParams
        {
            Q = "string",
            Target = "es",
            Format = V1TranslateParamsFormat.Text,
            Model = V1TranslateParamsModel.Nmt,
            Source = "en",
        };

        V1TranslateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class V1TranslateParamsQTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        V1TranslateParamsQ value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        V1TranslateParamsQ value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        V1TranslateParamsQ value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateParamsQ>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        V1TranslateParamsQ value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TranslateParamsQ>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1TranslateParamsFormatTest : TestBase
{
    [Theory]
    [InlineData(V1TranslateParamsFormat.Text)]
    [InlineData(V1TranslateParamsFormat.Html)]
    public void Validation_Works(V1TranslateParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1TranslateParamsFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1TranslateParamsFormat.Text)]
    [InlineData(V1TranslateParamsFormat.Html)]
    public void SerializationRoundtrip_Works(V1TranslateParamsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1TranslateParamsFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1TranslateParamsModelTest : TestBase
{
    [Theory]
    [InlineData(V1TranslateParamsModel.Nmt)]
    [InlineData(V1TranslateParamsModel.Base)]
    public void Validation_Works(V1TranslateParamsModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1TranslateParamsModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1TranslateParamsModel.Nmt)]
    [InlineData(V1TranslateParamsModel.Base)]
    public void SerializationRoundtrip_Works(V1TranslateParamsModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1TranslateParamsModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1TranslateParamsModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
