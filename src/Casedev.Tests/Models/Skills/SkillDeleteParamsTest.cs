using System;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillDeleteParams { Slug = "slug" };

        string expectedSlug = "slug";

        Assert.Equal(expectedSlug, parameters.Slug);
    }

    [Fact]
    public void Url_Works()
    {
        SkillDeleteParams parameters = new() { Slug = "slug" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/skills/slug"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillDeleteParams { Slug = "slug" };

        SkillDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
