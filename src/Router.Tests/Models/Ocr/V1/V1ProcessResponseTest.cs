using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Ocr.V1;

namespace Router.Tests.Models.Ocr.V1;

public class V1ProcessResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ProcessResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentID = "document_id",
            Engine = "engine",
            EstimatedCompletion = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            Status = V1ProcessResponseStatus.Queued,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDocumentID = "document_id";
        string expectedEngine = "engine";
        DateTimeOffset expectedEstimatedCompletion = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        ApiEnum<string, V1ProcessResponseStatus> expectedStatus = V1ProcessResponseStatus.Queued;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDocumentID, model.DocumentID);
        Assert.Equal(expectedEngine, model.Engine);
        Assert.Equal(expectedEstimatedCompletion, model.EstimatedCompletion);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ProcessResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentID = "document_id",
            Engine = "engine",
            EstimatedCompletion = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            Status = V1ProcessResponseStatus.Queued,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ProcessResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentID = "document_id",
            Engine = "engine",
            EstimatedCompletion = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            Status = V1ProcessResponseStatus.Queued,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDocumentID = "document_id";
        string expectedEngine = "engine";
        DateTimeOffset expectedEstimatedCompletion = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        ApiEnum<string, V1ProcessResponseStatus> expectedStatus = V1ProcessResponseStatus.Queued;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDocumentID, deserialized.DocumentID);
        Assert.Equal(expectedEngine, deserialized.Engine);
        Assert.Equal(expectedEstimatedCompletion, deserialized.EstimatedCompletion);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ProcessResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentID = "document_id",
            Engine = "engine",
            EstimatedCompletion = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            Status = V1ProcessResponseStatus.Queued,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ProcessResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DocumentID);
        Assert.False(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.Engine);
        Assert.False(model.RawData.ContainsKey("engine"));
        Assert.Null(model.EstimatedCompletion);
        Assert.False(model.RawData.ContainsKey("estimated_completion"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("page_count"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ProcessResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ProcessResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DocumentID = null,
            Engine = null,
            EstimatedCompletion = null,
            PageCount = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DocumentID);
        Assert.False(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.Engine);
        Assert.False(model.RawData.ContainsKey("engine"));
        Assert.Null(model.EstimatedCompletion);
        Assert.False(model.RawData.ContainsKey("estimated_completion"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("page_count"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ProcessResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            DocumentID = null,
            Engine = null,
            EstimatedCompletion = null,
            PageCount = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ProcessResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentID = "document_id",
            Engine = "engine",
            EstimatedCompletion = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            Status = V1ProcessResponseStatus.Queued,
        };

        V1ProcessResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1ProcessResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(V1ProcessResponseStatus.Queued)]
    [InlineData(V1ProcessResponseStatus.Processing)]
    [InlineData(V1ProcessResponseStatus.Completed)]
    [InlineData(V1ProcessResponseStatus.Failed)]
    public void Validation_Works(V1ProcessResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ProcessResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ProcessResponseStatus.Queued)]
    [InlineData(V1ProcessResponseStatus.Processing)]
    [InlineData(V1ProcessResponseStatus.Completed)]
    [InlineData(V1ProcessResponseStatus.Failed)]
    public void SerializationRoundtrip_Works(V1ProcessResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ProcessResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ProcessResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
