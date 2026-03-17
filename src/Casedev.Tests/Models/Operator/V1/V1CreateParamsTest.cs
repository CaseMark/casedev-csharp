using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Operator.V1;

namespace Casedev.Tests.Models.Operator.V1;

public class V1CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",
            Model = "model",
            Size = Size.Small,
        };

        string expectedName = "name";
        string expectedModel = "model";
        ApiEnum<string, Size> expectedSize = Size.Small;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedSize, parameters.Size);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateParams { Name = "name" };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Size);
        Assert.False(parameters.RawBodyData.ContainsKey("size"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Model = null,
            Size = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Size);
        Assert.False(parameters.RawBodyData.ContainsKey("size"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/operator/v1/create"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",
            Model = "model",
            Size = Size.Small,
        };

        V1CreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SizeTest : TestBase
{
    [Theory]
    [InlineData(Size.Small)]
    [InlineData(Size.Medium)]
    [InlineData(Size.Large)]
    public void Validation_Works(Size rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Size> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Size.Small)]
    [InlineData(Size.Medium)]
    [InlineData(Size.Large)]
    public void SerializationRoundtrip_Works(Size rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Size> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
