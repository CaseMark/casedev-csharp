using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Deployments;

namespace CaseDev.Tests.Models.Applications.V1.Deployments;

public class DeploymentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            ProjectID = "projectId",
            Ref = "ref",
            Target = Target.Production,
        };

        string expectedProjectID = "projectId";
        string expectedRef = "ref";
        ApiEnum<string, Target> expectedTarget = Target.Production;

        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedRef, parameters.Ref);
        Assert.Equal(expectedTarget, parameters.Target);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentCreateParams { ProjectID = "projectId" };

        Assert.Null(parameters.Ref);
        Assert.False(parameters.RawBodyData.ContainsKey("ref"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawBodyData.ContainsKey("target"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            ProjectID = "projectId",

            // Null should be interpreted as omitted for these properties
            Ref = null,
            Target = null,
        };

        Assert.Null(parameters.Ref);
        Assert.False(parameters.RawBodyData.ContainsKey("ref"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawBodyData.ContainsKey("target"));
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentCreateParams parameters = new() { ProjectID = "projectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/deployments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            ProjectID = "projectId",
            Ref = "ref",
            Target = Target.Production,
        };

        DeploymentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TargetTest : TestBase
{
    [Theory]
    [InlineData(Target.Production)]
    [InlineData(Target.Preview)]
    public void Validation_Works(Target rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Target> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Target>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Target.Production)]
    [InlineData(Target.Preview)]
    public void SerializationRoundtrip_Works(Target rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Target> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Target>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Target>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Target>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
