using System;
using Router.Models.Compute.V1.Instances;

namespace Router.Tests.Models.Compute.V1.Instances;

public class InstanceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InstanceRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        InstanceRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/instances/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InstanceRetrieveParams { ID = "id" };

        InstanceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
