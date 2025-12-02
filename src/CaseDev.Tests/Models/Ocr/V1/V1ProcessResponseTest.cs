using System;
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
}
