using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Format.V1;

namespace CaseDev.Tests.Models.Format.V1;

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options
        {
            Components =
            [
                new()
                {
                    Content = "content",
                    Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                    TemplateID = "templateId",
                    Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        List<Component> expectedComponents =
        [
            new()
            {
                Content = "content",
                Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
                TemplateID = "templateId",
                Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        ];

        Assert.Equal(expectedComponents.Count, model.Components.Count);
        for (int i = 0; i < expectedComponents.Count; i++)
        {
            Assert.Equal(expectedComponents[i], model.Components[i]);
        }
    }
}

public class ComponentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Component
        {
            Content = "content",
            Styles = JsonSerializer.Deserialize<JsonElement>("{}"),
            TemplateID = "templateId",
            Variables = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedContent = "content";
        JsonElement expectedStyles = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTemplateID = "templateId";
        JsonElement expectedVariables = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(
            model.Styles.HasValue && JsonElement.DeepEquals(expectedStyles, model.Styles.Value)
        );
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.True(
            model.Variables.HasValue
                && JsonElement.DeepEquals(expectedVariables, model.Variables.Value)
        );
    }
}
