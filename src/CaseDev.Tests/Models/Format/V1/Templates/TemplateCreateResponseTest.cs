using System;
using System.Collections.Generic;
using CaseDev.Models.Format.V1.Templates;

namespace CaseDev.Tests.Models.Format.V1.Templates;

public class TemplateCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            Type = "type",
            Variables = ["string"],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedType = "type";
        List<string> expectedVariables = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
    }
}
