using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1ListJurisdictionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdictions =
            [
                new()
                {
                    ID = "id",
                    Level = Level.Federal,
                    Name = "name",
                    State = "state",
                },
            ],
            Query = "query",
        };

        long expectedFound = 0;
        string expectedHint = "hint";
        List<Jurisdiction> expectedJurisdictions =
        [
            new()
            {
                ID = "id",
                Level = Level.Federal,
                Name = "name",
                State = "state",
            },
        ];
        string expectedQuery = "query";

        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedHint, model.Hint);
        Assert.NotNull(model.Jurisdictions);
        Assert.Equal(expectedJurisdictions.Count, model.Jurisdictions.Count);
        for (int i = 0; i < expectedJurisdictions.Count; i++)
        {
            Assert.Equal(expectedJurisdictions[i], model.Jurisdictions[i]);
        }
        Assert.Equal(expectedQuery, model.Query);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdictions =
            [
                new()
                {
                    ID = "id",
                    Level = Level.Federal,
                    Name = "name",
                    State = "state",
                },
            ],
            Query = "query",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListJurisdictionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdictions =
            [
                new()
                {
                    ID = "id",
                    Level = Level.Federal,
                    Name = "name",
                    State = "state",
                },
            ],
            Query = "query",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListJurisdictionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedFound = 0;
        string expectedHint = "hint";
        List<Jurisdiction> expectedJurisdictions =
        [
            new()
            {
                ID = "id",
                Level = Level.Federal,
                Name = "name",
                State = "state",
            },
        ];
        string expectedQuery = "query";

        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.NotNull(deserialized.Jurisdictions);
        Assert.Equal(expectedJurisdictions.Count, deserialized.Jurisdictions.Count);
        for (int i = 0; i < expectedJurisdictions.Count; i++)
        {
            Assert.Equal(expectedJurisdictions[i], deserialized.Jurisdictions[i]);
        }
        Assert.Equal(expectedQuery, deserialized.Query);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdictions =
            [
                new()
                {
                    ID = "id",
                    Level = Level.Federal,
                    Name = "name",
                    State = "state",
                },
            ],
            Query = "query",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListJurisdictionsResponse { };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdictions);
        Assert.False(model.RawData.ContainsKey("jurisdictions"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListJurisdictionsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Found = null,
            Hint = null,
            Jurisdictions = null,
            Query = null,
        };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdictions);
        Assert.False(model.RawData.ContainsKey("jurisdictions"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            // Null should be interpreted as omitted for these properties
            Found = null,
            Hint = null,
            Jurisdictions = null,
            Query = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListJurisdictionsResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdictions =
            [
                new()
                {
                    ID = "id",
                    Level = Level.Federal,
                    Name = "name",
                    State = "state",
                },
            ],
            Query = "query",
        };

        V1ListJurisdictionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JurisdictionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
            State = "state",
        };

        string expectedID = "id";
        ApiEnum<string, Level> expectedLevel = Level.Federal;
        string expectedName = "name";
        string expectedState = "state";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedLevel, model.Level);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jurisdiction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jurisdiction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Level> expectedLevel = Level.Federal;
        string expectedName = "name";
        string expectedState = "state";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedLevel, deserialized.Level);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Jurisdiction { State = "state" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Level);
        Assert.False(model.RawData.ContainsKey("level"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Jurisdiction { State = "state" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Jurisdiction
        {
            State = "state",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Level = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Level);
        Assert.False(model.RawData.ContainsKey("level"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Jurisdiction
        {
            State = "state",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Level = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",

            State = null,
        };

        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",

            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Jurisdiction
        {
            ID = "id",
            Level = Level.Federal,
            Name = "name",
            State = "state",
        };

        Jurisdiction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LevelTest : TestBase
{
    [Theory]
    [InlineData(Level.Federal)]
    [InlineData(Level.State)]
    [InlineData(Level.County)]
    [InlineData(Level.Municipal)]
    public void Validation_Works(Level rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Level> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Level>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Level.Federal)]
    [InlineData(Level.State)]
    [InlineData(Level.County)]
    [InlineData(Level.Municipal)]
    public void SerializationRoundtrip_Works(Level rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Level> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Level>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Level>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Level>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
