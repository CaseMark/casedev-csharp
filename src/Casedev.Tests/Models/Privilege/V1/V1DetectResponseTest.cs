using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Privilege.V1;

namespace Casedev.Tests.Models.Privilege.V1;

public class V1DetectResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DetectResponse
        {
            Categories =
            [
                new()
                {
                    Confidence = 0,
                    Detected = true,
                    Indicators = ["string"],
                    Rationale = "rationale",
                    Type = "type",
                },
            ],
            Confidence = 0,
            PolicyRationale = "policy_rationale",
            Privileged = true,
            Recommendation = Recommendation.Withhold,
        };

        List<V1DetectResponseCategory> expectedCategories =
        [
            new()
            {
                Confidence = 0,
                Detected = true,
                Indicators = ["string"],
                Rationale = "rationale",
                Type = "type",
            },
        ];
        double expectedConfidence = 0;
        string expectedPolicyRationale = "policy_rationale";
        bool expectedPrivileged = true;
        ApiEnum<string, Recommendation> expectedRecommendation = Recommendation.Withhold;

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedPolicyRationale, model.PolicyRationale);
        Assert.Equal(expectedPrivileged, model.Privileged);
        Assert.Equal(expectedRecommendation, model.Recommendation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DetectResponse
        {
            Categories =
            [
                new()
                {
                    Confidence = 0,
                    Detected = true,
                    Indicators = ["string"],
                    Rationale = "rationale",
                    Type = "type",
                },
            ],
            Confidence = 0,
            PolicyRationale = "policy_rationale",
            Privileged = true,
            Recommendation = Recommendation.Withhold,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DetectResponse
        {
            Categories =
            [
                new()
                {
                    Confidence = 0,
                    Detected = true,
                    Indicators = ["string"],
                    Rationale = "rationale",
                    Type = "type",
                },
            ],
            Confidence = 0,
            PolicyRationale = "policy_rationale",
            Privileged = true,
            Recommendation = Recommendation.Withhold,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<V1DetectResponseCategory> expectedCategories =
        [
            new()
            {
                Confidence = 0,
                Detected = true,
                Indicators = ["string"],
                Rationale = "rationale",
                Type = "type",
            },
        ];
        double expectedConfidence = 0;
        string expectedPolicyRationale = "policy_rationale";
        bool expectedPrivileged = true;
        ApiEnum<string, Recommendation> expectedRecommendation = Recommendation.Withhold;

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedPolicyRationale, deserialized.PolicyRationale);
        Assert.Equal(expectedPrivileged, deserialized.Privileged);
        Assert.Equal(expectedRecommendation, deserialized.Recommendation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DetectResponse
        {
            Categories =
            [
                new()
                {
                    Confidence = 0,
                    Detected = true,
                    Indicators = ["string"],
                    Rationale = "rationale",
                    Type = "type",
                },
            ],
            Confidence = 0,
            PolicyRationale = "policy_rationale",
            Privileged = true,
            Recommendation = Recommendation.Withhold,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DetectResponse
        {
            Categories =
            [
                new()
                {
                    Confidence = 0,
                    Detected = true,
                    Indicators = ["string"],
                    Rationale = "rationale",
                    Type = "type",
                },
            ],
            Confidence = 0,
            PolicyRationale = "policy_rationale",
            Privileged = true,
            Recommendation = Recommendation.Withhold,
        };

        V1DetectResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1DetectResponseCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DetectResponseCategory
        {
            Confidence = 0,
            Detected = true,
            Indicators = ["string"],
            Rationale = "rationale",
            Type = "type",
        };

        double expectedConfidence = 0;
        bool expectedDetected = true;
        List<string> expectedIndicators = ["string"];
        string expectedRationale = "rationale";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedDetected, model.Detected);
        Assert.NotNull(model.Indicators);
        Assert.Equal(expectedIndicators.Count, model.Indicators.Count);
        for (int i = 0; i < expectedIndicators.Count; i++)
        {
            Assert.Equal(expectedIndicators[i], model.Indicators[i]);
        }
        Assert.Equal(expectedRationale, model.Rationale);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DetectResponseCategory
        {
            Confidence = 0,
            Detected = true,
            Indicators = ["string"],
            Rationale = "rationale",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponseCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DetectResponseCategory
        {
            Confidence = 0,
            Detected = true,
            Indicators = ["string"],
            Rationale = "rationale",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DetectResponseCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        bool expectedDetected = true;
        List<string> expectedIndicators = ["string"];
        string expectedRationale = "rationale";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedDetected, deserialized.Detected);
        Assert.NotNull(deserialized.Indicators);
        Assert.Equal(expectedIndicators.Count, deserialized.Indicators.Count);
        for (int i = 0; i < expectedIndicators.Count; i++)
        {
            Assert.Equal(expectedIndicators[i], deserialized.Indicators[i]);
        }
        Assert.Equal(expectedRationale, deserialized.Rationale);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DetectResponseCategory
        {
            Confidence = 0,
            Detected = true,
            Indicators = ["string"],
            Rationale = "rationale",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DetectResponseCategory { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Detected);
        Assert.False(model.RawData.ContainsKey("detected"));
        Assert.Null(model.Indicators);
        Assert.False(model.RawData.ContainsKey("indicators"));
        Assert.Null(model.Rationale);
        Assert.False(model.RawData.ContainsKey("rationale"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DetectResponseCategory { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DetectResponseCategory
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Detected = null,
            Indicators = null,
            Rationale = null,
            Type = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Detected);
        Assert.False(model.RawData.ContainsKey("detected"));
        Assert.Null(model.Indicators);
        Assert.False(model.RawData.ContainsKey("indicators"));
        Assert.Null(model.Rationale);
        Assert.False(model.RawData.ContainsKey("rationale"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DetectResponseCategory
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Detected = null,
            Indicators = null,
            Rationale = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DetectResponseCategory
        {
            Confidence = 0,
            Detected = true,
            Indicators = ["string"],
            Rationale = "rationale",
            Type = "type",
        };

        V1DetectResponseCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecommendationTest : TestBase
{
    [Theory]
    [InlineData(Recommendation.Withhold)]
    [InlineData(Recommendation.Redact)]
    [InlineData(Recommendation.Produce)]
    [InlineData(Recommendation.Review)]
    public void Validation_Works(Recommendation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Recommendation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Recommendation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Recommendation.Withhold)]
    [InlineData(Recommendation.Redact)]
    [InlineData(Recommendation.Produce)]
    [InlineData(Recommendation.Review)]
    public void SerializationRoundtrip_Works(Recommendation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Recommendation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Recommendation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Recommendation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Recommendation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
