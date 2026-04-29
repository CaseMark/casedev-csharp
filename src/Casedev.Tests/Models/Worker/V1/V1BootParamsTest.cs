using System;
using Casedev.Models.Worker.V1;

namespace Casedev.Tests.Models.Worker.V1;

public class V1BootParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1BootParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        V1BootParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/worker/v1/id/boot"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1BootParams { ID = "id" };

        V1BootParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
