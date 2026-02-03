using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",
            SourceType = SourceType.GitHub,
            BuildCommand = "buildCommand",
            DefaultMemory = "defaultMemory",
            DefaultVcpu = "defaultVcpu",
            Description = "description",
            Framework = "framework",
            GitHubBranch = "githubBranch",
            GitHubRepo = "githubRepo",
            InstallCommand = "installCommand",
            RootDirectory = "rootDirectory",
            S3SourceBucket = "s3SourceBucket",
            S3SourcePrefix = "s3SourcePrefix",
            StartCommand = "startCommand",
            ThurgoodSessionID = "thurgoodSessionId",
        };

        string expectedName = "name";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.GitHub;
        string expectedBuildCommand = "buildCommand";
        string expectedDefaultMemory = "defaultMemory";
        string expectedDefaultVcpu = "defaultVcpu";
        string expectedDescription = "description";
        string expectedFramework = "framework";
        string expectedGitHubBranch = "githubBranch";
        string expectedGitHubRepo = "githubRepo";
        string expectedInstallCommand = "installCommand";
        string expectedRootDirectory = "rootDirectory";
        string expectedS3SourceBucket = "s3SourceBucket";
        string expectedS3SourcePrefix = "s3SourcePrefix";
        string expectedStartCommand = "startCommand";
        string expectedThurgoodSessionID = "thurgoodSessionId";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSourceType, parameters.SourceType);
        Assert.Equal(expectedBuildCommand, parameters.BuildCommand);
        Assert.Equal(expectedDefaultMemory, parameters.DefaultMemory);
        Assert.Equal(expectedDefaultVcpu, parameters.DefaultVcpu);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFramework, parameters.Framework);
        Assert.Equal(expectedGitHubBranch, parameters.GitHubBranch);
        Assert.Equal(expectedGitHubRepo, parameters.GitHubRepo);
        Assert.Equal(expectedInstallCommand, parameters.InstallCommand);
        Assert.Equal(expectedRootDirectory, parameters.RootDirectory);
        Assert.Equal(expectedS3SourceBucket, parameters.S3SourceBucket);
        Assert.Equal(expectedS3SourcePrefix, parameters.S3SourcePrefix);
        Assert.Equal(expectedStartCommand, parameters.StartCommand);
        Assert.Equal(expectedThurgoodSessionID, parameters.ThurgoodSessionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateParams { Name = "name", SourceType = SourceType.GitHub };

        Assert.Null(parameters.BuildCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("buildCommand"));
        Assert.Null(parameters.DefaultMemory);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultMemory"));
        Assert.Null(parameters.DefaultVcpu);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultVcpu"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Framework);
        Assert.False(parameters.RawBodyData.ContainsKey("framework"));
        Assert.Null(parameters.GitHubBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("githubBranch"));
        Assert.Null(parameters.GitHubRepo);
        Assert.False(parameters.RawBodyData.ContainsKey("githubRepo"));
        Assert.Null(parameters.InstallCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("installCommand"));
        Assert.Null(parameters.RootDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDirectory"));
        Assert.Null(parameters.S3SourceBucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3SourceBucket"));
        Assert.Null(parameters.S3SourcePrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("s3SourcePrefix"));
        Assert.Null(parameters.StartCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("startCommand"));
        Assert.Null(parameters.ThurgoodSessionID);
        Assert.False(parameters.RawBodyData.ContainsKey("thurgoodSessionId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",
            SourceType = SourceType.GitHub,

            // Null should be interpreted as omitted for these properties
            BuildCommand = null,
            DefaultMemory = null,
            DefaultVcpu = null,
            Description = null,
            Framework = null,
            GitHubBranch = null,
            GitHubRepo = null,
            InstallCommand = null,
            RootDirectory = null,
            S3SourceBucket = null,
            S3SourcePrefix = null,
            StartCommand = null,
            ThurgoodSessionID = null,
        };

        Assert.Null(parameters.BuildCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("buildCommand"));
        Assert.Null(parameters.DefaultMemory);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultMemory"));
        Assert.Null(parameters.DefaultVcpu);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultVcpu"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Framework);
        Assert.False(parameters.RawBodyData.ContainsKey("framework"));
        Assert.Null(parameters.GitHubBranch);
        Assert.False(parameters.RawBodyData.ContainsKey("githubBranch"));
        Assert.Null(parameters.GitHubRepo);
        Assert.False(parameters.RawBodyData.ContainsKey("githubRepo"));
        Assert.Null(parameters.InstallCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("installCommand"));
        Assert.Null(parameters.RootDirectory);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDirectory"));
        Assert.Null(parameters.S3SourceBucket);
        Assert.False(parameters.RawBodyData.ContainsKey("s3SourceBucket"));
        Assert.Null(parameters.S3SourcePrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("s3SourcePrefix"));
        Assert.Null(parameters.StartCommand);
        Assert.False(parameters.RawBodyData.ContainsKey("startCommand"));
        Assert.Null(parameters.ThurgoodSessionID);
        Assert.False(parameters.RawBodyData.ContainsKey("thurgoodSessionId"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateParams parameters = new() { Name = "name", SourceType = SourceType.GitHub };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/projects/v1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateParams
        {
            Name = "name",
            SourceType = SourceType.GitHub,
            BuildCommand = "buildCommand",
            DefaultMemory = "defaultMemory",
            DefaultVcpu = "defaultVcpu",
            Description = "description",
            Framework = "framework",
            GitHubBranch = "githubBranch",
            GitHubRepo = "githubRepo",
            InstallCommand = "installCommand",
            RootDirectory = "rootDirectory",
            S3SourceBucket = "s3SourceBucket",
            S3SourcePrefix = "s3SourcePrefix",
            StartCommand = "startCommand",
            ThurgoodSessionID = "thurgoodSessionId",
        };

        V1CreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.GitHub)]
    [InlineData(SourceType.Thurgood)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.GitHub)]
    [InlineData(SourceType.Thurgood)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
