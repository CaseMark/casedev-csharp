using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Applications.V1.Deployments;

namespace Casedev.Tests.Models.Applications.V1.Deployments;

public class DeploymentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentListParams
        {
            ProjectID = "projectId",
            Limit = 0,
            State = "state",
            Target = DeploymentListParamsTarget.Production,
        };

        string expectedProjectID = "projectId";
        double expectedLimit = 0;
        string expectedState = "state";
        ApiEnum<string, DeploymentListParamsTarget> expectedTarget =
            DeploymentListParamsTarget.Production;

        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedTarget, parameters.Target);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentListParams { ProjectID = "projectId" };

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
        var parameters = new DeploymentListParams
        {
            ProjectID = "projectId",

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
        DeploymentListParams parameters = new()
        {
            ProjectID = "projectId",
            Limit = 0,
            State = "state",
            Target = DeploymentListParamsTarget.Production,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/applications/v1/deployments?projectId=projectId&limit=0&state=state&target=production"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentListParams
        {
            ProjectID = "projectId",
            Limit = 0,
            State = "state",
            Target = DeploymentListParamsTarget.Production,
        };

        DeploymentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DeploymentListParamsTargetTest : TestBase
{
    [Theory]
    [InlineData(DeploymentListParamsTarget.Production)]
    [InlineData(DeploymentListParamsTarget.Staging)]
    public void Validation_Works(DeploymentListParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentListParamsTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeploymentListParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeploymentListParamsTarget.Production)]
    [InlineData(DeploymentListParamsTarget.Staging)]
    public void SerializationRoundtrip_Works(DeploymentListParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentListParamsTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeploymentListParamsTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeploymentListParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeploymentListParamsTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
