using System;
using CaseDev.Models.Convert.V1.Jobs;

namespace CaseDev.Tests.Models.Convert.V1.Jobs;

public class JobRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        JobRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/jobs/id"), url);
    }
}
