using System.Threading.Tasks;
using CaseDev.Models.Payments.V1.Parties;

namespace CaseDev.Tests.Services.Payments.V1;

public class PartyServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Payments.V1.Parties.Create(
            new() { Name = "name", Type = Type.Individual },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Parties.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Payments.V1.Parties.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Parties.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListPaymentMethods_Works()
    {
        await this.client.Payments.V1.Parties.ListPaymentMethods(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
