using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1ResearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedModel = "model";
        string expectedResearchID = "researchId";
        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedResearchID, model.ResearchID);
        Assert.NotNull(model.Results);
        Assert.True(JsonElement.DeepEquals(expectedResults, model.Results.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ResearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModel = "model";
        string expectedResearchID = "researchId";
        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedResearchID, deserialized.ResearchID);
        Assert.NotNull(deserialized.Results);
        Assert.True(JsonElement.DeepEquals(expectedResults, deserialized.Results.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ResearchResponse { };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.ResearchID);
        Assert.False(model.RawData.ContainsKey("researchId"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ResearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ResearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            ResearchID = null,
            Results = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.ResearchID);
        Assert.False(model.RawData.ContainsKey("researchId"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ResearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            ResearchID = null,
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        V1ResearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
