using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using V1 = Casedev.Models.Ocr.V1;

namespace Casedev.Tests.Models.Ocr.V1;

public class V1DownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1::V1DownloadParams { ID = "id", Type = V1::Type.Text };

        string expectedID = "id";
        ApiEnum<string, V1::Type> expectedType = V1::Type.Text;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void Url_Works()
    {
        V1::V1DownloadParams parameters = new() { ID = "id", Type = V1::Type.Text };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/ocr/v1/id/download/text"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1::V1DownloadParams { ID = "id", Type = V1::Type.Text };

        V1::V1DownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(V1::Type.Text)]
    [InlineData(V1::Type.Json)]
    [InlineData(V1::Type.Pdf)]
    [InlineData(V1::Type.Original)]
    public void Validation_Works(V1::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1::Type.Text)]
    [InlineData(V1::Type.Json)]
    [InlineData(V1::Type.Pdf)]
    [InlineData(V1::Type.Original)]
    public void SerializationRoundtrip_Works(V1::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
