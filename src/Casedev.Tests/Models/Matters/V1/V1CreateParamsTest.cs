using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1;

namespace Casedev.Tests.Models.Matters.V1;

public class V1CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateParams
        {
            Title = "title",
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
            Status = Status.Intake,
            Subtype = "subtype",
            Vault = new()
            {
                Description = "description",
                EnableGraph = true,
                EnableIndexing = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            VaultID = "vault_id",
        };

        string expectedTitle = "title";
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
        ApiEnum<string, Status> expectedStatus = Status.Intake;
        string expectedSubtype = "subtype";
        V1CreateParamsVault expectedVault = new()
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedTitle, parameters.Title);
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
        Assert.Equal(expectedVault, parameters.Vault);
        Assert.Equal(expectedVaultID, parameters.VaultID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateParams { Title = "title", ClientPartyID = "client_party_id" };

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
        Assert.Null(parameters.Vault);
        Assert.False(parameters.RawBodyData.ContainsKey("vault"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Title = "title",
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
            Vault = null,
            VaultID = null,
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
        Assert.Null(parameters.Vault);
        Assert.False(parameters.RawBodyData.ContainsKey("vault"));
        Assert.Null(parameters.VaultID);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1CreateParams
        {
            Title = "title",
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
            Status = Status.Intake,
            Subtype = "subtype",
            Vault = new()
            {
                Description = "description",
                EnableGraph = true,
                EnableIndexing = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            VaultID = "vault_id",
        };

        Assert.Null(parameters.ClientPartyID);
        Assert.False(parameters.RawBodyData.ContainsKey("client_party_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new V1CreateParams
        {
            Title = "title",
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
            Status = Status.Intake,
            Subtype = "subtype",
            Vault = new()
            {
                Description = "description",
                EnableGraph = true,
                EnableIndexing = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            VaultID = "vault_id",

            ClientPartyID = null,
        };

        Assert.Null(parameters.ClientPartyID);
        Assert.True(parameters.RawBodyData.ContainsKey("client_party_id"));
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateParams parameters = new() { Title = "title" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateParams
        {
            Title = "title",
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
            Status = Status.Intake,
            Subtype = "subtype",
            Vault = new()
            {
                Description = "description",
                EnableGraph = true,
                EnableIndexing = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            VaultID = "vault_id",
        };

        V1CreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Intake)]
    [InlineData(Status.Open)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Archived)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Intake)]
    [InlineData(Status.Open)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Archived)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class V1CreateParamsVaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateParamsVault
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        bool expectedEnableIndexing = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnableGraph, model.EnableGraph);
        Assert.Equal(expectedEnableIndexing, model.EnableIndexing);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateParamsVault
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateParamsVault>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateParamsVault
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateParamsVault>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        bool expectedEnableIndexing = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnableGraph, deserialized.EnableGraph);
        Assert.Equal(expectedEnableIndexing, deserialized.EnableIndexing);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateParamsVault
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1CreateParamsVault { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1CreateParamsVault { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1CreateParamsVault
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            EnableGraph = null,
            EnableIndexing = null,
            Metadata = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1CreateParamsVault
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            EnableGraph = null,
            EnableIndexing = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1CreateParamsVault
        {
            Description = "description",
            EnableGraph = true,
            EnableIndexing = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        V1CreateParamsVault copied = new(model);

        Assert.Equal(model, copied);
    }
}
