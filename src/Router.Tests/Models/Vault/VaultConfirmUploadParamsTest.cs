using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Vault;

namespace Router.Tests.Models.Vault;

public class VaultConfirmUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultConfirmUploadParams
        {
            ID = "id",
            ObjectID = "objectId",
            Body = new VaultConfirmUploadSuccess()
            {
                SizeBytes = 1,
                Success = Success.True,
                Etag = "etag",
            },
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        Body expectedBody = new VaultConfirmUploadSuccess()
        {
            SizeBytes = 1,
            Success = Success.True,
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
            Body = new VaultConfirmUploadSuccess()
            {
                SizeBytes = 1,
                Success = Success.True,
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
            Body = new VaultConfirmUploadSuccess()
            {
                SizeBytes = 1,
                Success = Success.True,
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
    public void VaultConfirmUploadSuccessValidationWorks()
    {
        Body value = new VaultConfirmUploadSuccess()
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };
        value.Validate();
    }

    [Fact]
    public void VaultConfirmUploadFailureValidationWorks()
    {
        Body value = new VaultConfirmUploadFailure()
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };
        value.Validate();
    }

    [Fact]
    public void VaultConfirmUploadSuccessSerializationRoundtripWorks()
    {
        Body value = new VaultConfirmUploadSuccess()
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultConfirmUploadFailureSerializationRoundtripWorks()
    {
        Body value = new VaultConfirmUploadFailure()
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VaultConfirmUploadSuccessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };

        long expectedSizeBytes = 1;
        ApiEnum<bool, Success> expectedSuccess = Success.True;
        string expectedEtag = "etag";

        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedEtag, model.Etag);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadSuccess>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadSuccess>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedSizeBytes = 1;
        ApiEnum<bool, Success> expectedSuccess = Success.True;
        string expectedEtag = "etag";

        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedEtag, deserialized.Etag);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultConfirmUploadSuccess { SizeBytes = 1, Success = Success.True };

        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultConfirmUploadSuccess { SizeBytes = 1, Success = Success.True };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,

            // Null should be interpreted as omitted for these properties
            Etag = null,
        };

        Assert.Null(model.Etag);
        Assert.False(model.RawData.ContainsKey("etag"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,

            // Null should be interpreted as omitted for these properties
            Etag = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultConfirmUploadSuccess
        {
            SizeBytes = 1,
            Success = Success.True,
            Etag = "etag",
        };

        VaultConfirmUploadSuccess copied = new(model);

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

public class VaultConfirmUploadFailureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultConfirmUploadFailure
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };

        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        ApiEnum<bool, VaultConfirmUploadFailureSuccess> expectedSuccess =
            VaultConfirmUploadFailureSuccess.False;

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultConfirmUploadFailure
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadFailure>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultConfirmUploadFailure
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadFailure>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        ApiEnum<bool, VaultConfirmUploadFailureSuccess> expectedSuccess =
            VaultConfirmUploadFailureSuccess.False;

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultConfirmUploadFailure
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultConfirmUploadFailure
        {
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            Success = VaultConfirmUploadFailureSuccess.False,
        };

        VaultConfirmUploadFailure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VaultConfirmUploadFailureSuccessTest : TestBase
{
    [Theory]
    [InlineData(VaultConfirmUploadFailureSuccess.False)]
    public void Validation_Works(VaultConfirmUploadFailureSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, VaultConfirmUploadFailureSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, VaultConfirmUploadFailureSuccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VaultConfirmUploadFailureSuccess.False)]
    public void SerializationRoundtrip_Works(VaultConfirmUploadFailureSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, VaultConfirmUploadFailureSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, VaultConfirmUploadFailureSuccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, VaultConfirmUploadFailureSuccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, VaultConfirmUploadFailureSuccess>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
