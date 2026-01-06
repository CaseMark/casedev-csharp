using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectCreatePresignedUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectCreatePresignedUrlParams
        {
            ID = "id",
            ObjectID = "objectId",
            ContentType = "contentType",
            ExpiresIn = 60,
            Operation = Operation.Get,
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        string expectedContentType = "contentType";
        long expectedExpiresIn = 60;
        ApiEnum<string, Operation> expectedOperation = Operation.Get;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedContentType, parameters.ContentType);
        Assert.Equal(expectedExpiresIn, parameters.ExpiresIn);
        Assert.Equal(expectedOperation, parameters.Operation);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectCreatePresignedUrlParams { ID = "id", ObjectID = "objectId" };

        Assert.Null(parameters.ContentType);
        Assert.False(parameters.RawBodyData.ContainsKey("contentType"));
        Assert.Null(parameters.ExpiresIn);
        Assert.False(parameters.RawBodyData.ContainsKey("expiresIn"));
        Assert.Null(parameters.Operation);
        Assert.False(parameters.RawBodyData.ContainsKey("operation"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectCreatePresignedUrlParams
        {
            ID = "id",
            ObjectID = "objectId",

            // Null should be interpreted as omitted for these properties
            ContentType = null,
            ExpiresIn = null,
            Operation = null,
        };

        Assert.Null(parameters.ContentType);
        Assert.False(parameters.RawBodyData.ContainsKey("contentType"));
        Assert.Null(parameters.ExpiresIn);
        Assert.False(parameters.RawBodyData.ContainsKey("expiresIn"));
        Assert.Null(parameters.Operation);
        Assert.False(parameters.RawBodyData.ContainsKey("operation"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectCreatePresignedUrlParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId/presigned-url"), url);
    }
}

public class OperationTest : TestBase
{
    [Theory]
    [InlineData(Operation.Get)]
    [InlineData(Operation.Put)]
    [InlineData(Operation.Delete)]
    [InlineData(Operation.Head)]
    public void Validation_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operation.Get)]
    [InlineData(Operation.Put)]
    [InlineData(Operation.Delete)]
    [InlineData(Operation.Head)]
    public void SerializationRoundtrip_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
