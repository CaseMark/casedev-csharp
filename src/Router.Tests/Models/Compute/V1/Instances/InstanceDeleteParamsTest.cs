using System;
using Router.Models.Compute.V1.Instances;

namespace Router.Tests.Models.Compute.V1.Instances;

public class InstanceDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InstanceDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        InstanceDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/instances/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InstanceDeleteParams { ID = "id" };

        InstanceDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
