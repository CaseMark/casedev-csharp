using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Tests.Models.Vault.Graphrag;

public class GraphragGetStatsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            Communities = 0,
            Documents = 0,
            Entities = 0,
            LastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Relationships = 0,
            Status = Status.Processing,
        };

        long expectedCommunities = 0;
        long expectedDocuments = 0;
        long expectedEntities = 0;
        DateTimeOffset expectedLastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRelationships = 0;
        ApiEnum<string, Status> expectedStatus = Status.Processing;

        Assert.Equal(expectedCommunities, model.Communities);
        Assert.Equal(expectedDocuments, model.Documents);
        Assert.Equal(expectedEntities, model.Entities);
        Assert.Equal(expectedLastProcessed, model.LastProcessed);
        Assert.Equal(expectedRelationships, model.Relationships);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            Communities = 0,
            Documents = 0,
            Entities = 0,
            LastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Relationships = 0,
            Status = Status.Processing,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragGetStatsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            Communities = 0,
            Documents = 0,
            Entities = 0,
            LastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Relationships = 0,
            Status = Status.Processing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragGetStatsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCommunities = 0;
        long expectedDocuments = 0;
        long expectedEntities = 0;
        DateTimeOffset expectedLastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRelationships = 0;
        ApiEnum<string, Status> expectedStatus = Status.Processing;

        Assert.Equal(expectedCommunities, deserialized.Communities);
        Assert.Equal(expectedDocuments, deserialized.Documents);
        Assert.Equal(expectedEntities, deserialized.Entities);
        Assert.Equal(expectedLastProcessed, deserialized.LastProcessed);
        Assert.Equal(expectedRelationships, deserialized.Relationships);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            Communities = 0,
            Documents = 0,
            Entities = 0,
            LastProcessed = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Relationships = 0,
            Status = Status.Processing,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GraphragGetStatsResponse { };

        Assert.Null(model.Communities);
        Assert.False(model.RawData.ContainsKey("communities"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.LastProcessed);
        Assert.False(model.RawData.ContainsKey("lastProcessed"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GraphragGetStatsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            // Null should be interpreted as omitted for these properties
            Communities = null,
            Documents = null,
            Entities = null,
            LastProcessed = null,
            Relationships = null,
            Status = null,
        };

        Assert.Null(model.Communities);
        Assert.False(model.RawData.ContainsKey("communities"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.LastProcessed);
        Assert.False(model.RawData.ContainsKey("lastProcessed"));
        Assert.Null(model.Relationships);
        Assert.False(model.RawData.ContainsKey("relationships"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GraphragGetStatsResponse
        {
            // Null should be interpreted as omitted for these properties
            Communities = null,
            Documents = null,
            Entities = null,
            LastProcessed = null,
            Relationships = null,
            Status = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
