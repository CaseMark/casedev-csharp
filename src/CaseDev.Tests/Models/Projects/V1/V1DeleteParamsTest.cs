using System;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1DeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DeleteParams { ID = "id", DeleteDeployments = true };

        string expectedID = "id";
        bool expectedDeleteDeployments = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDeleteDeployments, parameters.DeleteDeployments);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1DeleteParams { ID = "id" };

        Assert.Null(parameters.DeleteDeployments);
        Assert.False(parameters.RawQueryData.ContainsKey("deleteDeployments"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1DeleteParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            DeleteDeployments = null,
        };

        Assert.Null(parameters.DeleteDeployments);
        Assert.False(parameters.RawQueryData.ContainsKey("deleteDeployments"));
    }

    [Fact]
    public void Url_Works()
    {
        V1DeleteParams parameters = new() { ID = "id", DeleteDeployments = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/projects/v1/id?deleteDeployments=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1DeleteParams { ID = "id", DeleteDeployments = true };

        V1DeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
