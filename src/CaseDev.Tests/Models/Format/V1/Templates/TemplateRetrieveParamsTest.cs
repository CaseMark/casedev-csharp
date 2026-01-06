using System;
using CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Tests.Models.Format.V1.Templates;

public class TemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/format/v1/templates/id"), url);
    }
}
