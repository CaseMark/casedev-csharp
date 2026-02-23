using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Privilege.V1;

namespace Router.Tests.Models.Privilege.V1;

public class V1DetectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DetectParams
        {
            Categories = [Category.AttorneyClient],
            Content = "content",
            DocumentID = "document_id",
            IncludeRationale = true,
            Jurisdiction = Jurisdiction.UsFederal,
            Model = "model",
            VaultID = "vault_id",
        };

        List<ApiEnum<string, Category>> expectedCategories = [Category.AttorneyClient];
        string expectedContent = "content";
        string expectedDocumentID = "document_id";
        bool expectedIncludeRationale = true;
        ApiEnum<string, Jurisdiction> expectedJurisdiction = Jurisdiction.UsFederal;
        string expectedModel = "model";
        string expectedVaultID = "vault_id";

        Assert.NotNull(parameters.Categories);
        Assert.Equal(expectedCategories.Count, parameters.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], parameters.Categories[i]);
        }
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedDocumentID, parameters.DocumentID);
        Assert.Equal(expectedIncludeRationale, parameters.IncludeRationale);
        Assert.Equal(expectedJurisdiction, parameters.Jurisdiction);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedVaultID, parameters.VaultID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1DetectParams { };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.DocumentID);
        Assert.False(parameters.RawBodyData.ContainsKey("document_id"));
        Assert.Null(parameters.IncludeRationale);
        Assert.False(parameters.RawBodyData.ContainsKey("include_rationale"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1DetectParams
        {
            // Null should be interpreted as omitted for these properties
            Categories = null,
            Content = null,
            DocumentID = null,
            IncludeRationale = null,
            Jurisdiction = null,
            Model = null,
            VaultID = null,
        };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.DocumentID);
        Assert.False(parameters.RawBodyData.ContainsKey("document_id"));
        Assert.Null(parameters.IncludeRationale);
        Assert.False(parameters.RawBodyData.ContainsKey("include_rationale"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void Url_Works()
    {
        V1DetectParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/privilege/v1/detect"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1DetectParams
        {
            Categories = [Category.AttorneyClient],
            Content = "content",
            DocumentID = "document_id",
            IncludeRationale = true,
            Jurisdiction = Jurisdiction.UsFederal,
            Model = "model",
            VaultID = "vault_id",
        };

        V1DetectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.AttorneyClient)]
    [InlineData(Category.WorkProduct)]
    [InlineData(Category.CommonInterest)]
    [InlineData(Category.LitigationHold)]
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
    [InlineData(Category.AttorneyClient)]
    [InlineData(Category.WorkProduct)]
    [InlineData(Category.CommonInterest)]
    [InlineData(Category.LitigationHold)]
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

public class JurisdictionTest : TestBase
{
    [Theory]
    [InlineData(Jurisdiction.UsFederal)]
    public void Validation_Works(Jurisdiction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Jurisdiction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Jurisdiction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Jurisdiction.UsFederal)]
    public void SerializationRoundtrip_Works(Jurisdiction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Jurisdiction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Jurisdiction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Jurisdiction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Jurisdiction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
