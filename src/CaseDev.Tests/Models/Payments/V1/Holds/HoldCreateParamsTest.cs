using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using Holds = CaseDev.Models.Payments.V1.Holds;

namespace CaseDev.Tests.Models.Payments.V1.Holds;

public class HoldCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Holds::HoldCreateParams
        {
            AccountID = "account_id",
            Amount = 0,
            Currency = "currency",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OnReleaseAction = "on_release_action",
            OnReleaseConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            ReleaseConditions =
            [
                new()
                {
                    Approvers = ["string"],
                    Date = "date",
                    DocumentID = "document_id",
                    Type = Holds::Type.ManualApproval,
                },
            ],
        };

        string expectedAccountID = "account_id";
        long expectedAmount = 0;
        string expectedCurrency = "currency";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemo = "memo";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedOnReleaseAction = "on_release_action";
        JsonElement expectedOnReleaseConfig = JsonSerializer.Deserialize<JsonElement>("{}");
        List<Holds::ReleaseCondition> expectedReleaseConditions =
        [
            new()
            {
                Approvers = ["string"],
                Date = "date",
                DocumentID = "document_id",
                Type = Holds::Type.ManualApproval,
            },
        ];

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedMemo, parameters.Memo);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedOnReleaseAction, parameters.OnReleaseAction);
        Assert.NotNull(parameters.OnReleaseConfig);
        Assert.True(
            JsonElement.DeepEquals(expectedOnReleaseConfig, parameters.OnReleaseConfig.Value)
        );
        Assert.NotNull(parameters.ReleaseConditions);
        Assert.Equal(expectedReleaseConditions.Count, parameters.ReleaseConditions.Count);
        for (int i = 0; i < expectedReleaseConditions.Count; i++)
        {
            Assert.Equal(expectedReleaseConditions[i], parameters.ReleaseConditions[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Holds::HoldCreateParams { AccountID = "account_id", Amount = 0 };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OnReleaseAction);
        Assert.False(parameters.RawBodyData.ContainsKey("on_release_action"));
        Assert.Null(parameters.OnReleaseConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("on_release_config"));
        Assert.Null(parameters.ReleaseConditions);
        Assert.False(parameters.RawBodyData.ContainsKey("release_conditions"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Holds::HoldCreateParams
        {
            AccountID = "account_id",
            Amount = 0,

            // Null should be interpreted as omitted for these properties
            Currency = null,
            ExpiresAt = null,
            Memo = null,
            Metadata = null,
            OnReleaseAction = null,
            OnReleaseConfig = null,
            ReleaseConditions = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.ExpiresAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_at"));
        Assert.Null(parameters.Memo);
        Assert.False(parameters.RawBodyData.ContainsKey("memo"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OnReleaseAction);
        Assert.False(parameters.RawBodyData.ContainsKey("on_release_action"));
        Assert.Null(parameters.OnReleaseConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("on_release_config"));
        Assert.Null(parameters.ReleaseConditions);
        Assert.False(parameters.RawBodyData.ContainsKey("release_conditions"));
    }

    [Fact]
    public void Url_Works()
    {
        Holds::HoldCreateParams parameters = new() { AccountID = "account_id", Amount = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/holds"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Holds::HoldCreateParams
        {
            AccountID = "account_id",
            Amount = 0,
            Currency = "currency",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Memo = "memo",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            OnReleaseAction = "on_release_action",
            OnReleaseConfig = JsonSerializer.Deserialize<JsonElement>("{}"),
            ReleaseConditions =
            [
                new()
                {
                    Approvers = ["string"],
                    Date = "date",
                    DocumentID = "document_id",
                    Type = Holds::Type.ManualApproval,
                },
            ],
        };

        Holds::HoldCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReleaseConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            Approvers = ["string"],
            Date = "date",
            DocumentID = "document_id",
            Type = Holds::Type.ManualApproval,
        };

        List<string> expectedApprovers = ["string"];
        string expectedDate = "date";
        string expectedDocumentID = "document_id";
        ApiEnum<string, Holds::Type> expectedType = Holds::Type.ManualApproval;

        Assert.NotNull(model.Approvers);
        Assert.Equal(expectedApprovers.Count, model.Approvers.Count);
        for (int i = 0; i < expectedApprovers.Count; i++)
        {
            Assert.Equal(expectedApprovers[i], model.Approvers[i]);
        }
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedDocumentID, model.DocumentID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            Approvers = ["string"],
            Date = "date",
            DocumentID = "document_id",
            Type = Holds::Type.ManualApproval,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Holds::ReleaseCondition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            Approvers = ["string"],
            Date = "date",
            DocumentID = "document_id",
            Type = Holds::Type.ManualApproval,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Holds::ReleaseCondition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedApprovers = ["string"];
        string expectedDate = "date";
        string expectedDocumentID = "document_id";
        ApiEnum<string, Holds::Type> expectedType = Holds::Type.ManualApproval;

        Assert.NotNull(deserialized.Approvers);
        Assert.Equal(expectedApprovers.Count, deserialized.Approvers.Count);
        for (int i = 0; i < expectedApprovers.Count; i++)
        {
            Assert.Equal(expectedApprovers[i], deserialized.Approvers[i]);
        }
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedDocumentID, deserialized.DocumentID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            Approvers = ["string"],
            Date = "date",
            DocumentID = "document_id",
            Type = Holds::Type.ManualApproval,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Holds::ReleaseCondition { };

        Assert.Null(model.Approvers);
        Assert.False(model.RawData.ContainsKey("approvers"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.DocumentID);
        Assert.False(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Holds::ReleaseCondition { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            // Null should be interpreted as omitted for these properties
            Approvers = null,
            Date = null,
            DocumentID = null,
            Type = null,
        };

        Assert.Null(model.Approvers);
        Assert.False(model.RawData.ContainsKey("approvers"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.DocumentID);
        Assert.False(model.RawData.ContainsKey("document_id"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            // Null should be interpreted as omitted for these properties
            Approvers = null,
            Date = null,
            DocumentID = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Holds::ReleaseCondition
        {
            Approvers = ["string"],
            Date = "date",
            DocumentID = "document_id",
            Type = Holds::Type.ManualApproval,
        };

        Holds::ReleaseCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Holds::Type.ManualApproval)]
    [InlineData(Holds::Type.DocumentSigned)]
    [InlineData(Holds::Type.DateReached)]
    public void Validation_Works(Holds::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Holds::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Holds::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Holds::Type.ManualApproval)]
    [InlineData(Holds::Type.DocumentSigned)]
    [InlineData(Holds::Type.DateReached)]
    public void SerializationRoundtrip_Works(Holds::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Holds::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Holds::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Holds::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Holds::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
