using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Types;

namespace Casedev.Tests.Models.Matters.V1.Types;

public class TypeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TypeCreateParams
        {
            Name = "name",
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
            OrchestrationMode = OrchestrationMode.Auto,
            ReviewAgentTypeID = "review_agent_type_id",
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",
        };

        string expectedName = "name";
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
        ApiEnum<string, OrchestrationMode> expectedOrchestrationMode = OrchestrationMode.Auto;
        string expectedReviewAgentTypeID = "review_agent_type_id";
        List<string> expectedReviewCriteria = ["string"];
        List<string> expectedSkillRefs = ["string"];
        string expectedSlug = "slug";

        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new TypeCreateParams { Name = "name" };

        Assert.Null(parameters.DefaultAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("default_agent_type_id"));
        Assert.Null(parameters.DefaultMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("default_metadata"));
        Assert.Null(parameters.DefaultWorkItems);
        Assert.False(parameters.RawBodyData.ContainsKey("default_work_items"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.IntakeRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("intake_requirements"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.OrchestrationMode);
        Assert.False(parameters.RawBodyData.ContainsKey("orchestration_mode"));
        Assert.Null(parameters.ReviewAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("review_agent_type_id"));
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
        var parameters = new TypeCreateParams
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            DefaultAgentTypeID = null,
            DefaultMetadata = null,
            DefaultWorkItems = null,
            Description = null,
            ExitCriteria = null,
            Instructions = null,
            IntakeRequirements = null,
            IsActive = null,
            OrchestrationMode = null,
            ReviewAgentTypeID = null,
            ReviewCriteria = null,
            SkillRefs = null,
            Slug = null,
        };

        Assert.Null(parameters.DefaultAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("default_agent_type_id"));
        Assert.Null(parameters.DefaultMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("default_metadata"));
        Assert.Null(parameters.DefaultWorkItems);
        Assert.False(parameters.RawBodyData.ContainsKey("default_work_items"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExitCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("exit_criteria"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.IntakeRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("intake_requirements"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.OrchestrationMode);
        Assert.False(parameters.RawBodyData.ContainsKey("orchestration_mode"));
        Assert.Null(parameters.ReviewAgentTypeID);
        Assert.False(parameters.RawBodyData.ContainsKey("review_agent_type_id"));
        Assert.Null(parameters.ReviewCriteria);
        Assert.False(parameters.RawBodyData.ContainsKey("review_criteria"));
        Assert.Null(parameters.SkillRefs);
        Assert.False(parameters.RawBodyData.ContainsKey("skill_refs"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
    }

    [Fact]
    public void Url_Works()
    {
        TypeCreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/types"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TypeCreateParams
        {
            Name = "name",
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
            OrchestrationMode = OrchestrationMode.Auto,
            ReviewAgentTypeID = "review_agent_type_id",
            ReviewCriteria = ["string"],
            SkillRefs = ["string"],
            Slug = "slug",
        };

        TypeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OrchestrationModeTest : TestBase
{
    [Theory]
    [InlineData(OrchestrationMode.Auto)]
    [InlineData(OrchestrationMode.Human)]
    public void Validation_Works(OrchestrationMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrchestrationMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrchestrationMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrchestrationMode.Auto)]
    [InlineData(OrchestrationMode.Human)]
    public void SerializationRoundtrip_Works(OrchestrationMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrchestrationMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrchestrationMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrchestrationMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrchestrationMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
