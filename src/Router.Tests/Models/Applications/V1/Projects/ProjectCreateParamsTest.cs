using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Projects = Router.Models.Applications.V1.Projects;

namespace Router.Tests.Models.Applications.V1.Projects;

public class ProjectCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Projects::ProjectCreateParams
        {
            GitRepo = "gitRepo",
            Name = "name",
            BuildCommand = "buildCommand",
            EnvironmentVariables =
            [
                new()
                {
                    Key = "key",
                    Target = [Projects::Target.Production],
                    Value = "value",
                    Type = Projects::Type.Plain,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            InstallCommand = "installCommand",
            OutputDirectory = "outputDirectory",
            RootDirectory = "rootDirectory",
        };

        string expectedGitRepo = "gitRepo";
        string expectedName = "name";
        string expectedBuildCommand = "buildCommand";
        List<Projects::EnvironmentVariable> expectedEnvironmentVariables =
        [
            new()
            {
                Key = "key",
                Target = [Projects::Target.Production],
                Value = "value",
                Type = Projects::Type.Plain,
            },
        ];
        string expectedFramework = "framework";
        string expectedGitBranch = "gitBranch";
        string expectedInstallCommand = "installCommand";
        string expectedOutputDirectory = "outputDirectory";
        string expectedRootDirectory = "rootDirectory";

        Assert.Equal(expectedGitRepo, parameters.GitRepo);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBuildCommand, parameters.BuildCommand);
        Assert.NotNull(parameters.EnvironmentVariables);
        Assert.Equal(expectedEnvironmentVariables.Count, parameters.EnvironmentVariables.Count);
        for (int i = 0; i < expectedEnvironmentVariables.Count; i++)
        {
            Assert.Equal(expectedEnvironmentVariables[i], parameters.EnvironmentVariables[i]);
        }
        Assert.Equal(expectedFramework, parameters.Framework);
        Assert.Equal(expectedGitBranch, parameters.GitBranch);
        Assert.Equal(expectedInstallCommand, parameters.InstallCommand);
        Assert.Equal(expectedOutputDirectory, parameters.OutputDirectory);
        Assert.Equal(expectedRootDirectory, parameters.RootDirectory);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Projects::ProjectCreateParams { GitRepo = "gitRepo", Name = "name" };

        Assert.Null(parameters.BuildCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("buildCommand"));
        Assert.Null(parameters.EnvironmentVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("environmentVariables"));
        Assert.Null(parameters.Framework);
        Assert.False(parameters.RawBodyData.ContainsKey("framework"));
        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
        Assert.Null(parameters.InstallCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("installCommand"));
        Assert.Null(parameters.OutputDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("outputDirectory"));
        Assert.Null(parameters.RootDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDirectory"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Projects::ProjectCreateParams
        {
            GitRepo = "gitRepo",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            BuildCommand = null,
            EnvironmentVariables = null,
            Framework = null,
            GitBranch = null,
            InstallCommand = null,
            OutputDirectory = null,
            RootDirectory = null,
        };

        Assert.Null(parameters.BuildCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("buildCommand"));
        Assert.Null(parameters.EnvironmentVariables);
        Assert.False(parameters.RawBodyData.ContainsKey("environmentVariables"));
        Assert.Null(parameters.Framework);
        Assert.False(parameters.RawBodyData.ContainsKey("framework"));
        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
        Assert.Null(parameters.InstallCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("installCommand"));
        Assert.Null(parameters.OutputDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("outputDirectory"));
        Assert.Null(parameters.RootDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDirectory"));
    }

    [Fact]
    public void Url_Works()
    {
        Projects::ProjectCreateParams parameters = new() { GitRepo = "gitRepo", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Projects::ProjectCreateParams
        {
            GitRepo = "gitRepo",
            Name = "name",
            BuildCommand = "buildCommand",
            EnvironmentVariables =
            [
                new()
                {
                    Key = "key",
                    Target = [Projects::Target.Production],
                    Value = "value",
                    Type = Projects::Type.Plain,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            InstallCommand = "installCommand",
            OutputDirectory = "outputDirectory",
            RootDirectory = "rootDirectory",
        };

        Projects::ProjectCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnvironmentVariableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
            Type = Projects::Type.Plain,
        };

        string expectedKey = "key";
        List<ApiEnum<string, Projects::Target>> expectedTarget = [Projects::Target.Production];
        string expectedValue = "value";
        ApiEnum<string, Projects::Type> expectedType = Projects::Type.Plain;

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
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
            Type = Projects::Type.Plain,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::EnvironmentVariable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
            Type = Projects::Type.Plain,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::EnvironmentVariable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        List<ApiEnum<string, Projects::Target>> expectedTarget = [Projects::Target.Production];
        string expectedValue = "value";
        ApiEnum<string, Projects::Type> expectedType = Projects::Type.Plain;

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
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
            Type = Projects::Type.Plain,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
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
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Projects::EnvironmentVariable
        {
            Key = "key",
            Target = [Projects::Target.Production],
            Value = "value",
            Type = Projects::Type.Plain,
        };

        Projects::EnvironmentVariable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTest : TestBase
{
    [Theory]
    [InlineData(Projects::Target.Production)]
    [InlineData(Projects::Target.Preview)]
    [InlineData(Projects::Target.Development)]
    public void Validation_Works(Projects::Target rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Target> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Target>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Projects::Target.Production)]
    [InlineData(Projects::Target.Preview)]
    [InlineData(Projects::Target.Development)]
    public void SerializationRoundtrip_Works(Projects::Target rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Target> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Target>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Target>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Target>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Projects::Type.Plain)]
    [InlineData(Projects::Type.Encrypted)]
    [InlineData(Projects::Type.Secret)]
    public void Validation_Works(Projects::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Projects::Type.Plain)]
    [InlineData(Projects::Type.Encrypted)]
    [InlineData(Projects::Type.Secret)]
    public void SerializationRoundtrip_Works(Projects::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
