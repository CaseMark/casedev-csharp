using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Multipart;

namespace Router.Tests.Models.Vault.Multipart;

public class MultipartGetPartUrlsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            Urls = [new() { PartNumber = 0, UrlValue = "url" }],
        };

        List<Url> expectedUrls = [new() { PartNumber = 0, UrlValue = "url" }];

        Assert.NotNull(model.Urls);
        Assert.Equal(expectedUrls.Count, model.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], model.Urls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            Urls = [new() { PartNumber = 0, UrlValue = "url" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartGetPartUrlsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            Urls = [new() { PartNumber = 0, UrlValue = "url" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartGetPartUrlsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Url> expectedUrls = [new() { PartNumber = 0, UrlValue = "url" }];

        Assert.NotNull(deserialized.Urls);
        Assert.Equal(expectedUrls.Count, deserialized.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], deserialized.Urls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            Urls = [new() { PartNumber = 0, UrlValue = "url" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MultipartGetPartUrlsResponse { };

        Assert.Null(model.Urls);
        Assert.False(model.RawData.ContainsKey("urls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MultipartGetPartUrlsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            // Null should be interpreted as omitted for these properties
            Urls = null,
        };

        Assert.Null(model.Urls);
        Assert.False(model.RawData.ContainsKey("urls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            // Null should be interpreted as omitted for these properties
            Urls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipartGetPartUrlsResponse
        {
            Urls = [new() { PartNumber = 0, UrlValue = "url" }],
        };

        MultipartGetPartUrlsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Url { PartNumber = 0, UrlValue = "url" };

        long expectedPartNumber = 0;
        string expectedUrlValue = "url";

        Assert.Equal(expectedPartNumber, model.PartNumber);
        Assert.Equal(expectedUrlValue, model.UrlValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Url { PartNumber = 0, UrlValue = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Url>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Url { PartNumber = 0, UrlValue = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Url>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedPartNumber = 0;
        string expectedUrlValue = "url";

        Assert.Equal(expectedPartNumber, deserialized.PartNumber);
        Assert.Equal(expectedUrlValue, deserialized.UrlValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Url { PartNumber = 0, UrlValue = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Url { };

        Assert.Null(model.PartNumber);
        Assert.False(model.RawData.ContainsKey("partNumber"));
        Assert.Null(model.UrlValue);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Url { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Url
        {
            // Null should be interpreted as omitted for these properties
            PartNumber = null,
            UrlValue = null,
        };

        Assert.Null(model.PartNumber);
        Assert.False(model.RawData.ContainsKey("partNumber"));
        Assert.Null(model.UrlValue);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Url
        {
            // Null should be interpreted as omitted for these properties
            PartNumber = null,
            UrlValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Url { PartNumber = 0, UrlValue = "url" };

        Url copied = new(model);

        Assert.Equal(model, copied);
    }
}
