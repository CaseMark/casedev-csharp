using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Models.Applications.V1.Projects;

public class ProjectCreateDeploymentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectCreateDeploymentParams
        {
            ID = "id",
            EnvironmentVariables =
            [
                new()
                {
                    Key = "key",
                    Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
                    Value = "value",
                    Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
                },
            ],
        };

        string expectedID = "id";
        List<ProjectCreateDeploymentParamsEnvironmentVariable> expectedEnvironmentVariables =
        [
            new()
            {
                Key = "key",
                Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
                Value = "value",
                Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EnvironmentVariables);
        Assert.Equal(expectedEnvironmentVariables.Count, parameters.EnvironmentVariables.Count);
        for (int i = 0; i < expectedEnvironmentVariables.Count; i++)
        {
            Assert.Equal(expectedEnvironmentVariables[i], parameters.EnvironmentVariables[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectCreateDeploymentParams { ID = "id" };

        Assert.Null(parameters.EnvironmentVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("environmentVariables"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectCreateDeploymentParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EnvironmentVariables = null,
        };

        Assert.Null(parameters.EnvironmentVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("environmentVariables"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectCreateDeploymentParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id/deployments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectCreateDeploymentParams
        {
            ID = "id",
            EnvironmentVariables =
            [
                new()
                {
                    Key = "key",
                    Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
                    Value = "value",
                    Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
                },
            ],
        };

        ProjectCreateDeploymentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProjectCreateDeploymentParamsEnvironmentVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
            Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
        };

        string expectedKey = "key";
        List<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        > expectedTarget = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production];
        string expectedValue = "value";
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType> expectedType =
            ProjectCreateDeploymentParamsEnvironmentVariableType.Plain;

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedTarget.Count, model.Target.Count);
        for (int i = 0; i < expectedTarget.Count; i++)
        {
            Assert.Equal(expectedTarget[i], model.Target[i]);
        }
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
            Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProjectCreateDeploymentParamsEnvironmentVariable>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
            Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProjectCreateDeploymentParamsEnvironmentVariable>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        List<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        > expectedTarget = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production];
        string expectedValue = "value";
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType> expectedType =
            ProjectCreateDeploymentParamsEnvironmentVariableType.Plain;

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedTarget.Count, deserialized.Target.Count);
        for (int i = 0; i < expectedTarget.Count; i++)
        {
            Assert.Equal(expectedTarget[i], deserialized.Target[i]);
        }
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
            Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProjectCreateDeploymentParamsEnvironmentVariable
        {
            Key = "key",
            Target = [ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production],
            Value = "value",
            Type = ProjectCreateDeploymentParamsEnvironmentVariableType.Plain,
        };

        ProjectCreateDeploymentParamsEnvironmentVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectCreateDeploymentParamsEnvironmentVariableTargetTest : TestBase
{
    [Theory]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Preview)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Development)]
    public void Validation_Works(ProjectCreateDeploymentParamsEnvironmentVariableTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Production)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Preview)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableTarget.Development)]
    public void SerializationRoundtrip_Works(
        ProjectCreateDeploymentParamsEnvironmentVariableTarget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProjectCreateDeploymentParamsEnvironmentVariableTypeTest : TestBase
{
    [Theory]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Plain)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Encrypted)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Secret)]
    public void Validation_Works(ProjectCreateDeploymentParamsEnvironmentVariableType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Plain)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Encrypted)]
    [InlineData(ProjectCreateDeploymentParamsEnvironmentVariableType.Secret)]
    public void SerializationRoundtrip_Works(
        ProjectCreateDeploymentParamsEnvironmentVariableType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateDeploymentParamsEnvironmentVariableType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
