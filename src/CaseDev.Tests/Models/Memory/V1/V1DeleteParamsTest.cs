using System;
using CaseDev.Models.Memory.V1;

namespace CaseDev.Tests.Models.Memory.V1;

public class V1DeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        V1DeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/memory/v1/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1DeleteParams { ID = "id" };

        V1DeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
