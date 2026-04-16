using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Ocr.V1;

namespace Casedev.Tests.Models.Ocr.V1;

public class V1RetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveParams { ID = "id", IncludeText = IncludeText.True };

        string expectedID = "id";
        ApiEnum<string, IncludeText> expectedIncludeText = IncludeText.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIncludeText, parameters.IncludeText);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1RetrieveParams { ID = "id" };

        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawQueryData.ContainsKey("include_text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1RetrieveParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            IncludeText = null,
        };

        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawQueryData.ContainsKey("include_text"));
    }

    [Fact]
    public void Url_Works()
    {
        V1RetrieveParams parameters = new() { ID = "id", IncludeText = IncludeText.True };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/ocr/v1/id?include_text=true"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1RetrieveParams { ID = "id", IncludeText = IncludeText.True };

        V1RetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IncludeTextTest : TestBase
{
    [Theory]
    [InlineData(IncludeText.True)]
    [InlineData(IncludeText.False)]
    public void Validation_Works(IncludeText rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeText> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IncludeText.True)]
    [InlineData(IncludeText.False)]
    public void SerializationRoundtrip_Works(IncludeText rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeText> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeText>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
