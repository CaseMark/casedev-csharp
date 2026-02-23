using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Translate.V1;

namespace Router.Tests.Models.Translate.V1;

public class V1ListLanguagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListLanguagesParams { Model = Model.Nmt, Target = "target" };

        ApiEnum<string, Model> expectedModel = Model.Nmt;
        string expectedTarget = "target";

        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedTarget, parameters.Target);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListLanguagesParams { };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawQueryData.ContainsKey("model"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawQueryData.ContainsKey("target"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListLanguagesParams
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Target = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawQueryData.ContainsKey("model"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawQueryData.ContainsKey("target"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListLanguagesParams parameters = new() { Model = Model.Nmt, Target = "target" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/translate/v1/languages?model=nmt&target=target"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListLanguagesParams { Model = Model.Nmt, Target = "target" };

        V1ListLanguagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.Nmt)]
    [InlineData(Model.Base)]
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
    [InlineData(Model.Nmt)]
    [InlineData(Model.Base)]
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
