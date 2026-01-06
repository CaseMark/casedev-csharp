using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1ExecuteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ExecuteParams
        {
            ID = "id",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
            Options = new() { Format = OptionsFormat.Json, Model = "model" },
        };

        string expectedID = "id";
        JsonElement expectedInput = JsonSerializer.Deserialize<JsonElement>("{}");
        Options expectedOptions = new() { Format = OptionsFormat.Json, Model = "model" };

        Assert.Equal(expectedID, parameters.ID);
        Assert.True(JsonElement.DeepEquals(expectedInput, parameters.Input));
        Assert.Equal(expectedOptions, parameters.Options);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ExecuteParams
        {
            ID = "id",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ExecuteParams
        {
            ID = "id",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            Options = null,
        };

        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ExecuteParams parameters = new()
        {
            ID = "id",
            Input = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/templates/v1/id/execute"), url);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        ApiEnum<string, OptionsFormat> expectedFormat = OptionsFormat.Json;
        string expectedModel = "model";

        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, OptionsFormat> expectedFormat = OptionsFormat.Json;
        string expectedModel = "model";

        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
            Model = null,
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
            Model = null,
        };

        model.Validate();
    }
}

public class OptionsFormatTest : TestBase
{
    [Theory]
    [InlineData(OptionsFormat.Json)]
    [InlineData(OptionsFormat.Text)]
    public void Validation_Works(OptionsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptionsFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptionsFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OptionsFormat.Json)]
    [InlineData(OptionsFormat.Text)]
    public void SerializationRoundtrip_Works(OptionsFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptionsFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptionsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptionsFormat>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptionsFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
