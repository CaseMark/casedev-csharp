using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Compute.V1;

public class InstanceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var instance = await this.client.Compute.V1.Instances.Create(
            new()
            {
                InstanceType = "gpu_1x_a10",
                Name = "ocr-batch-job",
                Region = "us-west-1",
            },
            TestContext.Current.CancellationToken
        );
        instance.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var instance = await this.client.Compute.V1.Instances.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        instance.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var instances = await this.client.Compute.V1.Instances.List(
            new(),
            TestContext.Current.CancellationToken
        );
        instances.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var instance = await this.client.Compute.V1.Instances.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        instance.Validate();
    }
}
