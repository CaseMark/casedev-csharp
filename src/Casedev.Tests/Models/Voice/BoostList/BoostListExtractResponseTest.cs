using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Voice.BoostList;

namespace Casedev.Tests.Models.Voice.BoostList;

public class BoostListExtractResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BoostListExtractResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = Source.Document,
            SourceIds = ["string"],
        };

        List<Item> expectedItems =
        [
            new()
            {
                BoostParam = BoostParam.Low,
                Category = "category",
                Word = "word",
            },
        ];
        ApiEnum<string, Source> expectedSource = Source.Document;
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
        var model = new BoostListExtractResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = Source.Document,
            SourceIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListExtractResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BoostListExtractResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = Source.Document,
            SourceIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BoostListExtractResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                BoostParam = BoostParam.Low,
                Category = "category",
                Word = "word",
            },
        ];
        ApiEnum<string, Source> expectedSource = Source.Document;
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
        var model = new BoostListExtractResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = Source.Document,
            SourceIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BoostListExtractResponse { };

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
        var model = new BoostListExtractResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BoostListExtractResponse
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
        var model = new BoostListExtractResponse
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
        var model = new BoostListExtractResponse
        {
            Items =
            [
                new()
                {
                    BoostParam = BoostParam.Low,
                    Category = "category",
                    Word = "word",
                },
            ],
            Source = Source.Document,
            SourceIds = ["string"],
        };

        BoostListExtractResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            BoostParam = BoostParam.Low,
            Category = "category",
            Word = "word",
        };

        ApiEnum<string, BoostParam> expectedBoostParam = BoostParam.Low;
        string expectedCategory = "category";
        string expectedWord = "word";

        Assert.Equal(expectedBoostParam, model.BoostParam);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedWord, model.Word);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            BoostParam = BoostParam.Low,
            Category = "category",
            Word = "word",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            BoostParam = BoostParam.Low,
            Category = "category",
            Word = "word",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, BoostParam> expectedBoostParam = BoostParam.Low;
        string expectedCategory = "category";
        string expectedWord = "word";

        Assert.Equal(expectedBoostParam, deserialized.BoostParam);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedWord, deserialized.Word);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            BoostParam = BoostParam.Low,
            Category = "category",
            Word = "word",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item { };

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
        var model = new Item { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
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
        var model = new Item
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
        var model = new Item
        {
            BoostParam = BoostParam.Low,
            Category = "category",
            Word = "word",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BoostParamTest : TestBase
{
    [Theory]
    [InlineData(BoostParam.Low)]
    [InlineData(BoostParam.Default)]
    [InlineData(BoostParam.High)]
    public void Validation_Works(BoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostParam> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BoostParam.Low)]
    [InlineData(BoostParam.Default)]
    [InlineData(BoostParam.High)]
    public void SerializationRoundtrip_Works(BoostParam rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostParam> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BoostParam>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Document)]
    [InlineData(Source.Text)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Document)]
    [InlineData(Source.Text)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
