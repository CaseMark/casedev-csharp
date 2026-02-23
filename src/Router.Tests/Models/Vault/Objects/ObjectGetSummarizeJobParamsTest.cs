using System;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectGetSummarizeJobParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectGetSummarizeJobParams
        {
            ID = "id",
            ObjectID = "objectId",
            JobID = "jobId",
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        string expectedJobID = "jobId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedJobID, parameters.JobID);
    }

    [Fact]
    public void Url_Works()
    {
        ObjectGetSummarizeJobParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            JobID = "jobId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/vault/id/objects/objectId/summarize/jobId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectGetSummarizeJobParams
        {
            ID = "id",
            ObjectID = "objectId",
            JobID = "jobId",
        };

        ObjectGetSummarizeJobParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
