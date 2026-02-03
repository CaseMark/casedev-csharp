using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Projects;

namespace CaseDev.Tests.Models.Applications.V1.Projects;

public class ProjectCreateEnvParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectCreateEnvParams
        {
            ID = "id",
            Key = "key",
            Target = [ProjectCreateEnvParamsTarget.Production],
            Value = "value",
            GitBranch = "gitBranch",
            Type = ProjectCreateEnvParamsType.Plain,
        };

        string expectedID = "id";
        string expectedKey = "key";
        List<ApiEnum<string, ProjectCreateEnvParamsTarget>> expectedTarget =
        [
            ProjectCreateEnvParamsTarget.Production,
        ];
        string expectedValue = "value";
        string expectedGitBranch = "gitBranch";
        ApiEnum<string, ProjectCreateEnvParamsType> expectedType = ProjectCreateEnvParamsType.Plain;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedKey, parameters.Key);
        Assert.Equal(expectedTarget.Count, parameters.Target.Count);
        for (int i = 0; i < expectedTarget.Count; i++)
        {
            Assert.Equal(expectedTarget[i], parameters.Target[i]);
        }
        Assert.Equal(expectedValue, parameters.Value);
        Assert.Equal(expectedGitBranch, parameters.GitBranch);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectCreateEnvParams
        {
            ID = "id",
            Key = "key",
            Target = [ProjectCreateEnvParamsTarget.Production],
            Value = "value",
        };

        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectCreateEnvParams
        {
            ID = "id",
            Key = "key",
            Target = [ProjectCreateEnvParamsTarget.Production],
            Value = "value",

            // Null should be interpreted as omitted for these properties
            GitBranch = null,
            Type = null,
        };

        Assert.Null(parameters.GitBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("gitBranch"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectCreateEnvParams parameters = new()
        {
            ID = "id",
            Key = "key",
            Target = [ProjectCreateEnvParamsTarget.Production],
            Value = "value",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/applications/v1/projects/id/env"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectCreateEnvParams
        {
            ID = "id",
            Key = "key",
            Target = [ProjectCreateEnvParamsTarget.Production],
            Value = "value",
            GitBranch = "gitBranch",
            Type = ProjectCreateEnvParamsType.Plain,
        };

        ProjectCreateEnvParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProjectCreateEnvParamsTargetTest : TestBase
{
    [Theory]
    [InlineData(ProjectCreateEnvParamsTarget.Production)]
    [InlineData(ProjectCreateEnvParamsTarget.Preview)]
    [InlineData(ProjectCreateEnvParamsTarget.Development)]
    public void Validation_Works(ProjectCreateEnvParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateEnvParamsTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectCreateEnvParamsTarget.Production)]
    [InlineData(ProjectCreateEnvParamsTarget.Preview)]
    [InlineData(ProjectCreateEnvParamsTarget.Development)]
    public void SerializationRoundtrip_Works(ProjectCreateEnvParamsTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateEnvParamsTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateEnvParamsTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProjectCreateEnvParamsTarget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProjectCreateEnvParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(ProjectCreateEnvParamsType.Plain)]
    [InlineData(ProjectCreateEnvParamsType.Encrypted)]
    [InlineData(ProjectCreateEnvParamsType.Secret)]
    public void Validation_Works(ProjectCreateEnvParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateEnvParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectCreateEnvParamsType.Plain)]
    [InlineData(ProjectCreateEnvParamsType.Encrypted)]
    [InlineData(ProjectCreateEnvParamsType.Secret)]
    public void SerializationRoundtrip_Works(ProjectCreateEnvParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectCreateEnvParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectCreateEnvParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
