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
            }
        );
        template.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Format.V1.Templates.Retrieve("id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Format.V1.Templates.List();
    }
}
