using System;
using CaseDev.Models.Convert.V1.Jobs;

namespace CaseDev.Tests.Models.Convert.V1.Jobs;

public class JobDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        JobDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/convert/v1/jobs/id"), url);
    }
}
