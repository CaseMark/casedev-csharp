using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillDeleteResponse { Deleted = true, Slug = "slug" };

        bool expectedDeleted = true;
        string expectedSlug = "slug";

        Assert.Equal(expectedDeleted, model.Deleted);
        Assert.Equal(expectedSlug, model.Slug);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillDeleteResponse { Deleted = true, Slug = "slug" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillDeleteResponse { Deleted = true, Slug = "slug" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeleted = true;
        string expectedSlug = "slug";

        Assert.Equal(expectedDeleted, deserialized.Deleted);
        Assert.Equal(expectedSlug, deserialized.Slug);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillDeleteResponse { Deleted = true, Slug = "slug" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SkillDeleteResponse { };

        Assert.Null(model.Deleted);
        Assert.False(model.RawData.ContainsKey("deleted"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SkillDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SkillDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Deleted = null,
            Slug = null,
        };

        Assert.Null(model.Deleted);
        Assert.False(model.RawData.ContainsKey("deleted"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SkillDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Deleted = null,
            Slug = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillDeleteResponse { Deleted = true, Slug = "slug" };

        SkillDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
