using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectDeleteParams
        {
            ID = "id",
            ObjectID = "objectId",
            Force = Force.True,
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        ApiEnum<string, Force> expectedForce = Force.True;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedForce, parameters.Force);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectDeleteParams { ID = "id", ObjectID = "objectId" };

        Assert.Null(parameters.Force);
        Assert.False(parameters.RawQueryData.ContainsKey("force"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectDeleteParams
        {
            ID = "id",
            ObjectID = "objectId",

            // Null should be interpreted as omitted for these properties
            Force = null,
        };

        Assert.Null(parameters.Force);
        Assert.False(parameters.RawQueryData.ContainsKey("force"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectDeleteParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            Force = Force.True,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId?force=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectDeleteParams
        {
            ID = "id",
            ObjectID = "objectId",
            Force = Force.True,
        };

        ObjectDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ForceTest : TestBase
{
    [Theory]
    [InlineData(Force.True)]
    public void Validation_Works(Force rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Force> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Force>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Force.True)]
    public void SerializationRoundtrip_Works(Force rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Force> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Force>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Force>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Force>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
