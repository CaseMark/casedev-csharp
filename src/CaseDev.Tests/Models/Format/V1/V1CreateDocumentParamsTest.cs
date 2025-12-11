using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Format.V1;

namespace CaseDev.Tests.Models.Format.V1;

public class OutputFormatTest : TestBase
{
    [Theory]
    [InlineData(OutputFormat.Pdf)]
    [InlineData(OutputFormat.Docx)]
    [InlineData(OutputFormat.HTMLPreview)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputFormat.Pdf)]
    [InlineData(OutputFormat.Docx)]
    [InlineData(OutputFormat.HTMLPreview)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);
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
        Assert.True(
            model.Styles.HasValue && JsonElement.DeepEquals(expectedStyles, model.Styles.Value)
        );
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.True(
            model.Variables.HasValue
                && JsonElement.DeepEquals(expectedVariables, model.Variables.Value)
        );
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Component>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Component>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        JsonElement expectedStyles = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTemplateID = "templateId";
        JsonElement expectedVariables = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(
            deserialized.Styles.HasValue
                && JsonElement.DeepEquals(expectedStyles, deserialized.Styles.Value)
        );
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.True(
            deserialized.Variables.HasValue
                && JsonElement.DeepEquals(expectedVariables, deserialized.Variables.Value)
        );
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
}
