using System.Threading.Tasks;
using CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Tests.Services.Format.V1;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
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

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var template = await this.client.Format.V1.Templates.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Format.V1.Templates.List(
            new(),
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }
}
