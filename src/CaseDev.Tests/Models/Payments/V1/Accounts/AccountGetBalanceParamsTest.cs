using System;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountGetBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountGetBalanceParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountGetBalanceParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/accounts/id/balance"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountGetBalanceParams { ID = "id" };

        AccountGetBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
