using System;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectGetChunksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectGetChunksParams
        {
            ID = "id",
            ObjectID = "objectId",
            End = 0,
            Start = 0,
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        long expectedEnd = 0;
        long expectedStart = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectGetChunksParams { ID = "id", ObjectID = "objectId" };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectGetChunksParams
        {
            ID = "id",
            ObjectID = "objectId",

            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectGetChunksParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            End = 0,
            Start = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/vault/id/objects/objectId/chunks?end=0&start=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectGetChunksParams
        {
            ID = "id",
            ObjectID = "objectId",
            End = 0,
            Start = 0,
        };

        ObjectGetChunksParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
