using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Format.V1;

namespace Casedev.Tests.Models.Format.V1;

public class V1CreateDocumentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateDocumentParams
        {
            Content = "content",
            OutputFormat = OutputFormat.Pdf,
            InputFormat = InputFormat.Md,
            Options = new()
            {
                Components =
                [
                    new()
                    {
                        Content = "content",
                        Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                        TemplateID = "templateId",
                        Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        };

        string expectedContent = "content";
        ApiEnum<string, OutputFormat> expectedOutputFormat = OutputFormat.Pdf;
        ApiEnum<string, InputFormat> expectedInputFormat = InputFormat.Md;
        Options expectedOptions = new()
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
        Assert.Equal(expectedInputFormat, parameters.InputFormat);
        Assert.Equal(expectedOptions, parameters.Options);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateDocumentParams
        {
            Content = "content",
            OutputFormat = OutputFormat.Pdf,
        };

        Assert.Null(parameters.InputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("input_format"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateDocumentParams
        {
            Content = "content",
            OutputFormat = OutputFormat.Pdf,

            // Null should be interpreted as omitted for these properties
            InputFormat = null,
            Options = null,
        };

        Assert.Null(parameters.InputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("input_format"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateDocumentParams parameters = new()
        {
            Content = "content",
            OutputFormat = OutputFormat.Pdf,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/format/v1/document"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateDocumentParams
        {
            Content = "content",
            OutputFormat = OutputFormat.Pdf,
            InputFormat = InputFormat.Md,
            Options = new()
            {
                Components =
                [
                    new()
                    {
                        Content = "content",
                        Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                        TemplateID = "templateId",
                        Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                ],
            },
        };

        V1CreateDocumentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OutputFormatTest : TestBase
{
    [Theory]
    [InlineData(OutputFormat.Pdf)]
    [InlineData(OutputFormat.Docx)]
    [InlineData(OutputFormat.HtmlPreview)]
    public void Validation_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputFormat.Pdf)]
    [InlineData(OutputFormat.Docx)]
    [InlineData(OutputFormat.HtmlPreview)]
    public void SerializationRoundtrip_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InputFormatTest : TestBase
{
    [Theory]
    [InlineData(InputFormat.Md)]
    [InlineData(InputFormat.Json)]
    [InlineData(InputFormat.Text)]
    public void Validation_Works(InputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputFormat.Md)]
    [InlineData(InputFormat.Json)]
    [InlineData(InputFormat.Text)]
    public void SerializationRoundtrip_Works(InputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        List<Component> expectedComponents =
        [
            new()
            {
                Content = "content",
                Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                TemplateID = "templateId",
                Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.NotNull(model.Components);
        Assert.Equal(expectedComponents.Count, model.Components.Count);
        for (int i = 0; i < expectedComponents.Count; i++)
        {
            Assert.Equal(expectedComponents[i], model.Components[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Component> expectedComponents =
        [
            new()
            {
                Content = "content",
                Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                TemplateID = "templateId",
                Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.NotNull(deserialized.Components);
        Assert.Equal(expectedComponents.Count, deserialized.Components.Count);
        for (int i = 0; i < expectedComponents.Count; i++)
        {
            Assert.Equal(expectedComponents[i], deserialized.Components[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

        Assert.Null(model.Components);
        Assert.False(model.RawData.ContainsKey("components"));
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
            Components = null,
        };

        Assert.Null(model.Components);
        Assert.False(model.RawData.ContainsKey("components"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Components = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComponentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedContent = "content";
        JsonElement expectedStyles = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTemplateID = "templateId";
        JsonElement expectedVariables = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Styles);
        Assert.True(JsonElement.DeepEquals(expectedStyles, model.Styles.Value));
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.NotNull(model.Variables);
        Assert.True(JsonElement.DeepEquals(expectedVariables, model.Variables.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        JsonElement expectedStyles = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTemplateID = "templateId";
        JsonElement expectedVariables = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Styles);
        Assert.True(JsonElement.DeepEquals(expectedStyles, deserialized.Styles.Value));
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.NotNull(deserialized.Variables);
        Assert.True(JsonElement.DeepEquals(expectedVariables, deserialized.Variables.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Component { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Styles);
        Assert.False(model.RawData.ContainsKey("styles"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Component { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Component
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Styles = null,
            TemplateID = null,
            Variables = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Styles);
        Assert.False(model.RawData.ContainsKey("styles"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Component
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Styles = null,
            TemplateID = null,
            Variables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Component copied = new(model);

        Assert.Equal(model, copied);
    }
}
