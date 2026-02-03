using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using V1 = CaseDev.Models.Superdoc.V1;

namespace CaseDev.Tests.Models.Superdoc.V1;

public class V1AnnotateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1::V1AnnotateParams
        {
            Document = new() { Base64 = "base64", Url = "url" },
            Fields =
            [
                new()
                {
                    Type = V1::Type.Text,
                    Value = "string",
                    ID = "id",
                    Group = "group",
                    Options = new() { Height = 0, Width = 0 },
                },
            ],
            OutputFormat = V1::OutputFormat.Docx,
        };

        V1::Document expectedDocument = new() { Base64 = "base64", Url = "url" };
        List<V1::Field> expectedFields =
        [
            new()
            {
                Type = V1::Type.Text,
                Value = "string",
                ID = "id",
                Group = "group",
                Options = new() { Height = 0, Width = 0 },
            },
        ];
        ApiEnum<string, V1::OutputFormat> expectedOutputFormat = V1::OutputFormat.Docx;

        Assert.Equal(expectedDocument, parameters.Document);
        Assert.Equal(expectedFields.Count, parameters.Fields.Count);
        for (int i = 0; i < expectedFields.Count; i++)
        {
            Assert.Equal(expectedFields[i], parameters.Fields[i]);
        }
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1::V1AnnotateParams
        {
            Document = new() { Base64 = "base64", Url = "url" },
            Fields =
            [
                new()
                {
                    Type = V1::Type.Text,
                    Value = "string",
                    ID = "id",
                    Group = "group",
                    Options = new() { Height = 0, Width = 0 },
                },
            ],
        };

        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1::V1AnnotateParams
        {
            Document = new() { Base64 = "base64", Url = "url" },
            Fields =
            [
                new()
                {
                    Type = V1::Type.Text,
                    Value = "string",
                    ID = "id",
                    Group = "group",
                    Options = new() { Height = 0, Width = 0 },
                },
            ],

            // Null should be interpreted as omitted for these properties
            OutputFormat = null,
        };

        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void Url_Works()
    {
        V1::V1AnnotateParams parameters = new()
        {
            Document = new() { Base64 = "base64", Url = "url" },
            Fields =
            [
                new()
                {
                    Type = V1::Type.Text,
                    Value = "string",
                    ID = "id",
                    Group = "group",
                    Options = new() { Height = 0, Width = 0 },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/superdoc/v1/annotate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1::V1AnnotateParams
        {
            Document = new() { Base64 = "base64", Url = "url" },
            Fields =
            [
                new()
                {
                    Type = V1::Type.Text,
                    Value = "string",
                    ID = "id",
                    Group = "group",
                    Options = new() { Height = 0, Width = 0 },
                },
            ],
            OutputFormat = V1::OutputFormat.Docx,
        };

        V1::V1AnnotateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1::Document { Base64 = "base64", Url = "url" };

        string expectedBase64 = "base64";
        string expectedUrl = "url";

        Assert.Equal(expectedBase64, model.Base64);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1::Document { Base64 = "base64", Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Document>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1::Document { Base64 = "base64", Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Document>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBase64 = "base64";
        string expectedUrl = "url";

        Assert.Equal(expectedBase64, deserialized.Base64);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1::Document { Base64 = "base64", Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1::Document { };

        Assert.Null(model.Base64);
        Assert.False(model.RawData.ContainsKey("base64"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1::Document { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1::Document
        {
            // Null should be interpreted as omitted for these properties
            Base64 = null,
            Url = null,
        };

        Assert.Null(model.Base64);
        Assert.False(model.RawData.ContainsKey("base64"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1::Document
        {
            // Null should be interpreted as omitted for these properties
            Base64 = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1::Document { Base64 = "base64", Url = "url" };

        V1::Document copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",
            ID = "id",
            Group = "group",
            Options = new() { Height = 0, Width = 0 },
        };

        ApiEnum<string, V1::Type> expectedType = V1::Type.Text;
        V1::FieldValue expectedValue = "string";
        string expectedID = "id";
        string expectedGroup = "group";
        V1::Options expectedOptions = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedOptions, model.Options);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",
            ID = "id",
            Group = "group",
            Options = new() { Height = 0, Width = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Field>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",
            ID = "id",
            Group = "group",
            Options = new() { Height = 0, Width = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Field>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, V1::Type> expectedType = V1::Type.Text;
        V1::FieldValue expectedValue = "string";
        string expectedID = "id";
        string expectedGroup = "group";
        V1::Options expectedOptions = new() { Height = 0, Width = 0 };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedOptions, deserialized.Options);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",
            ID = "id",
            Group = "group",
            Options = new() { Height = 0, Width = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1::Field { Type = V1::Type.Text, Value = "string" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1::Field { Type = V1::Type.Text, Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Group = null,
            Options = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Options);
        Assert.False(model.RawData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Group = null,
            Options = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1::Field
        {
            Type = V1::Type.Text,
            Value = "string",
            ID = "id",
            Group = "group",
            Options = new() { Height = 0, Width = 0 },
        };

        V1::Field copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(V1::Type.Text)]
    [InlineData(V1::Type.Image)]
    [InlineData(V1::Type.Date)]
    [InlineData(V1::Type.Number)]
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
    [InlineData(V1::Type.Image)]
    [InlineData(V1::Type.Date)]
    [InlineData(V1::Type.Number)]
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

public class FieldValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        V1::FieldValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        V1::FieldValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        V1::FieldValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::FieldValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        V1::FieldValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::FieldValue>(
            element,
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
        var model = new V1::Options { Height = 0, Width = 0 };

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1::Options { Height = 0, Width = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Options>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1::Options { Height = 0, Width = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::Options>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedHeight = 0;
        double expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1::Options { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1::Options { };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1::Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1::Options
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1::Options
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1::Options { Height = 0, Width = 0 };

        V1::Options copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputFormatTest : TestBase
{
    [Theory]
    [InlineData(V1::OutputFormat.Docx)]
    [InlineData(V1::OutputFormat.Pdf)]
    public void Validation_Works(V1::OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::OutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1::OutputFormat.Docx)]
    [InlineData(V1::OutputFormat.Pdf)]
    public void SerializationRoundtrip_Works(V1::OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::OutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
