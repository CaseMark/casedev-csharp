using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultConfirmUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultConfirmUploadParams
        {
            ID = "id",
            ObjectID = "objectId",
            Body = new UnionMember0()
            {
                SizeBytes = 1,
                Success = Success.True,
                ErrorCode = "errorCode",
                ErrorMessage = "errorMessage",
                Etag = "etag",
            },
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        Body expectedBody = new UnionMember0()
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        VaultConfirmUploadParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            Body = new UnionMember0()
            {
                SizeBytes = 1,
                Success = Success.True,
                ErrorCode = "errorCode",
                ErrorMessage = "errorMessage",
                Etag = "etag",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/upload/objectId/confirm"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultConfirmUploadParams
        {
            ID = "id",
            ObjectID = "objectId",
            Body = new UnionMember0()
            {
                SizeBytes = 1,
                Success = Success.True,
                ErrorCode = "errorCode",
                ErrorMessage = "errorMessage",
                Etag = "etag",
            },
        };

        VaultConfirmUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void UnionMember0ValidationWorks()
    {
        Body value = new UnionMember0()
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        Body value = new UnionMember1()
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember0SerializationRoundtripWorks()
    {
        Body value = new UnionMember0()
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        Body value = new UnionMember1()
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        long expectedSizeBytes = 1;
        ApiEnum<bool, Success> expectedSuccess = Success.True;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedEtag = "etag";

        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedEtag, model.Etag);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedSizeBytes = 1;
        ApiEnum<bool, Success> expectedSuccess = Success.True;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedEtag = "etag";

        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedEtag, deserialized.Etag);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember0 { SizeBytes = 1, Success = Success.True };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember0 { SizeBytes = 1, Success = Success.True };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            Etag = null,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            Etag = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember0
        {
            SizeBytes = 1,
            Success = Success.True,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Etag = "etag",
        };

        UnionMember0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SuccessTest : TestBase
{
    [Theory]
    [InlineData(Success.True)]
    public void Validation_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Success.True)]
    public void SerializationRoundtrip_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };

        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        ApiEnum<bool, UnionMember1Success> expectedSuccess = UnionMember1Success.False;
        string expectedEtag = "etag";
        long expectedSizeBytes = 1;

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedEtag, model.Etag);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        ApiEnum<bool, UnionMember1Success> expectedSuccess = UnionMember1Success.False;
        string expectedEtag = "etag";
        long expectedSizeBytes = 1;

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedEtag, deserialized.Etag);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
        };

        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,

            // Null should be interpreted as omitted for these properties
            Etag = null,
            SizeBytes = null,
        };

        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,

            // Null should be interpreted as omitted for these properties
            Etag = null,
            SizeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember1
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = UnionMember1Success.False,
            Etag = "etag",
            SizeBytes = 1,
        };

        UnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember1SuccessTest : TestBase
{
    [Theory]
    [InlineData(UnionMember1Success.False)]
    public void Validation_Works(UnionMember1Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, UnionMember1Success> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, UnionMember1Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1Success.False)]
    public void SerializationRoundtrip_Works(UnionMember1Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, UnionMember1Success> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, UnionMember1Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, UnionMember1Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, UnionMember1Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
