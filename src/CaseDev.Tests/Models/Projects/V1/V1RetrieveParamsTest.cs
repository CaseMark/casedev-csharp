using System;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1RetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        V1RetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/projects/v1/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1RetrieveParams { ID = "id" };

        V1RetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
