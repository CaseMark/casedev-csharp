using System;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnvironmentCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = Status.Active,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDomain = "domain";
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedSlug = "slug";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedStatus, model.Status);
    }
}
