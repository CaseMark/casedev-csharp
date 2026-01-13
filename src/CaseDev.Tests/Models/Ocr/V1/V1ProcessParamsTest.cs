using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Ocr.V1;

namespace CaseDev.Tests.Models.Ocr.V1;

public class V1ProcessParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ProcessParams
        {
            DocumentUrl = "https://example.com/contract.pdf",
            CallbackUrl = "https://your-app.com/webhooks/ocr-complete",
            DocumentID = "contract-2024-001",
            Engine = Engine.Doctr,
            Features = new()
            {
                Forms = false,
                Layout = true,
                Tables = true,
                Text = true,
            },
            ResultBucket = "my-ocr-results",
            ResultPrefix = "ocr/2024/",
        };

        string expectedDocumentUrl = "https://example.com/contract.pdf";
        string expectedCallbackUrl = "https://your-app.com/webhooks/ocr-complete";
        string expectedDocumentID = "contract-2024-001";
        ApiEnum<string, Engine> expectedEngine = Engine.Doctr;
        Features expectedFeatures = new()
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };
        string expectedResultBucket = "my-ocr-results";
        string expectedResultPrefix = "ocr/2024/";

        Assert.Equal(expectedDocumentUrl, parameters.DocumentUrl);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.Equal(expectedDocumentID, parameters.DocumentID);
        Assert.Equal(expectedEngine, parameters.Engine);
        Assert.Equal(expectedFeatures, parameters.Features);
        Assert.Equal(expectedResultBucket, parameters.ResultBucket);
        Assert.Equal(expectedResultPrefix, parameters.ResultPrefix);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ProcessParams { DocumentUrl = "https://example.com/contract.pdf" };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.DocumentID);
        Assert.False(parameters.RawBodyData.ContainsKey("document_id"));
        Assert.Null(parameters.Engine);
        Assert.False(parameters.RawBodyData.ContainsKey("engine"));
        Assert.Null(parameters.Features);
        Assert.False(parameters.RawBodyData.ContainsKey("features"));
        Assert.Null(parameters.ResultBucket);
        Assert.False(parameters.RawBodyData.ContainsKey("result_bucket"));
        Assert.Null(parameters.ResultPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("result_prefix"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ProcessParams
        {
            DocumentUrl = "https://example.com/contract.pdf",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            DocumentID = null,
            Engine = null,
            Features = null,
            ResultBucket = null,
            ResultPrefix = null,
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callback_url"));
        Assert.Null(parameters.DocumentID);
        Assert.False(parameters.RawBodyData.ContainsKey("document_id"));
        Assert.Null(parameters.Engine);
        Assert.False(parameters.RawBodyData.ContainsKey("engine"));
        Assert.Null(parameters.Features);
        Assert.False(parameters.RawBodyData.ContainsKey("features"));
        Assert.Null(parameters.ResultBucket);
        Assert.False(parameters.RawBodyData.ContainsKey("result_bucket"));
        Assert.Null(parameters.ResultPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("result_prefix"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ProcessParams parameters = new() { DocumentUrl = "https://example.com/contract.pdf" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/ocr/v1/process"), url);
    }
}

public class EngineTest : TestBase
{
    [Theory]
    [InlineData(Engine.Doctr)]
    [InlineData(Engine.Paddleocr)]
    public void Validation_Works(Engine rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Engine> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Engine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Engine.Doctr)]
    [InlineData(Engine.Paddleocr)]
    public void SerializationRoundtrip_Works(Engine rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Engine> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Engine>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Engine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Engine>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeaturesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        bool expectedForms = false;
        bool expectedLayout = true;
        bool expectedTables = true;
        bool expectedText = true;

        Assert.Equal(expectedForms, model.Forms);
        Assert.Equal(expectedLayout, model.Layout);
        Assert.Equal(expectedTables, model.Tables);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Features>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Features>(element);
        Assert.NotNull(deserialized);

        bool expectedForms = false;
        bool expectedLayout = true;
        bool expectedTables = true;
        bool expectedText = true;

        Assert.Equal(expectedForms, deserialized.Forms);
        Assert.Equal(expectedLayout, deserialized.Layout);
        Assert.Equal(expectedTables, deserialized.Tables);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Features { };

        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Layout);
        Assert.False(model.RawData.ContainsKey("layout"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Features { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Features
        {
            // Null should be interpreted as omitted for these properties
            Forms = null,
            Layout = null,
            Tables = null,
            Text = null,
        };

        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Layout);
        Assert.False(model.RawData.ContainsKey("layout"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Features
        {
            // Null should be interpreted as omitted for these properties
            Forms = null,
            Layout = null,
            Tables = null,
            Text = null,
        };

        model.Validate();
    }
}
