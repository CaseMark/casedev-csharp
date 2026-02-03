using System.Threading.Tasks;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Services.Payments.V1;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var account = await this.client.Payments.V1.Accounts.Create(
            new() { Name = "name", Type = Type.Trust },
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Accounts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Payments.V1.Accounts.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Accounts.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetBalance_Works()
    {
        var response = await this.client.Payments.V1.Accounts.GetBalance(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetLedger_Works()
    {
        var response = await this.client.Payments.V1.Accounts.GetLedger(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
