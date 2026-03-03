using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1ListCourtsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        List<Court> expectedCourts =
        [
            new()
            {
                ID = "id",
                FullName = "fullName",
                Jurisdiction = "jurisdiction",
                PacerCourtID = 0,
                ShortName = "shortName",
            },
        ];
        long expectedFound = 0;
        bool expectedInUseOnly = true;
        string expectedJurisdiction = "jurisdiction";
        string expectedQuery = "query";

        Assert.NotNull(model.Courts);
        Assert.Equal(expectedCourts.Count, model.Courts.Count);
        for (int i = 0; i < expectedCourts.Count; i++)
        {
            Assert.Equal(expectedCourts[i], model.Courts[i]);
        }
        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedInUseOnly, model.InUseOnly);
        Assert.Equal(expectedJurisdiction, model.Jurisdiction);
        Assert.Equal(expectedQuery, model.Query);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListCourtsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListCourtsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Court> expectedCourts =
        [
            new()
            {
                ID = "id",
                FullName = "fullName",
                Jurisdiction = "jurisdiction",
                PacerCourtID = 0,
                ShortName = "shortName",
            },
        ];
        long expectedFound = 0;
        bool expectedInUseOnly = true;
        string expectedJurisdiction = "jurisdiction";
        string expectedQuery = "query";

        Assert.NotNull(deserialized.Courts);
        Assert.Equal(expectedCourts.Count, deserialized.Courts.Count);
        for (int i = 0; i < expectedCourts.Count; i++)
        {
            Assert.Equal(expectedCourts[i], deserialized.Courts[i]);
        }
        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedInUseOnly, deserialized.InUseOnly);
        Assert.Equal(expectedJurisdiction, deserialized.Jurisdiction);
        Assert.Equal(expectedQuery, deserialized.Query);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListCourtsResponse { Jurisdiction = "jurisdiction", Query = "query" };

        Assert.Null(model.Courts);
        Assert.False(model.RawData.ContainsKey("courts"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.InUseOnly);
        Assert.False(model.RawData.ContainsKey("inUseOnly"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListCourtsResponse { Jurisdiction = "jurisdiction", Query = "query" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Jurisdiction = "jurisdiction",
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Courts = null,
            Found = null,
            InUseOnly = null,
        };

        Assert.Null(model.Courts);
        Assert.False(model.RawData.ContainsKey("courts"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.InUseOnly);
        Assert.False(model.RawData.ContainsKey("inUseOnly"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Jurisdiction = "jurisdiction",
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Courts = null,
            Found = null,
            InUseOnly = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
        };

        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,

            Jurisdiction = null,
            Query = null,
        };

        Assert.Null(model.Jurisdiction);
        Assert.True(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.Query);
        Assert.True(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,

            Jurisdiction = null,
            Query = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListCourtsResponse
        {
            Courts =
            [
                new()
                {
                    ID = "id",
                    FullName = "fullName",
                    Jurisdiction = "jurisdiction",
                    PacerCourtID = 0,
                    ShortName = "shortName",
                },
            ],
            Found = 0,
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Query = "query",
        };

        V1ListCourtsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CourtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Court
        {
            ID = "id",
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        string expectedID = "id";
        string expectedFullName = "fullName";
        string expectedJurisdiction = "jurisdiction";
        long expectedPacerCourtID = 0;
        string expectedShortName = "shortName";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFullName, model.FullName);
        Assert.Equal(expectedJurisdiction, model.Jurisdiction);
        Assert.Equal(expectedPacerCourtID, model.PacerCourtID);
        Assert.Equal(expectedShortName, model.ShortName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Court
        {
            ID = "id",
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Court>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Court
        {
            ID = "id",
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Court>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedFullName = "fullName";
        string expectedJurisdiction = "jurisdiction";
        long expectedPacerCourtID = 0;
        string expectedShortName = "shortName";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFullName, deserialized.FullName);
        Assert.Equal(expectedJurisdiction, deserialized.Jurisdiction);
        Assert.Equal(expectedPacerCourtID, deserialized.PacerCourtID);
        Assert.Equal(expectedShortName, deserialized.ShortName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Court
        {
            ID = "id",
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Court
        {
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Court
        {
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Court
        {
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Court
        {
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Court { ID = "id" };

        Assert.Null(model.FullName);
        Assert.False(model.RawData.ContainsKey("fullName"));
        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.PacerCourtID);
        Assert.False(model.RawData.ContainsKey("pacerCourtId"));
        Assert.Null(model.ShortName);
        Assert.False(model.RawData.ContainsKey("shortName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Court { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Court
        {
            ID = "id",

            FullName = null,
            Jurisdiction = null,
            PacerCourtID = null,
            ShortName = null,
        };

        Assert.Null(model.FullName);
        Assert.True(model.RawData.ContainsKey("fullName"));
        Assert.Null(model.Jurisdiction);
        Assert.True(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.PacerCourtID);
        Assert.True(model.RawData.ContainsKey("pacerCourtId"));
        Assert.Null(model.ShortName);
        Assert.True(model.RawData.ContainsKey("shortName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Court
        {
            ID = "id",

            FullName = null,
            Jurisdiction = null,
            PacerCourtID = null,
            ShortName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Court
        {
            ID = "id",
            FullName = "fullName",
            Jurisdiction = "jurisdiction",
            PacerCourtID = 0,
            ShortName = "shortName",
        };

        Court copied = new(model);

        Assert.Equal(model, copied);
    }
}
