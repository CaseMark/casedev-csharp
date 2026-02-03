using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using V1 = CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1CreateEnvVarsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1::V1CreateEnvVarsParams
        {
            ID = "id",
            EnvVars =
            [
                new()
                {
                    Environment = V1::Environment.Production,
                    Key = "key",
                    Value = "value",
                    Description = "description",
                    IsSecret = true,
                },
            ],
        };

        string expectedID = "id";
        List<V1::EnvVar> expectedEnvVars =
        [
            new()
            {
                Environment = V1::Environment.Production,
                Key = "key",
                Value = "value",
                Description = "description",
                IsSecret = true,
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EnvVars);
        Assert.Equal(expectedEnvVars.Count, parameters.EnvVars.Count);
        for (int i = 0; i < expectedEnvVars.Count; i++)
        {
            Assert.Equal(expectedEnvVars[i], parameters.EnvVars[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1::V1CreateEnvVarsParams { ID = "id" };

        Assert.Null(parameters.EnvVars);
        Assert.False(parameters.RawBodyData.ContainsKey("envVars"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1::V1CreateEnvVarsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EnvVars = null,
        };

        Assert.Null(parameters.EnvVars);
        Assert.False(parameters.RawBodyData.ContainsKey("envVars"));
    }

    [Fact]
    public void Url_Works()
    {
        V1::V1CreateEnvVarsParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/projects/v1/id/env-vars"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1::V1CreateEnvVarsParams
        {
            ID = "id",
            EnvVars =
            [
                new()
                {
                    Environment = V1::Environment.Production,
                    Key = "key",
                    Value = "value",
                    Description = "description",
                    IsSecret = true,
                },
            ],
        };

        V1::V1CreateEnvVarsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnvVarTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
            Description = "description",
            IsSecret = true,
        };

        ApiEnum<string, V1::Environment> expectedEnvironment = V1::Environment.Production;
        string expectedKey = "key";
        string expectedValue = "value";
        string expectedDescription = "description";
        bool expectedIsSecret = true;

        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIsSecret, model.IsSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
            Description = "description",
            IsSecret = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::EnvVar>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
            Description = "description",
            IsSecret = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1::EnvVar>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, V1::Environment> expectedEnvironment = V1::Environment.Production;
        string expectedKey = "key";
        string expectedValue = "value";
        string expectedDescription = "description";
        bool expectedIsSecret = true;

        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIsSecret, deserialized.IsSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
            Description = "description",
            IsSecret = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.IsSecret);
        Assert.False(model.RawData.ContainsKey("isSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Description = null,
            IsSecret = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.IsSecret);
        Assert.False(model.RawData.ContainsKey("isSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Description = null,
            IsSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1::EnvVar
        {
            Environment = V1::Environment.Production,
            Key = "key",
            Value = "value",
            Description = "description",
            IsSecret = true,
        };

        V1::EnvVar copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnvironmentTest : TestBase
{
    [Theory]
    [InlineData(V1::Environment.Production)]
    [InlineData(V1::Environment.Preview)]
    [InlineData(V1::Environment.Development)]
    [InlineData(V1::Environment.Shared)]
    public void Validation_Works(V1::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Environment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1::Environment.Production)]
    [InlineData(V1::Environment.Preview)]
    [InlineData(V1::Environment.Development)]
    [InlineData(V1::Environment.Shared)]
    public void SerializationRoundtrip_Works(V1::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Environment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
