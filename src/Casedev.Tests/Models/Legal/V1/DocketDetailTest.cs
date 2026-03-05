using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class DocketDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAssignedTo, model.AssignedTo);
        Assert.Equal(expectedCaseName, model.CaseName);
        Assert.Equal(expectedCause, model.Cause);
        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedCourtID, model.CourtID);
        Assert.Equal(expectedDateFiled, model.DateFiled);
        Assert.Equal(expectedDateTerminated, model.DateTerminated);
        Assert.Equal(expectedDocketNumber, model.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, model.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, model.PacerCaseID);
        Assert.NotNull(model.Parties);
        Assert.Equal(expectedParties.Count, model.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], model.Parties[i]);
        }
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocketDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocketDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAssignedTo, deserialized.AssignedTo);
        Assert.Equal(expectedCaseName, deserialized.CaseName);
        Assert.Equal(expectedCause, deserialized.Cause);
        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedCourtID, deserialized.CourtID);
        Assert.Equal(expectedDateFiled, deserialized.DateFiled);
        Assert.Equal(expectedDateTerminated, deserialized.DateTerminated);
        Assert.Equal(expectedDocketNumber, deserialized.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, deserialized.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, deserialized.PacerCaseID);
        Assert.NotNull(deserialized.Parties);
        Assert.Equal(expectedParties.Count, deserialized.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], deserialized.Parties[i]);
        }
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocketDetail
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocketDetail
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DocketDetail
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocketDetail
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        Assert.Null(model.AssignedTo);
        Assert.False(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.False(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.False(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.False(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.False(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.False(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.False(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.False(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.False(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        Assert.Null(model.AssignedTo);
        Assert.True(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.True(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.True(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.True(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.True(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.True(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.True(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.True(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.True(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.True(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocketDetail
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        DocketDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}
