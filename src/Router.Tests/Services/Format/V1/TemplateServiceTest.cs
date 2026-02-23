using System.Threading.Tasks;
using Router.Models.Format.V1.Templates;

namespace Router.Tests.Services.Format.V1;

public class TemplateServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var template = await this.client.Format.V1.Templates.Create(
            new()
            {
                Content = "content",
                Name = "name",
                Type = Type.Caption,
            },
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var template = await this.client.Format.V1.Templates.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var templates = await this.client.Format.V1.Templates.List(
            new(),
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }
}
