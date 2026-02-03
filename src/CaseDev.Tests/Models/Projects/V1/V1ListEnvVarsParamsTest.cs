using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1ListEnvVarsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListEnvVarsParams
        {
            ID = "id",
            Environment = V1ListEnvVarsParamsEnvironment.Production,
        };

        string expectedID = "id";
        ApiEnum<string, V1ListEnvVarsParamsEnvironment> expectedEnvironment =
            V1ListEnvVarsParamsEnvironment.Production;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnvironment, parameters.Environment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListEnvVarsParams { ID = "id" };

        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawQueryData.ContainsKey("environment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListEnvVarsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Environment = null,
        };

        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawQueryData.ContainsKey("environment"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListEnvVarsParams parameters = new()
        {
            ID = "id",
            Environment = V1ListEnvVarsParamsEnvironment.Production,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/projects/v1/id/env-vars?environment=production"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListEnvVarsParams
        {
            ID = "id",
            Environment = V1ListEnvVarsParamsEnvironment.Production,
        };

        V1ListEnvVarsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class V1ListEnvVarsParamsEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(V1ListEnvVarsParamsEnvironment.Production)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Preview)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Development)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Shared)]
    public void Validation_Works(V1ListEnvVarsParamsEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListEnvVarsParamsEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListEnvVarsParamsEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ListEnvVarsParamsEnvironment.Production)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Preview)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Development)]
    [InlineData(V1ListEnvVarsParamsEnvironment.Shared)]
    public void SerializationRoundtrip_Works(V1ListEnvVarsParamsEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListEnvVarsParamsEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, V1ListEnvVarsParamsEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListEnvVarsParamsEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, V1ListEnvVarsParamsEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
