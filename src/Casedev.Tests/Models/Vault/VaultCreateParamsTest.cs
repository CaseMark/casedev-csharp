using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",
            Description = "Repository for all client contract reviews and analysis",
            EmbeddingModel = EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2,
            EnableGraph = true,
            EnableIndexing = true,
            GroupID = "grp_abc123",
            Metadata = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "containsPHI": true,
                  "hipaaCompliant": true
                }
                """
            ),
        };

        string expectedName = "Contract Review Archive";
        string expectedDescription = "Repository for all client contract reviews and analysis";
        ApiEnum<string, EmbeddingModel> expectedEmbeddingModel =
            EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2;
        bool expectedEnableGraph = true;
        bool expectedEnableIndexing = true;
        string expectedGroupID = "grp_abc123";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "containsPHI": true,
              "hipaaCompliant": true
            }
            """
        );

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEmbeddingModel, parameters.EmbeddingModel);
        Assert.Equal(expectedEnableGraph, parameters.EnableGraph);
        Assert.Equal(expectedEnableIndexing, parameters.EnableIndexing);
        Assert.Equal(expectedGroupID, parameters.GroupID);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultCreateParams { Name = "Contract Review Archive" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EmbeddingModel);
        Assert.False(parameters.RawBodyData.ContainsKey("embeddingModel"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.EnableIndexing);
        Assert.False(parameters.RawBodyData.ContainsKey("enableIndexing"));
        Assert.Null(parameters.GroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("groupId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",

            // Null should be interpreted as omitted for these properties
            Description = null,
            EmbeddingModel = null,
            EnableGraph = null,
            EnableIndexing = null,
            GroupID = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EmbeddingModel);
        Assert.False(parameters.RawBodyData.ContainsKey("embeddingModel"));
        Assert.Null(parameters.EnableGraph);
        Assert.False(parameters.RawBodyData.ContainsKey("enableGraph"));
        Assert.Null(parameters.EnableIndexing);
        Assert.False(parameters.RawBodyData.ContainsKey("enableIndexing"));
        Assert.Null(parameters.GroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("groupId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultCreateParams parameters = new() { Name = "Contract Review Archive" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/vault"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultCreateParams
        {
            Name = "Contract Review Archive",
            Description = "Repository for all client contract reviews and analysis",
            EmbeddingModel = EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2,
            EnableGraph = true,
            EnableIndexing = true,
            GroupID = "grp_abc123",
            Metadata = JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "containsPHI": true,
                  "hipaaCompliant": true
                }
                """
            ),
        };

        VaultCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EmbeddingModelTest : TestBase
{
    [Theory]
    [InlineData(EmbeddingModel.OpenAITextEmbedding3Small)]
    [InlineData(EmbeddingModel.OpenAITextEmbedding3Large)]
    [InlineData(EmbeddingModel.VoyageVoyage3_5)]
    [InlineData(EmbeddingModel.VoyageVoyageLaw2)]
    [InlineData(EmbeddingModel.CohereEmbedV4_0)]
    [InlineData(EmbeddingModel.GoogleGeminiEmbedding2)]
    [InlineData(EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2)]
    public void Validation_Works(EmbeddingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmbeddingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmbeddingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmbeddingModel.OpenAITextEmbedding3Small)]
    [InlineData(EmbeddingModel.OpenAITextEmbedding3Large)]
    [InlineData(EmbeddingModel.VoyageVoyage3_5)]
    [InlineData(EmbeddingModel.VoyageVoyageLaw2)]
    [InlineData(EmbeddingModel.CohereEmbedV4_0)]
    [InlineData(EmbeddingModel.GoogleGeminiEmbedding2)]
    [InlineData(EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2)]
    public void SerializationRoundtrip_Works(EmbeddingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmbeddingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmbeddingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EmbeddingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EmbeddingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
