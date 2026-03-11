using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Voice.BoostList;

namespace Casedev.Tests.Models.Voice.BoostList;

public class BoostListGenerateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BoostListGenerateParams
        {
            TranscriptionJobID = "transcription_job_id",
            Categories = [BoostListGenerateParamsCategory.Person],
        };

        string expectedTranscriptionJobID = "transcription_job_id";
        List<ApiEnum<string, BoostListGenerateParamsCategory>> expectedCategories =
        [
            BoostListGenerateParamsCategory.Person,
        ];

        Assert.Equal(expectedTranscriptionJobID, parameters.TranscriptionJobID);
        Assert.NotNull(parameters.Categories);
        Assert.Equal(expectedCategories.Count, parameters.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], parameters.Categories[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BoostListGenerateParams
        {
            TranscriptionJobID = "transcription_job_id",
        };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BoostListGenerateParams
        {
            TranscriptionJobID = "transcription_job_id",

            // Null should be interpreted as omitted for these properties
            Categories = null,
        };

        Assert.Null(parameters.Categories);
        Assert.False(parameters.RawBodyData.ContainsKey("categories"));
    }

    [Fact]
    public void Url_Works()
    {
        BoostListGenerateParams parameters = new() { TranscriptionJobID = "transcription_job_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/voice/boost-list/generate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BoostListGenerateParams
        {
            TranscriptionJobID = "transcription_job_id",
            Categories = [BoostListGenerateParamsCategory.Person],
        };

        BoostListGenerateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BoostListGenerateParamsCategoryTest : TestBase
{
    [Theory]
    [InlineData(BoostListGenerateParamsCategory.Person)]
    [InlineData(BoostListGenerateParamsCategory.Organization)]
    [InlineData(BoostListGenerateParamsCategory.LegalTerm)]
    [InlineData(BoostListGenerateParamsCategory.Medical)]
    [InlineData(BoostListGenerateParamsCategory.Citation)]
    [InlineData(BoostListGenerateParamsCategory.Email)]
    public void Validation_Works(BoostListGenerateParamsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateParamsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostListGenerateParamsCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BoostListGenerateParamsCategory.Person)]
    [InlineData(BoostListGenerateParamsCategory.Organization)]
    [InlineData(BoostListGenerateParamsCategory.LegalTerm)]
    [InlineData(BoostListGenerateParamsCategory.Medical)]
    [InlineData(BoostListGenerateParamsCategory.Citation)]
    [InlineData(BoostListGenerateParamsCategory.Email)]
    public void SerializationRoundtrip_Works(BoostListGenerateParamsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BoostListGenerateParamsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateParamsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BoostListGenerateParamsCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BoostListGenerateParamsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
