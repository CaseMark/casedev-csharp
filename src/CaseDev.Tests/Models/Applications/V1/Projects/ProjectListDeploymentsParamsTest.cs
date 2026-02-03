using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Models.Applications.V1.Projects;

public class ProjectListDeploymentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListDeploymentsParams
        {
            ID = "id",
            Limit = 0,
            State = "state",
            Target = ProjectListDeploymentsParamsTarget.Production,
        };

        string expectedID = "id";
        double expectedLimit = 0;
        string expectedState = "state";
        ApiEnum<string, ProjectListDeploymentsParamsTarget> expectedTarget =
            ProjectListDeploymentsParamsTarget.Production;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedTarget, parameters.Target);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectListDeploymentsParams { ID = "id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawQueryData.ContainsKey("target"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectListDeploymentsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            State = null,
            Target = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawQueryData.ContainsKey("target"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectListDeploymentsParams parameters = new()
        {
            ID = "id",
            Limit = 0,
            State = "state",
            Target = ProjectListDeploymentsParamsTarget.Production,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/applications/v1/projects/id/deployments?limit=0&state=state&target=production"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListDeploymentsParams
        {
            ID = "id",
            Limit = 0,
            State = "state",
            Target = ProjectListDeploymentsParamsTarget.Production,
        };

        ProjectListDeploymentsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProjectListDeploymentsParamsTargetTest : TestBase
{
    [Theory]
    [InlineData(ProjectListDeploymentsParamsTarget.Production)]
    [InlineData(ProjectListDeploymentsParamsTarget.Staging)]
    public void Validation_Works(ProjectListDeploymentsParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectListDeploymentsParamsTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectListDeploymentsParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectListDeploymentsParamsTarget.Production)]
    [InlineData(ProjectListDeploymentsParamsTarget.Staging)]
    public void SerializationRoundtrip_Works(ProjectListDeploymentsParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectListDeploymentsParamsTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectListDeploymentsParamsTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectListDeploymentsParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectListDeploymentsParamsTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
