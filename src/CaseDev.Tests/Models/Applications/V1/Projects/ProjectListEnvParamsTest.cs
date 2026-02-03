using System;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Models.Applications.V1.Projects;

public class ProjectListEnvParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListEnvParams { ID = "id", Decrypt = true };

        string expectedID = "id";
        bool expectedDecrypt = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDecrypt, parameters.Decrypt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectListEnvParams { ID = "id" };

        Assert.Null(parameters.Decrypt);
        Assert.False(parameters.RawQueryData.ContainsKey("decrypt"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectListEnvParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Decrypt = null,
        };

        Assert.Null(parameters.Decrypt);
        Assert.False(parameters.RawQueryData.ContainsKey("decrypt"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListEnvParams parameters = new() { ID = "id", Decrypt = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/applications/v1/projects/id/env?decrypt=true"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListEnvParams { ID = "id", Decrypt = true };

        ProjectListEnvParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
