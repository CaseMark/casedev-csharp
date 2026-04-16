using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Shares;

namespace Casedev.Tests.Models.Matters.V1.Shares;

public class ShareCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Permission = Permission.Read,
        };

        string expectedID = "id";
        string expectedTargetOrgID = "target_org_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Permission> expectedPermission = Permission.Read;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedTargetOrgID, parameters.TargetOrgID);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedPermission, parameters.Permission);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.Permission);
        Assert.False(parameters.RawBodyData.ContainsKey("permission"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Permission = null,
        };

        Assert.Null(parameters.Permission);
        Assert.False(parameters.RawBodyData.ContainsKey("permission"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            Permission = Permission.Read,
        };

        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            Permission = Permission.Read,

            ExpiresAt = null,
        };

        Assert.Null(parameters.ExpiresAt);
        Assert.True(parameters.RawBodyData.ContainsKey("expires_at"));
    }

    [Fact]
    public void Url_Works()
    {
        ShareCreateParams parameters = new() { ID = "id", TargetOrgID = "target_org_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/id/shares"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ShareCreateParams
        {
            ID = "id",
            TargetOrgID = "target_org_id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Permission = Permission.Read,
        };

        ShareCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PermissionTest : TestBase
{
    [Theory]
    [InlineData(Permission.Read)]
    [InlineData(Permission.Edit)]
    public void Validation_Works(Permission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Permission> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Permission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Permission.Read)]
    [InlineData(Permission.Edit)]
    public void SerializationRoundtrip_Works(Permission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Permission> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Permission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Permission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Permission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
