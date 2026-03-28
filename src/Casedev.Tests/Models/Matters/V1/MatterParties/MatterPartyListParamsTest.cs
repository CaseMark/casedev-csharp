using System;
using Casedev.Models.Matters.V1.MatterParties;

namespace Casedev.Tests.Models.Matters.V1.MatterParties;

public class MatterPartyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatterPartyListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MatterPartyListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id/parties"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatterPartyListParams { ID = "id" };

        MatterPartyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
