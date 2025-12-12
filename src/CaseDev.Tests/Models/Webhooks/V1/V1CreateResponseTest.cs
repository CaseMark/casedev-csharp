using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Webhooks.V1;

namespace CaseDev.Tests.Models.Webhooks.V1;

public class V1CreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<string> expectedEvents = ["string"];
        bool expectedIsActive = true;
        string expectedSecret = "secret";
        string expectedURL = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Events);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<string> expectedEvents = ["string"];
        bool expectedIsActive = true;
        string expectedSecret = "secret";
        string expectedURL = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Events);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateResponse { Description = "description" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateResponse { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1CreateResponse
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Events = null,
            IsActive = null,
            Secret = null,
            URL = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Events);
        Assert.False(model.RawData.ContainsKey("events"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateResponse
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Events = null,
            IsActive = null,
            Secret = null,
            URL = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",

            Description = null,
        };

        model.Validate();
    }
}
