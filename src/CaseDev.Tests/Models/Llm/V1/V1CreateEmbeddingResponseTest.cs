using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Llm.V1;

namespace CaseDev.Tests.Models.Llm.V1;

public class V1CreateEmbeddingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            Data =
            [
                new()
                {
                    Embedding = [0],
                    Index = 0,
                    Object = "embedding",
                },
            ],
            Model = "model",
            Object = "list",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        List<Data> expectedData =
        [
            new()
            {
                Embedding = [0],
                Index = 0,
                Object = "embedding",
            },
        ];
        string expectedModel = "model";
        string expectedObject = "list";
        Usage expectedUsage = new() { PromptTokens = 0, TotalTokens = 0 };

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            Data =
            [
                new()
                {
                    Embedding = [0],
                    Index = 0,
                    Object = "embedding",
                },
            ],
            Model = "model",
            Object = "list",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateEmbeddingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            Data =
            [
                new()
                {
                    Embedding = [0],
                    Index = 0,
                    Object = "embedding",
                },
            ],
            Model = "model",
            Object = "list",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateEmbeddingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                Embedding = [0],
                Index = 0,
                Object = "embedding",
            },
        ];
        string expectedModel = "model";
        string expectedObject = "list";
        Usage expectedUsage = new() { PromptTokens = 0, TotalTokens = 0 };

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            Data =
            [
                new()
                {
                    Embedding = [0],
                    Index = 0,
                    Object = "embedding",
                },
            ],
            Model = "model",
            Object = "list",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateEmbeddingResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateEmbeddingResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Model = null,
            Object = null,
            Usage = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Model = null,
            Object = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1CreateEmbeddingResponse
        {
            Data =
            [
                new()
                {
                    Embedding = [0],
                    Index = 0,
                    Object = "embedding",
                },
            ],
            Model = "model",
            Object = "list",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        V1CreateEmbeddingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Embedding = [0],
            Index = 0,
            Object = "embedding",
        };

        List<double> expectedEmbedding = [0];
        long expectedIndex = 0;
        string expectedObject = "embedding";

        Assert.NotNull(model.Embedding);
        Assert.Equal(expectedEmbedding.Count, model.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], model.Embedding[i]);
        }
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedObject, model.Object);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Embedding = [0],
            Index = 0,
            Object = "embedding",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Embedding = [0],
            Index = 0,
            Object = "embedding",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<double> expectedEmbedding = [0];
        long expectedIndex = 0;
        string expectedObject = "embedding";

        Assert.NotNull(deserialized.Embedding);
        Assert.Equal(expectedEmbedding.Count, deserialized.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], deserialized.Embedding[i]);
        }
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedObject, deserialized.Object);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Embedding = [0],
            Index = 0,
            Object = "embedding",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.Embedding);
        Assert.False(model.RawData.ContainsKey("embedding"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Embedding = null,
            Index = null,
            Object = null,
        };

        Assert.Null(model.Embedding);
        Assert.False(model.RawData.ContainsKey("embedding"));
        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Embedding = null,
            Index = null,
            Object = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Embedding = [0],
            Index = 0,
            Object = "embedding",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { };

        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            PromptTokens = null,
            TotalTokens = null,
        };

        Assert.Null(model.PromptTokens);
        Assert.False(model.RawData.ContainsKey("prompt_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            PromptTokens = null,
            TotalTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}
