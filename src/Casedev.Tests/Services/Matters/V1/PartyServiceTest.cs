using System.Threading.Tasks;

namespace Casedev.Tests.Services.Matters.V1;

public class PartyServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.Parties.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Matters.V1.Parties.Retrieve(
            "partyId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Update_Works()
    {
        await this.client.Matters.V1.Parties.Update(
            "partyId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.Parties.List(new(), TestContext.Current.CancellationToken);
    }
}
