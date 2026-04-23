using System;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EndpointRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/webhooks/v1/endpoints/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointRetrieveParams { ID = "id" };

        EndpointRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
