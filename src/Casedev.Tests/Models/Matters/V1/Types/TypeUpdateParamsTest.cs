using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Types;

namespace Casedev.Tests.Models.Matters.V1.Types;

public class TypeUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultAgentTypeID = "default_agent_type_id",
            DefaultMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DefaultWorkItems =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Description = "description",
            ExitCriteria = ["string"],
            Instructions = "instructions",
            IntakeRequirements = ["string"],
            IsActive = true,
            Name = "name",
            OrchestrationMode = TypeUpdateParamsOrchestrationMode.Auto,
            ReviewAgentTypeID = "review_agent_type_id",
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",
        };

        string expectedID = "id";
        string expectedDefaultAgentTypeID = "default_agent_type_id";
        Dictionary<string, JsonElement> expectedDefaultMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<Dictionary<string, JsonElement>> expectedDefaultWorkItems =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        string expectedDescription = "description";
        List<string> expectedExitCriteria = ["string"];
        string expectedInstructions = "instructions";
        List<string> expectedIntakeRequirements = ["string"];
        bool expectedIsActive = true;
        string expectedName = "name";
        ApiEnum<string, TypeUpdateParamsOrchestrationMode> expectedOrchestrationMode =
            TypeUpdateParamsOrchestrationMode.Auto;
        string expectedReviewAgentTypeID = "review_agent_type_id";
        List<string> expectedReviewCriteria = ["string"];
        List<string> expectedSkillRefs = ["string"];
        string expectedSlug = "slug";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDefaultAgentTypeID, parameters.DefaultAgentTypeID);
        Assert.NotNull(parameters.DefaultMetadata);
        Assert.Equal(expectedDefaultMetadata.Count, parameters.DefaultMetadata.Count);
        foreach (var item in expectedDefaultMetadata)
        {
            Assert.True(parameters.DefaultMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.DefaultMetadata[item.Key]));
        }
        Assert.NotNull(parameters.DefaultWorkItems);
        Assert.Equal(expectedDefaultWorkItems.Count, parameters.DefaultWorkItems.Count);
        for (int i = 0; i < expectedDefaultWorkItems.Count; i++)
        {
            Assert.Equal(expectedDefaultWorkItems[i].Count, parameters.DefaultWorkItems[i].Count);
            foreach (var item in expectedDefaultWorkItems[i])
            {
                Assert.True(parameters.DefaultWorkItems[i].TryGetValue(item.Key, out var value));

                Assert.True(
                    JsonElement.DeepEquals(value, parameters.DefaultWorkItems[i][item.Key])
                );
            }
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.ExitCriteria);
        Assert.Equal(expectedExitCriteria.Count, parameters.ExitCriteria.Count);
        for (int i = 0; i < expectedExitCriteria.Count; i++)
        {
            Assert.Equal(expectedExitCriteria[i], parameters.ExitCriteria[i]);
        }
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.NotNull(parameters.IntakeRequirements);
        Assert.Equal(expectedIntakeRequirements.Count, parameters.IntakeRequirements.Count);
        for (int i = 0; i < expectedIntakeRequirements.Count; i++)
        {
            Assert.Equal(expectedIntakeRequirements[i], parameters.IntakeRequirements[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrchestrationMode, parameters.OrchestrationMode);
        Assert.Equal(expectedReviewAgentTypeID, parameters.ReviewAgentTypeID);
        Assert.NotNull(parameters.ReviewCriteria);
        Assert.Equal(expectedReviewCriteria.Count, parameters.ReviewCriteria.Count);
        for (int i = 0; i < expectedReviewCriteria.Count; i++)
        {
            Assert.Equal(expectedReviewCriteria[i], parameters.ReviewCriteria[i]);
        }
        Assert.NotNull(parameters.SkillRefs);
        Assert.Equal(expectedSkillRefs.Count, parameters.SkillRefs.Count);
        for (int i = 0; i < expectedSkillRefs.Count; i++)
        {
            Assert.Equal(expectedSkillRefs[i], parameters.SkillRefs[i]);
        }
        Assert.Equal(expectedSlug, parameters.Slug);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultAgentTypeID = "default_agent_type_id",
            Description = "description",
            Instructions = "instructions",
            ReviewAgentTypeID = "review_agent_type_id",
        };

        Assert.Null(parameters.DefaultMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("default_metadata"));
        Assert.Null(parameters.DefaultWorkItems);
        Assert.False(parameters.RawBodyData.ContainsKey("default_work_items"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.IntakeRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("intake_requirements"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OrchestrationMode);
        Assert.False(parameters.RawBodyData.ContainsKey("orchestration_mode"));
        Assert.Null(parameters.ReviewCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("review_criteria"));
        Assert.Null(parameters.SkillRefs);
        Assert.False(parameters.RawBodyData.ContainsKey("skill_refs"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultAgentTypeID = "default_agent_type_id",
            Description = "description",
            Instructions = "instructions",
            ReviewAgentTypeID = "review_agent_type_id",

            // Null should be interpreted as omitted for these properties
            DefaultMetadata = null,
            DefaultWorkItems = null,
            ExitCriteria = null,
            IntakeRequirements = null,
            IsActive = null,
            Name = null,
            OrchestrationMode = null,
            ReviewCriteria = null,
            SkillRefs = null,
            Slug = null,
        };

        Assert.Null(parameters.DefaultMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("default_metadata"));
        Assert.Null(parameters.DefaultWorkItems);
        Assert.False(parameters.RawBodyData.ContainsKey("default_work_items"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.IntakeRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("intake_requirements"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OrchestrationMode);
        Assert.False(parameters.RawBodyData.ContainsKey("orchestration_mode"));
        Assert.Null(parameters.ReviewCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("review_criteria"));
        Assert.Null(parameters.SkillRefs);
        Assert.False(parameters.RawBodyData.ContainsKey("skill_refs"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DefaultWorkItems =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            ExitCriteria = ["string"],
            IntakeRequirements = ["string"],
            IsActive = true,
            Name = "name",
            OrchestrationMode = TypeUpdateParamsOrchestrationMode.Auto,
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",
        };

        Assert.Null(parameters.DefaultAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("default_agent_type_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.ReviewAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("review_agent_type_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DefaultWorkItems =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            ExitCriteria = ["string"],
            IntakeRequirements = ["string"],
            IsActive = true,
            Name = "name",
            OrchestrationMode = TypeUpdateParamsOrchestrationMode.Auto,
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",

            DefaultAgentTypeID = null,
            Description = null,
            Instructions = null,
            ReviewAgentTypeID = null,
        };

        Assert.Null(parameters.DefaultAgentTypeID);
        Assert.True(parameters.RawBodyData.ContainsKey("default_agent_type_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Instructions);
        Assert.True(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.ReviewAgentTypeID);
        Assert.True(parameters.RawBodyData.ContainsKey("review_agent_type_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TypeUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/types/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TypeUpdateParams
        {
            ID = "id",
            DefaultAgentTypeID = "default_agent_type_id",
            DefaultMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DefaultWorkItems =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Description = "description",
            ExitCriteria = ["string"],
            Instructions = "instructions",
            IntakeRequirements = ["string"],
            IsActive = true,
            Name = "name",
            OrchestrationMode = TypeUpdateParamsOrchestrationMode.Auto,
            ReviewAgentTypeID = "review_agent_type_id",
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",
        };

        TypeUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeUpdateParamsOrchestrationModeTest : TestBase
{
    [Theory]
    [InlineData(TypeUpdateParamsOrchestrationMode.Auto)]
    [InlineData(TypeUpdateParamsOrchestrationMode.Human)]
    public void Validation_Works(TypeUpdateParamsOrchestrationMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TypeUpdateParamsOrchestrationMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TypeUpdateParamsOrchestrationMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TypeUpdateParamsOrchestrationMode.Auto)]
    [InlineData(TypeUpdateParamsOrchestrationMode.Human)]
    public void SerializationRoundtrip_Works(TypeUpdateParamsOrchestrationMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TypeUpdateParamsOrchestrationMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TypeUpdateParamsOrchestrationMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TypeUpdateParamsOrchestrationMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TypeUpdateParamsOrchestrationMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
