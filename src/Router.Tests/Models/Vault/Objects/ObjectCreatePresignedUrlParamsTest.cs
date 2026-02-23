using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

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
            SizeBytes = 1,
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        string expectedContentType = "contentType";
        long expectedExpiresIn = 60;
        ApiEnum<string, Operation> expectedOperation = Operation.Get;
        long expectedSizeBytes = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedContentType, parameters.ContentType);
        Assert.Equal(expectedExpiresIn, parameters.ExpiresIn);
        Assert.Equal(expectedOperation, parameters.Operation);
        Assert.Equal(expectedSizeBytes, parameters.SizeBytes);
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
        Assert.Null(parameters.SizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("sizeBytes"));
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
            SizeBytes = null,
        };

        Assert.Null(parameters.ContentType);
        Assert.False(parameters.RawBodyData.ContainsKey("contentType"));
        Assert.Null(parameters.ExpiresIn);
        Assert.False(parameters.RawBodyData.ContainsKey("expiresIn"));
        Assert.Null(parameters.Operation);
        Assert.False(parameters.RawBodyData.ContainsKey("operation"));
        Assert.Null(parameters.SizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectCreatePresignedUrlParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId/presigned-url"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectCreatePresignedUrlParams
        {
            ID = "id",
            ObjectID = "objectId",
            ContentType = "contentType",
            ExpiresIn = 60,
            Operation = Operation.Get,
            SizeBytes = 1,
        };

        ObjectCreatePresignedUrlParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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
