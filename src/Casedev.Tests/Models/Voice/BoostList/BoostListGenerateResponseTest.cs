using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Voice.BoostList;

namespace Casedev.Tests.Models.Voice.BoostList;

public class BoostListGenerateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BoostListGenerateResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = BoostListGenerateResponseSource.Transcript,
            SourceIds = ["string"],
        };

        List<BoostListGenerateResponseItem> expectedItems =
        [
            new()
            {
                BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                Category = "category",
                Word = "word",
            },
        ];
        ApiEnum<string, BoostListGenerateResponseSource> expectedSource =
            BoostListGenerateResponseSource.Transcript;
        List<string> expectedSourceIds = ["string"];

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.NotNull(model.SourceIds);
        Assert.Equal(expectedSourceIds.Count, model.SourceIds.Count);
        for (int i = 0; i < expectedSourceIds.Count; i++)
        {
            Assert.Equal(expectedSourceIds[i], model.SourceIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BoostListGenerateResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = BoostListGenerateResponseSource.Transcript,
            SourceIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListGenerateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BoostListGenerateResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = BoostListGenerateResponseSource.Transcript,
            SourceIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListGenerateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BoostListGenerateResponseItem> expectedItems =
        [
            new()
            {
                BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                Category = "category",
                Word = "word",
            },
        ];
        ApiEnum<string, BoostListGenerateResponseSource> expectedSource =
            BoostListGenerateResponseSource.Transcript;
        List<string> expectedSourceIds = ["string"];

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.NotNull(deserialized.SourceIds);
        Assert.Equal(expectedSourceIds.Count, deserialized.SourceIds.Count);
        for (int i = 0; i < expectedSourceIds.Count; i++)
        {
            Assert.Equal(expectedSourceIds[i], deserialized.SourceIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BoostListGenerateResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = BoostListGenerateResponseSource.Transcript,
            SourceIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BoostListGenerateResponse { };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.SourceIds);
        Assert.False(model.RawData.ContainsKey("source_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BoostListGenerateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BoostListGenerateResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Source = null,
            SourceIds = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.SourceIds);
        Assert.False(model.RawData.ContainsKey("source_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BoostListGenerateResponse
        {
            // Null should be interpreted as omitted for these properties
            Items = null,
            Source = null,
            SourceIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BoostListGenerateResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostListGenerateResponseItemBoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = BoostListGenerateResponseSource.Transcript,
            SourceIds = ["string"],
        };

        BoostListGenerateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BoostListGenerateResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            BoostParam = BoostListGenerateResponseItemBoostParam.Low,
            Category = "category",
            Word = "word",
        };

        ApiEnum<string, BoostListGenerateResponseItemBoostParam> expectedBoostParam =
            BoostListGenerateResponseItemBoostParam.Low;
        string expectedCategory = "category";
        string expectedWord = "word";

        Assert.Equal(expectedBoostParam, model.BoostParam);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedWord, model.Word);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            BoostParam = BoostListGenerateResponseItemBoostParam.Low,
            Category = "category",
            Word = "word",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListGenerateResponseItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            BoostParam = BoostListGenerateResponseItemBoostParam.Low,
            Category = "category",
            Word = "word",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListGenerateResponseItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BoostListGenerateResponseItemBoostParam> expectedBoostParam =
            BoostListGenerateResponseItemBoostParam.Low;
        string expectedCategory = "category";
        string expectedWord = "word";

        Assert.Equal(expectedBoostParam, deserialized.BoostParam);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedWord, deserialized.Word);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            BoostParam = BoostListGenerateResponseItemBoostParam.Low,
            Category = "category",
            Word = "word",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BoostListGenerateResponseItem { };

        Assert.Null(model.BoostParam);
        Assert.False(model.RawData.ContainsKey("boost_param"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Word);
        Assert.False(model.RawData.ContainsKey("word"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BoostListGenerateResponseItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            // Null should be interpreted as omitted for these properties
            BoostParam = null,
            Category = null,
            Word = null,
        };

        Assert.Null(model.BoostParam);
        Assert.False(model.RawData.ContainsKey("boost_param"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Word);
        Assert.False(model.RawData.ContainsKey("word"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            // Null should be interpreted as omitted for these properties
            BoostParam = null,
            Category = null,
            Word = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BoostListGenerateResponseItem
        {
            BoostParam = BoostListGenerateResponseItemBoostParam.Low,
            Category = "category",
            Word = "word",
        };

        BoostListGenerateResponseItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BoostListGenerateResponseItemBoostParamTest : TestBase
{
    [Theory]
    [InlineData(BoostListGenerateResponseItemBoostParam.Low)]
    [InlineData(BoostListGenerateResponseItemBoostParam.Default)]
    [InlineData(BoostListGenerateResponseItemBoostParam.High)]
    public void Validation_Works(BoostListGenerateResponseItemBoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateResponseItemBoostParam> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseItemBoostParam>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BoostListGenerateResponseItemBoostParam.Low)]
    [InlineData(BoostListGenerateResponseItemBoostParam.Default)]
    [InlineData(BoostListGenerateResponseItemBoostParam.High)]
    public void SerializationRoundtrip_Works(BoostListGenerateResponseItemBoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateResponseItemBoostParam> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseItemBoostParam>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseItemBoostParam>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseItemBoostParam>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BoostListGenerateResponseSourceTest : TestBase
{
    [Theory]
    [InlineData(BoostListGenerateResponseSource.Transcript)]
    public void Validation_Works(BoostListGenerateResponseSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateResponseSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostListGenerateResponseSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BoostListGenerateResponseSource.Transcript)]
    public void SerializationRoundtrip_Works(BoostListGenerateResponseSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateResponseSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostListGenerateResponseSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateResponseSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
