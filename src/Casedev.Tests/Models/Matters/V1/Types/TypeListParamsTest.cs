using System;
using Casedev.Models.Matters.V1.Types;

namespace Casedev.Tests.Models.Matters.V1.Types;

public class TypeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TypeListParams { Active = true };

        bool expectedActive = true;

        Assert.Equal(expectedActive, parameters.Active);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TypeListParams { };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TypeListParams
        {
            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawQueryData.ContainsKey("active"));
    }

    [Fact]
    public void Url_Works()
    {
        TypeListParams parameters = new() { Active = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/types?active=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TypeListParams { Active = true };

        TypeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
