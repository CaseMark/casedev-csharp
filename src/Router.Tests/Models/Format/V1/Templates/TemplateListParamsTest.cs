using System;
using Router.Models.Format.V1.Templates;

namespace Router.Tests.Models.Format.V1.Templates;

public class TemplateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListParams { Type = "type" };

        string expectedType = "type";

        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams { };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateListParams parameters = new() { Type = "type" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/format/v1/templates?type=type"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateListParams { Type = "type" };

        TemplateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
