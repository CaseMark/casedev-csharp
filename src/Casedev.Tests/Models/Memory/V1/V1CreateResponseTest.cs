using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Memory.V1;

namespace Casedev.Tests.Models.Memory.V1;

public class V1CreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    Event = Event.Add,
                    Memory = "memory",
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                ID = "id",
                Event = Event.Add,
                Memory = "memory",
            },
        ];

        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    Event = Event.Add,
                    Memory = "memory",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    Event = Event.Add,
                    Memory = "memory",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                ID = "id",
                Event = Event.Add,
                Memory = "memory",
            },
        ];

        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    Event = Event.Add,
                    Memory = "memory",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateResponse { };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1CreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1CreateResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    Event = Event.Add,
                    Memory = "memory",
                },
            ],
        };

        V1CreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            ID = "id",
            Event = Event.Add,
            Memory = "memory",
        };

        string expectedID = "id";
        ApiEnum<string, Event> expectedEvent = Event.Add;
        string expectedMemory = "memory";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedMemory, model.Memory);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            ID = "id",
            Event = Event.Add,
            Memory = "memory",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            ID = "id",
            Event = Event.Add,
            Memory = "memory",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Event> expectedEvent = Event.Add;
        string expectedMemory = "memory";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedMemory, deserialized.Memory);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            ID = "id",
            Event = Event.Add,
            Memory = "memory",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Memory);
        Assert.False(model.RawData.ContainsKey("memory"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Event = null,
            Memory = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Memory);
        Assert.False(model.RawData.ContainsKey("memory"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Event = null,
            Memory = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            ID = "id",
            Event = Event.Add,
            Memory = "memory",
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTest : TestBase
{
    [Theory]
    [InlineData(Event.Add)]
    [InlineData(Event.Update)]
    [InlineData(Event.Delete)]
    [InlineData(Event.None)]
    public void Validation_Works(Event rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Event> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Event>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Event.Add)]
    [InlineData(Event.Update)]
    [InlineData(Event.Delete)]
    [InlineData(Event.None)]
    public void SerializationRoundtrip_Works(Event rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Event> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Event>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Event>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Event>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
