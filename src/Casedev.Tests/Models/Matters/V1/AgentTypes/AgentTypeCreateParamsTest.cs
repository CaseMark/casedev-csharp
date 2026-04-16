using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Models.Matters.V1.AgentTypes;

namespace Casedev.Tests.Models.Matters.V1.AgentTypes;

public class AgentTypeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentTypeCreateParams
        {
            Instructions = "instructions",
            Name = "name",
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            IsActive = true,
            IsDefault = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Model = "model",
            SkillRefs = ["string"],
            Slug = "slug",
        };

        string expectedInstructions = "instructions";
        string expectedName = "name";
        string expectedDescription = "description";
        List<string> expectedDisabledTools = ["string"];
        List<string> expectedEnabledTools = ["string"];
        bool expectedIsActive = true;
        bool expectedIsDefault = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedModel = "model";
        List<string> expectedSkillRefs = ["string"];
        string expectedSlug = "slug";

        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.DisabledTools);
        Assert.Equal(expectedDisabledTools.Count, parameters.DisabledTools.Count);
        for (int i = 0; i < expectedDisabledTools.Count; i++)
        {
            Assert.Equal(expectedDisabledTools[i], parameters.DisabledTools[i]);
        }
        Assert.NotNull(parameters.EnabledTools);
        Assert.Equal(expectedEnabledTools.Count, parameters.EnabledTools.Count);
        for (int i = 0; i < expectedEnabledTools.Count; i++)
        {
            Assert.Equal(expectedEnabledTools[i], parameters.EnabledTools[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedIsDefault, parameters.IsDefault);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedModel, parameters.Model);
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
        var parameters = new AgentTypeCreateParams { Instructions = "instructions", Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled_tools"));
        Assert.Null(parameters.EnabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled_tools"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.IsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("is_default"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.SkillRefs);
        Assert.False(parameters.RawBodyData.ContainsKey("skill_refs"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentTypeCreateParams
        {
            Instructions = "instructions",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisabledTools = null,
            EnabledTools = null,
            IsActive = null,
            IsDefault = null,
            Metadata = null,
            Model = null,
            SkillRefs = null,
            Slug = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("disabled_tools"));
        Assert.Null(parameters.EnabledTools);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled_tools"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.IsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("is_default"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.SkillRefs);
        Assert.False(parameters.RawBodyData.ContainsKey("skill_refs"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentTypeCreateParams parameters = new() { Instructions = "instructions", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/matters/v1/agent-types"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentTypeCreateParams
        {
            Instructions = "instructions",
            Name = "name",
            Description = "description",
            DisabledTools = ["string"],
            EnabledTools = ["string"],
            IsActive = true,
            IsDefault = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Model = "model",
            SkillRefs = ["string"],
            Slug = "slug",
        };

        AgentTypeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
