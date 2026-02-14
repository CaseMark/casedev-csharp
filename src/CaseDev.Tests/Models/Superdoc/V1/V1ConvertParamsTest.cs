using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Superdoc.V1;

namespace CaseDev.Tests.Models.Superdoc.V1;

public class V1ConvertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ConvertParams
        {
            From = From.Docx,
            DocumentBase64 = "document_base64",
            DocumentUrl = "document_url",
            To = To.Pdf,
        };

        ApiEnum<string, From> expectedFrom = From.Docx;
        string expectedDocumentBase64 = "document_base64";
        string expectedDocumentUrl = "document_url";
        ApiEnum<string, To> expectedTo = To.Pdf;

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedDocumentBase64, parameters.DocumentBase64);
        Assert.Equal(expectedDocumentUrl, parameters.DocumentUrl);
        Assert.Equal(expectedTo, parameters.To);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ConvertParams { From = From.Docx };

        Assert.Null(parameters.DocumentBase64);
        Assert.False(parameters.RawBodyData.ContainsKey("document_base64"));
        Assert.Null(parameters.DocumentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("document_url"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ConvertParams
        {
            From = From.Docx,

            // Null should be interpreted as omitted for these properties
            DocumentBase64 = null,
            DocumentUrl = null,
            To = null,
        };

        Assert.Null(parameters.DocumentBase64);
        Assert.False(parameters.RawBodyData.ContainsKey("document_base64"));
        Assert.Null(parameters.DocumentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("document_url"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawBodyData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ConvertParams parameters = new() { From = From.Docx };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/superdoc/v1/convert"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ConvertParams
        {
            From = From.Docx,
            DocumentBase64 = "document_base64",
            DocumentUrl = "document_url",
            To = To.Pdf,
        };

        V1ConvertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FromTest : TestBase
{
    [Theory]
    [InlineData(From.Docx)]
    [InlineData(From.Md)]
    [InlineData(From.Html)]
    public void Validation_Works(From rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, From> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, From>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(From.Docx)]
    [InlineData(From.Md)]
    [InlineData(From.Html)]
    public void SerializationRoundtrip_Works(From rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, From> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, From>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, From>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, From>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToTest : TestBase
{
    [Theory]
    [InlineData(To.Pdf)]
    [InlineData(To.Docx)]
    public void Validation_Works(To rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, To> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(To.Pdf)]
    [InlineData(To.Docx)]
    public void SerializationRoundtrip_Works(To rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, To> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
