using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Translate.V1;

namespace CaseDev.Tests.Models.Translate.V1;

public class V1ListLanguagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            Data = new() { Languages = [new() { LanguageValue = "language", Name = "name" }] },
        };

        V1ListLanguagesResponseData expectedData = new()
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            Data = new() { Languages = [new() { LanguageValue = "language", Name = "name" }] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListLanguagesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            Data = new() { Languages = [new() { LanguageValue = "language", Name = "name" }] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListLanguagesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        V1ListLanguagesResponseData expectedData = new()
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            Data = new() { Languages = [new() { LanguageValue = "language", Name = "name" }] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListLanguagesResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListLanguagesResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListLanguagesResponse
        {
            Data = new() { Languages = [new() { LanguageValue = "language", Name = "name" }] },
        };

        V1ListLanguagesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1ListLanguagesResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        List<Language> expectedLanguages = [new() { LanguageValue = "language", Name = "name" }];

        Assert.NotNull(model.Languages);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListLanguagesResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListLanguagesResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Language> expectedLanguages = [new() { LanguageValue = "language", Name = "name" }];

        Assert.NotNull(deserialized.Languages);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListLanguagesResponseData { };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListLanguagesResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            // Null should be interpreted as omitted for these properties
            Languages = null,
        };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            // Null should be interpreted as omitted for these properties
            Languages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListLanguagesResponseData
        {
            Languages = [new() { LanguageValue = "language", Name = "name" }],
        };

        V1ListLanguagesResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LanguageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Language { LanguageValue = "language", Name = "name" };

        string expectedLanguageValue = "language";
        string expectedName = "name";

        Assert.Equal(expectedLanguageValue, model.LanguageValue);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Language { LanguageValue = "language", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Language>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Language { LanguageValue = "language", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Language>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLanguageValue = "language";
        string expectedName = "name";

        Assert.Equal(expectedLanguageValue, deserialized.LanguageValue);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Language { LanguageValue = "language", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Language { };

        Assert.Null(model.LanguageValue);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Language { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Language
        {
            // Null should be interpreted as omitted for these properties
            LanguageValue = null,
            Name = null,
        };

        Assert.Null(model.LanguageValue);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Language
        {
            // Null should be interpreted as omitted for these properties
            LanguageValue = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Language { LanguageValue = "language", Name = "name" };

        Language copied = new(model);

        Assert.Equal(model, copied);
    }
}
