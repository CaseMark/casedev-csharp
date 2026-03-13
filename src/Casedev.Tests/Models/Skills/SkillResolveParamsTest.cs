using System;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillResolveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillResolveParams { Q = "q", Limit = 1 };

        string expectedQ = "q";
        long expectedLimit = 1;

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillResolveParams { Q = "q" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillResolveParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillResolveParams parameters = new() { Q = "q", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/skills/resolve?q=q&limit=1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillResolveParams { Q = "q", Limit = 1 };

        SkillResolveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
