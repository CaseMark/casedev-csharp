using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Voice.BoostList;

namespace Casedev.Tests.Models.Voice.BoostList;

public class BoostListExtractParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BoostListExtractParams
        {
            Categories = [Category.Person],
            ObjectIds = ["string"],
            Text = "text",
            VaultID = "vault_id",
        };

        List<ApiEnum<string, Category>> expectedCategories = [Category.Person];
        List<string> expectedObjectIds = ["string"];
        string expectedText = "text";
        string expectedVaultID = "vault_id";

        Assert.NotNull(parameters.Categories);
        Assert.Equal(expectedCategories.Count, parameters.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], parameters.Categories[i]);
        }
        Assert.NotNull(parameters.ObjectIds);
        Assert.Equal(expectedObjectIds.Count, parameters.ObjectIds.Count);
        for (int i = 0; i < expectedObjectIds.Count; i++)
        {
            Assert.Equal(expectedObjectIds[i], parameters.ObjectIds[i]);
        }
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedVaultID, parameters.VaultID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BoostListExtractParams { };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("object_ids"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BoostListExtractParams
        {
            // Null should be interpreted as omitted for these properties
            Categories = null,
            ObjectIds = null,
            Text = null,
            VaultID = null,
        };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("object_ids"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BoostListExtractParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/voice/boost-list/extract"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BoostListExtractParams
        {
            Categories = [Category.Person],
            ObjectIds = ["string"],
            Text = "text",
            VaultID = "vault_id",
        };

        BoostListExtractParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Person)]
    [InlineData(Category.Organization)]
    [InlineData(Category.LegalTerm)]
    [InlineData(Category.Medical)]
    [InlineData(Category.Citation)]
    [InlineData(Category.Email)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Person)]
    [InlineData(Category.Organization)]
    [InlineData(Category.LegalTerm)]
    [InlineData(Category.Medical)]
    [InlineData(Category.Citation)]
    [InlineData(Category.Email)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
