using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Ocr.V1;

namespace CaseDev.Tests.Models.Ocr.V1;

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
            Status = Status.Queued,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDocumentID = "document_id";
        string expectedEngine = "engine";
        DateTimeOffset expectedEstimatedCompletion = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        ApiEnum<string, Status> expectedStatus = Status.Queued;

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
            Status = Status.Queued,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(json);

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
            Status = Status.Queued,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ProcessResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDocumentID = "document_id";
        string expectedEngine = "engine";
        DateTimeOffset expectedEstimatedCompletion = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        ApiEnum<string, Status> expectedStatus = Status.Queued;

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
            Status = Status.Queued,
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
}
