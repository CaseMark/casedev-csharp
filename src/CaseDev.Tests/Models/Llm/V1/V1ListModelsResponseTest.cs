using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Llm.V1;

namespace CaseDev.Tests.Models.Llm.V1;

public class V1ListModelsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Object = "object",
                    OwnedBy = "owned_by",
                    Pricing = new()
                    {
                        Input = "input",
                        InputCacheRead = "input_cache_read",
                        Output = "output",
                    },
                },
            ],
            Object = "object",
        };

        List<V1ListModelsResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Object = "object",
                OwnedBy = "owned_by",
                Pricing = new()
                {
                    Input = "input",
                    InputCacheRead = "input_cache_read",
                    Output = "output",
                },
            },
        ];
        string expectedObject = "object";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedObject, model.Object);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Object = "object",
                    OwnedBy = "owned_by",
                    Pricing = new()
                    {
                        Input = "input",
                        InputCacheRead = "input_cache_read",
                        Output = "output",
                    },
                },
            ],
            Object = "object",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListModelsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Object = "object",
                    OwnedBy = "owned_by",
                    Pricing = new()
                    {
                        Input = "input",
                        InputCacheRead = "input_cache_read",
                        Output = "output",
                    },
                },
            ],
            Object = "object",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListModelsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<V1ListModelsResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Object = "object",
                OwnedBy = "owned_by",
                Pricing = new()
                {
                    Input = "input",
                    InputCacheRead = "input_cache_read",
                    Output = "output",
                },
            },
        ];
        string expectedObject = "object";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedObject, deserialized.Object);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Object = "object",
                    OwnedBy = "owned_by",
                    Pricing = new()
                    {
                        Input = "input",
                        InputCacheRead = "input_cache_read",
                        Output = "output",
                    },
                },
            ],
            Object = "object",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListModelsResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListModelsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListModelsResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Object = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListModelsResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Object = null,
        };

        model.Validate();
    }
}

public class V1ListModelsResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListModelsResponseData
        {
            ID = "id",
            Created = 0,
            Object = "object",
            OwnedBy = "owned_by",
            Pricing = new()
            {
                Input = "input",
                InputCacheRead = "input_cache_read",
                Output = "output",
            },
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedObject = "object";
        string expectedOwnedBy = "owned_by";
        Pricing expectedPricing = new()
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedOwnedBy, model.OwnedBy);
        Assert.Equal(expectedPricing, model.Pricing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListModelsResponseData
        {
            ID = "id",
            Created = 0,
            Object = "object",
            OwnedBy = "owned_by",
            Pricing = new()
            {
                Input = "input",
                InputCacheRead = "input_cache_read",
                Output = "output",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListModelsResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListModelsResponseData
        {
            ID = "id",
            Created = 0,
            Object = "object",
            OwnedBy = "owned_by",
            Pricing = new()
            {
                Input = "input",
                InputCacheRead = "input_cache_read",
                Output = "output",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListModelsResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedObject = "object";
        string expectedOwnedBy = "owned_by";
        Pricing expectedPricing = new()
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedOwnedBy, deserialized.OwnedBy);
        Assert.Equal(expectedPricing, deserialized.Pricing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListModelsResponseData
        {
            ID = "id",
            Created = 0,
            Object = "object",
            OwnedBy = "owned_by",
            Pricing = new()
            {
                Input = "input",
                InputCacheRead = "input_cache_read",
                Output = "output",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListModelsResponseData { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.OwnedBy);
        Assert.False(model.RawData.ContainsKey("owned_by"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListModelsResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListModelsResponseData
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Created = null,
            Object = null,
            OwnedBy = null,
            Pricing = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.OwnedBy);
        Assert.False(model.RawData.ContainsKey("owned_by"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListModelsResponseData
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Created = null,
            Object = null,
            OwnedBy = null,
            Pricing = null,
        };

        model.Validate();
    }
}

public class PricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pricing
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        string expectedInput = "input";
        string expectedInputCacheRead = "input_cache_read";
        string expectedOutput = "output";

        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedInputCacheRead, model.InputCacheRead);
        Assert.Equal(expectedOutput, model.Output);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pricing
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pricing
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInput = "input";
        string expectedInputCacheRead = "input_cache_read";
        string expectedOutput = "output";

        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedInputCacheRead, deserialized.InputCacheRead);
        Assert.Equal(expectedOutput, deserialized.Output);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pricing
        {
            Input = "input",
            InputCacheRead = "input_cache_read",
            Output = "output",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pricing { };

        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.InputCacheRead);
        Assert.False(model.RawData.ContainsKey("input_cache_read"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pricing { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            Input = null,
            InputCacheRead = null,
            Output = null,
        };

        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.InputCacheRead);
        Assert.False(model.RawData.ContainsKey("input_cache_read"));
        Assert.Null(model.Output);
        Assert.False(model.RawData.ContainsKey("output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            Input = null,
            InputCacheRead = null,
            Output = null,
        };

        model.Validate();
    }
}
