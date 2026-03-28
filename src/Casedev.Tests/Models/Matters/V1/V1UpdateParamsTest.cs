using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1;

namespace Casedev.Tests.Models.Matters.V1;

public class V1UpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Billing = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClientName = "client_name",
            ClientPartyID = "client_party_id",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            DisplayID = "display_id",
            ImportantDates = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Jurisdiction = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MatterType = "matter_type",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PracticeArea = "practice_area",
            ResponsibleAttorneyID = "responsible_attorney_id",
            Status = V1UpdateParamsStatus.Intake,
            Subtype = "subtype",
            Title = "title",
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedBilling = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedClientName = "client_name";
        string expectedClientPartyID = "client_party_id";
        Dictionary<string, JsonElement> expectedCustomFields = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "description";
        string expectedDisplayID = "display_id";
        Dictionary<string, JsonElement> expectedImportantDates = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedJurisdiction = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMatterType = "matter_type";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedPracticeArea = "practice_area";
        string expectedResponsibleAttorneyID = "responsible_attorney_id";
        ApiEnum<string, V1UpdateParamsStatus> expectedStatus = V1UpdateParamsStatus.Intake;
        string expectedSubtype = "subtype";
        string expectedTitle = "title";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedArchivedAt, parameters.ArchivedAt);
        Assert.NotNull(parameters.Billing);
        Assert.Equal(expectedBilling.Count, parameters.Billing.Count);
        foreach (var item in expectedBilling)
        {
            Assert.True(parameters.Billing.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Billing[item.Key]));
        }
        Assert.Equal(expectedClientName, parameters.ClientName);
        Assert.Equal(expectedClientPartyID, parameters.ClientPartyID);
        Assert.NotNull(parameters.CustomFields);
        Assert.Equal(expectedCustomFields.Count, parameters.CustomFields.Count);
        foreach (var item in expectedCustomFields)
        {
            Assert.True(parameters.CustomFields.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.CustomFields[item.Key]));
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayID, parameters.DisplayID);
        Assert.NotNull(parameters.ImportantDates);
        Assert.Equal(expectedImportantDates.Count, parameters.ImportantDates.Count);
        foreach (var item in expectedImportantDates)
        {
            Assert.True(parameters.ImportantDates.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.ImportantDates[item.Key]));
        }
        Assert.NotNull(parameters.Jurisdiction);
        Assert.Equal(expectedJurisdiction.Count, parameters.Jurisdiction.Count);
        foreach (var item in expectedJurisdiction)
        {
            Assert.True(parameters.Jurisdiction.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Jurisdiction[item.Key]));
        }
        Assert.Equal(expectedMatterType, parameters.MatterType);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedPracticeArea, parameters.PracticeArea);
        Assert.Equal(expectedResponsibleAttorneyID, parameters.ResponsibleAttorneyID);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedSubtype, parameters.Subtype);
        Assert.Equal(expectedTitle, parameters.Title);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ClientPartyID = "client_party_id",
        };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.ClientName);
        Assert.False(parameters.RawBodyData.ContainsKey("client_name"));
        Assert.Null(parameters.CustomFields);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayID);
        Assert.False(parameters.RawBodyData.ContainsKey("display_id"));
        Assert.Null(parameters.ImportantDates);
        Assert.False(parameters.RawBodyData.ContainsKey("important_dates"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.MatterType);
        Assert.False(parameters.RawBodyData.ContainsKey("matter_type"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PracticeArea);
        Assert.False(parameters.RawBodyData.ContainsKey("practice_area"));
        Assert.Null(parameters.ResponsibleAttorneyID);
        Assert.False(parameters.RawBodyData.ContainsKey("responsible_attorney_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Subtype);
        Assert.False(parameters.RawBodyData.ContainsKey("subtype"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ClientPartyID = "client_party_id",

            // Null should be interpreted as omitted for these properties
            Billing = null,
            ClientName = null,
            CustomFields = null,
            Description = null,
            DisplayID = null,
            ImportantDates = null,
            Jurisdiction = null,
            MatterType = null,
            Metadata = null,
            PracticeArea = null,
            ResponsibleAttorneyID = null,
            Status = null,
            Subtype = null,
            Title = null,
        };

        Assert.Null(parameters.Billing);
        Assert.False(parameters.RawBodyData.ContainsKey("billing"));
        Assert.Null(parameters.ClientName);
        Assert.False(parameters.RawBodyData.ContainsKey("client_name"));
        Assert.Null(parameters.CustomFields);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayID);
        Assert.False(parameters.RawBodyData.ContainsKey("display_id"));
        Assert.Null(parameters.ImportantDates);
        Assert.False(parameters.RawBodyData.ContainsKey("important_dates"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.MatterType);
        Assert.False(parameters.RawBodyData.ContainsKey("matter_type"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PracticeArea);
        Assert.False(parameters.RawBodyData.ContainsKey("practice_area"));
        Assert.Null(parameters.ResponsibleAttorneyID);
        Assert.False(parameters.RawBodyData.ContainsKey("responsible_attorney_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Subtype);
        Assert.False(parameters.RawBodyData.ContainsKey("subtype"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            Billing = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClientName = "client_name",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            DisplayID = "display_id",
            ImportantDates = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Jurisdiction = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MatterType = "matter_type",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PracticeArea = "practice_area",
            ResponsibleAttorneyID = "responsible_attorney_id",
            Status = V1UpdateParamsStatus.Intake,
            Subtype = "subtype",
            Title = "title",
        };

        Assert.Null(parameters.ArchivedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("archived_at"));
        Assert.Null(parameters.ClientPartyID);
        Assert.False(parameters.RawBodyData.ContainsKey("client_party_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            Billing = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClientName = "client_name",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            DisplayID = "display_id",
            ImportantDates = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Jurisdiction = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MatterType = "matter_type",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PracticeArea = "practice_area",
            ResponsibleAttorneyID = "responsible_attorney_id",
            Status = V1UpdateParamsStatus.Intake,
            Subtype = "subtype",
            Title = "title",

            ArchivedAt = null,
            ClientPartyID = null,
        };

        Assert.Null(parameters.ArchivedAt);
        Assert.True(parameters.RawBodyData.ContainsKey("archived_at"));
        Assert.Null(parameters.ClientPartyID);
        Assert.True(parameters.RawBodyData.ContainsKey("client_party_id"));
    }

    [Fact]
    public void Url_Works()
    {
        V1UpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1UpdateParams
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Billing = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ClientName = "client_name",
            ClientPartyID = "client_party_id",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "description",
            DisplayID = "display_id",
            ImportantDates = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Jurisdiction = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MatterType = "matter_type",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PracticeArea = "practice_area",
            ResponsibleAttorneyID = "responsible_attorney_id",
            Status = V1UpdateParamsStatus.Intake,
            Subtype = "subtype",
            Title = "title",
        };

        V1UpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class V1UpdateParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(V1UpdateParamsStatus.Intake)]
    [InlineData(V1UpdateParamsStatus.Open)]
    [InlineData(V1UpdateParamsStatus.Pending)]
    [InlineData(V1UpdateParamsStatus.Closed)]
    [InlineData(V1UpdateParamsStatus.Archived)]
    public void Validation_Works(V1UpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1UpdateParamsStatus.Intake)]
    [InlineData(V1UpdateParamsStatus.Open)]
    [InlineData(V1UpdateParamsStatus.Pending)]
    [InlineData(V1UpdateParamsStatus.Closed)]
    [InlineData(V1UpdateParamsStatus.Archived)]
    public void SerializationRoundtrip_Works(V1UpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1UpdateParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1UpdateParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
