using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Tests.Models.Database.V1.Projects;

public class ProjectCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectCreateParams
        {
            Name = "litigation-docs-db",
            Description = "Production database for litigation document management",
            Region = Region.AwsUsEast1,
        };

        string expectedName = "litigation-docs-db";
        string expectedDescription = "Production database for litigation document management";
        ApiEnum<string, Region> expectedRegion = Region.AwsUsEast1;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRegion, parameters.Region);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProjectCreateParams { Name = "litigation-docs-db" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawBodyData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProjectCreateParams
        {
            Name = "litigation-docs-db",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Region = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawBodyData.ContainsKey("region"));
    }

    [Fact]
    public void Url_Works()
    {
        ProjectCreateParams parameters = new() { Name = "litigation-docs-db" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/database/v1/projects"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectCreateParams
        {
            Name = "litigation-docs-db",
            Description = "Production database for litigation document management",
            Region = Region.AwsUsEast1,
        };

        ProjectCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RegionTest : TestBase
{
    [Theory]
    [InlineData(Region.AwsUsEast1)]
    [InlineData(Region.AwsUsEast2)]
    [InlineData(Region.AwsUsWest2)]
    [InlineData(Region.AwsEuCentral1)]
    [InlineData(Region.AwsEuWest1)]
    [InlineData(Region.AwsEuWest2)]
    [InlineData(Region.AwsApSoutheast1)]
    [InlineData(Region.AwsApSoutheast2)]
    public void Validation_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Region.AwsUsEast1)]
    [InlineData(Region.AwsUsEast2)]
    [InlineData(Region.AwsUsWest2)]
    [InlineData(Region.AwsEuCentral1)]
    [InlineData(Region.AwsEuWest1)]
    [InlineData(Region.AwsEuWest2)]
    [InlineData(Region.AwsApSoutheast1)]
    [InlineData(Region.AwsApSoutheast2)]
    public void SerializationRoundtrip_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
