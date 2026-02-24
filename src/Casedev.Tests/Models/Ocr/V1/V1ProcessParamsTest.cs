using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Ocr.V1;

namespace Casedev.Tests.Models.Ocr.V1;

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
                Embed = { },
                Forms = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Tables = new() { Format = TablesFormat.Csv },
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
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ProcessParams
        {
            DocumentUrl = "https://example.com/contract.pdf",
            CallbackUrl = "https://your-app.com/webhooks/ocr-complete",
            DocumentID = "contract-2024-001",
            Engine = Engine.Doctr,
            Features = new()
            {
                Embed = { },
                Forms = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Tables = new() { Format = TablesFormat.Csv },
            },
            ResultBucket = "my-ocr-results",
            ResultPrefix = "ocr/2024/",
        };

        V1ProcessParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
        };

        Dictionary<string, JsonElement> expectedEmbed = new() { };
        Dictionary<string, JsonElement> expectedForms = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Tables expectedTables = new() { Format = TablesFormat.Csv };

        Assert.NotNull(model.Embed);
        Assert.Equal(expectedEmbed.Count, model.Embed.Count);
        foreach (var item in expectedEmbed)
        {
            Assert.True(model.Embed.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Embed[item.Key]));
        }
        Assert.NotNull(model.Forms);
        Assert.Equal(expectedForms.Count, model.Forms.Count);
        foreach (var item in expectedForms)
        {
            Assert.True(model.Forms.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Forms[item.Key]));
        }
        Assert.Equal(expectedTables, model.Tables);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Features
        {
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Features>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Features
        {
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Features>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedEmbed = new() { };
        Dictionary<string, JsonElement> expectedForms = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Tables expectedTables = new() { Format = TablesFormat.Csv };

        Assert.NotNull(deserialized.Embed);
        Assert.Equal(expectedEmbed.Count, deserialized.Embed.Count);
        foreach (var item in expectedEmbed)
        {
            Assert.True(deserialized.Embed.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Embed[item.Key]));
        }
        Assert.NotNull(deserialized.Forms);
        Assert.Equal(expectedForms.Count, deserialized.Forms.Count);
        foreach (var item in expectedForms)
        {
            Assert.True(deserialized.Forms.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Forms[item.Key]));
        }
        Assert.Equal(expectedTables, deserialized.Tables);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Features
        {
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Features { };

        Assert.Null(model.Embed);
        Assert.False(model.RawData.ContainsKey("embed"));
        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
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
            Embed = null,
            Forms = null,
            Tables = null,
        };

        Assert.Null(model.Embed);
        Assert.False(model.RawData.ContainsKey("embed"));
        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Features
        {
            // Null should be interpreted as omitted for these properties
            Embed = null,
            Forms = null,
            Tables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Features
        {
            Embed = { },
            Forms = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Tables = new() { Format = TablesFormat.Csv },
        };

        Features copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TablesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tables { Format = TablesFormat.Csv };

        ApiEnum<string, TablesFormat> expectedFormat = TablesFormat.Csv;

        Assert.Equal(expectedFormat, model.Format);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tables { Format = TablesFormat.Csv };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tables>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tables { Format = TablesFormat.Csv };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tables>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, TablesFormat> expectedFormat = TablesFormat.Csv;

        Assert.Equal(expectedFormat, deserialized.Format);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tables { Format = TablesFormat.Csv };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tables { };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tables { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tables
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tables
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tables { Format = TablesFormat.Csv };

        Tables copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TablesFormatTest : TestBase
{
    [Theory]
    [InlineData(TablesFormat.Csv)]
    [InlineData(TablesFormat.Json)]
    public void Validation_Works(TablesFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TablesFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TablesFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TablesFormat.Csv)]
    [InlineData(TablesFormat.Json)]
    public void SerializationRoundtrip_Works(TablesFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TablesFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TablesFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TablesFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TablesFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
