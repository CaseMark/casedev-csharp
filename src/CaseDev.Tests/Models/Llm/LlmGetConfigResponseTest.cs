using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Llm;

namespace CaseDev.Tests.Models.Llm;

public class LlmGetConfigResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LlmGetConfigResponse
        {
            Models =
            [
                new()
                {
                    ID = "id",
                    ModelType = "modelType",
                    Name = "name",
                    Description = "description",
                    Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        List<Model> expectedModels =
        [
            new()
            {
                ID = "id",
                ModelType = "modelType",
                Name = "name",
                Description = "description",
                Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.Equal(expectedModels.Count, model.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], model.Models[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LlmGetConfigResponse
        {
            Models =
            [
                new()
                {
                    ID = "id",
                    ModelType = "modelType",
                    Name = "name",
                    Description = "description",
                    Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlmGetConfigResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LlmGetConfigResponse
        {
            Models =
            [
                new()
                {
                    ID = "id",
                    ModelType = "modelType",
                    Name = "name",
                    Description = "description",
                    Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlmGetConfigResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Model> expectedModels =
        [
            new()
            {
                ID = "id",
                ModelType = "modelType",
                Name = "name",
                Description = "description",
                Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.Equal(expectedModels.Count, deserialized.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], deserialized.Models[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LlmGetConfigResponse
        {
            Models =
            [
                new()
                {
                    ID = "id",
                    ModelType = "modelType",
                    Name = "name",
                    Description = "description",
                    Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        model.Validate();
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
            Description = "description",
            Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
            Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedModelType = "modelType";
        string expectedName = "name";
        string expectedDescription = "description";
        JsonElement expectedPricing = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSpecification = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Pricing);
        Assert.True(JsonElement.DeepEquals(expectedPricing, model.Pricing.Value));
        Assert.NotNull(model.Specification);
        Assert.True(JsonElement.DeepEquals(expectedSpecification, model.Specification.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
            Description = "description",
            Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
            Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
            Description = "description",
            Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
            Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedModelType = "modelType";
        string expectedName = "name";
        string expectedDescription = "description";
        JsonElement expectedPricing = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSpecification = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Pricing);
        Assert.True(JsonElement.DeepEquals(expectedPricing, deserialized.Pricing.Value));
        Assert.NotNull(deserialized.Specification);
        Assert.True(
            JsonElement.DeepEquals(expectedSpecification, deserialized.Specification.Value)
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
            Description = "description",
            Pricing = JsonSerializer.Deserialize<JsonElement>("{}"),
            Specification = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.Specification);
        Assert.False(model.RawData.ContainsKey("specification"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Pricing = null,
            Specification = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.Specification);
        Assert.False(model.RawData.ContainsKey("specification"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Model
        {
            ID = "id",
            ModelType = "modelType",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Pricing = null,
            Specification = null,
        };

        model.Validate();
    }
}
