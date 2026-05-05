using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectGetPagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponse
        {
            Metadata = new()
            {
                Filename = "filename",
                ObjectID = "object_id",
                PageCount = 0,
                ReturnedPages = 0,
                Source = Source.Ocr,
                VaultID = "vault_id",
                End = 0,
                Start = 0,
            },
            Pages = [new() { Page = 0, Text = "text" }],
        };

        ObjectGetPagesResponseMetadata expectedMetadata = new()
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };
        List<ObjectGetPagesResponsePage> expectedPages = [new() { Page = 0, Text = "text" }];

        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponse
        {
            Metadata = new()
            {
                Filename = "filename",
                ObjectID = "object_id",
                PageCount = 0,
                ReturnedPages = 0,
                Source = Source.Ocr,
                VaultID = "vault_id",
                End = 0,
                Start = 0,
            },
            Pages = [new() { Page = 0, Text = "text" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetPagesResponse
        {
            Metadata = new()
            {
                Filename = "filename",
                ObjectID = "object_id",
                PageCount = 0,
                ReturnedPages = 0,
                Source = Source.Ocr,
                VaultID = "vault_id",
                End = 0,
                Start = 0,
            },
            Pages = [new() { Page = 0, Text = "text" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ObjectGetPagesResponseMetadata expectedMetadata = new()
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };
        List<ObjectGetPagesResponsePage> expectedPages = [new() { Page = 0, Text = "text" }];

        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetPagesResponse
        {
            Metadata = new()
            {
                Filename = "filename",
                ObjectID = "object_id",
                PageCount = 0,
                ReturnedPages = 0,
                Source = Source.Ocr,
                VaultID = "vault_id",
                End = 0,
                Start = 0,
            },
            Pages = [new() { Page = 0, Text = "text" }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetPagesResponse
        {
            Metadata = new()
            {
                Filename = "filename",
                ObjectID = "object_id",
                PageCount = 0,
                ReturnedPages = 0,
                Source = Source.Ocr,
                VaultID = "vault_id",
                End = 0,
                Start = 0,
            },
            Pages = [new() { Page = 0, Text = "text" }],
        };

        ObjectGetPagesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectGetPagesResponseMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };

        string expectedFilename = "filename";
        string expectedObjectID = "object_id";
        long expectedPageCount = 0;
        long expectedReturnedPages = 0;
        ApiEnum<string, Source> expectedSource = Source.Ocr;
        string expectedVaultID = "vault_id";
        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedReturnedPages, model.ReturnedPages);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponseMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFilename = "filename";
        string expectedObjectID = "object_id";
        long expectedPageCount = 0;
        long expectedReturnedPages = 0;
        ApiEnum<string, Source> expectedSource = Source.Ocr;
        string expectedVaultID = "vault_id";
        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedReturnedPages, deserialized.ReturnedPages);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
        };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",

            End = null,
            Start = null,
        };

        Assert.Null(model.End);
        Assert.True(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.True(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",

            End = null,
            Start = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetPagesResponseMetadata
        {
            Filename = "filename",
            ObjectID = "object_id",
            PageCount = 0,
            ReturnedPages = 0,
            Source = Source.Ocr,
            VaultID = "vault_id",
            End = 0,
            Start = 0,
        };

        ObjectGetPagesResponseMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Ocr)]
    [InlineData(Source.Txt)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Ocr)]
    [InlineData(Source.Txt)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ObjectGetPagesResponsePageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponsePage { Page = 0, Text = "text" };

        long expectedPage = 0;
        string expectedText = "text";

        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetPagesResponsePage { Page = 0, Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponsePage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetPagesResponsePage { Page = 0, Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetPagesResponsePage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPage = 0;
        string expectedText = "text";

        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetPagesResponsePage { Page = 0, Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetPagesResponsePage { Page = 0, Text = "text" };

        ObjectGetPagesResponsePage copied = new(model);

        Assert.Equal(model, copied);
    }
}
