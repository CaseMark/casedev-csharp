using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class V1GetUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1GetUsageResponse
        {
            ByEnvironment =
            [
                new()
                {
                    Environment = "environment",
                    TotalCostCents = 0,
                    TotalCostFormatted = "totalCostFormatted",
                    TotalCpuSeconds = 0,
                    TotalGpuSeconds = 0,
                    TotalRuns = 0,
                },
            ],
            Period = new()
            {
                Month = 0,
                MonthName = "monthName",
                Year = 0,
            },
            Summary = new()
            {
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuHours = 0,
                TotalGpuHours = 0,
                TotalRuns = 0,
            },
        };

        List<ByEnvironment> expectedByEnvironment =
        [
            new()
            {
                Environment = "environment",
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuSeconds = 0,
                TotalGpuSeconds = 0,
                TotalRuns = 0,
            },
        ];
        Period expectedPeriod = new()
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };
        Summary expectedSummary = new()
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        Assert.NotNull(model.ByEnvironment);
        Assert.Equal(expectedByEnvironment.Count, model.ByEnvironment.Count);
        for (int i = 0; i < expectedByEnvironment.Count; i++)
        {
            Assert.Equal(expectedByEnvironment[i], model.ByEnvironment[i]);
        }
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1GetUsageResponse
        {
            ByEnvironment =
            [
                new()
                {
                    Environment = "environment",
                    TotalCostCents = 0,
                    TotalCostFormatted = "totalCostFormatted",
                    TotalCpuSeconds = 0,
                    TotalGpuSeconds = 0,
                    TotalRuns = 0,
                },
            ],
            Period = new()
            {
                Month = 0,
                MonthName = "monthName",
                Year = 0,
            },
            Summary = new()
            {
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuHours = 0,
                TotalGpuHours = 0,
                TotalRuns = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1GetUsageResponse
        {
            ByEnvironment =
            [
                new()
                {
                    Environment = "environment",
                    TotalCostCents = 0,
                    TotalCostFormatted = "totalCostFormatted",
                    TotalCpuSeconds = 0,
                    TotalGpuSeconds = 0,
                    TotalRuns = 0,
                },
            ],
            Period = new()
            {
                Month = 0,
                MonthName = "monthName",
                Year = 0,
            },
            Summary = new()
            {
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuHours = 0,
                TotalGpuHours = 0,
                TotalRuns = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ByEnvironment> expectedByEnvironment =
        [
            new()
            {
                Environment = "environment",
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuSeconds = 0,
                TotalGpuSeconds = 0,
                TotalRuns = 0,
            },
        ];
        Period expectedPeriod = new()
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };
        Summary expectedSummary = new()
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        Assert.NotNull(deserialized.ByEnvironment);
        Assert.Equal(expectedByEnvironment.Count, deserialized.ByEnvironment.Count);
        for (int i = 0; i < expectedByEnvironment.Count; i++)
        {
            Assert.Equal(expectedByEnvironment[i], deserialized.ByEnvironment[i]);
        }
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1GetUsageResponse
        {
            ByEnvironment =
            [
                new()
                {
                    Environment = "environment",
                    TotalCostCents = 0,
                    TotalCostFormatted = "totalCostFormatted",
                    TotalCpuSeconds = 0,
                    TotalGpuSeconds = 0,
                    TotalRuns = 0,
                },
            ],
            Period = new()
            {
                Month = 0,
                MonthName = "monthName",
                Year = 0,
            },
            Summary = new()
            {
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuHours = 0,
                TotalGpuHours = 0,
                TotalRuns = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetUsageResponse { };

        Assert.Null(model.ByEnvironment);
        Assert.False(model.RawData.ContainsKey("byEnvironment"));
        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1GetUsageResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1GetUsageResponse
        {
            // Null should be interpreted as omitted for these properties
            ByEnvironment = null,
            Period = null,
            Summary = null,
        };

        Assert.Null(model.ByEnvironment);
        Assert.False(model.RawData.ContainsKey("byEnvironment"));
        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetUsageResponse
        {
            // Null should be interpreted as omitted for these properties
            ByEnvironment = null,
            Period = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1GetUsageResponse
        {
            ByEnvironment =
            [
                new()
                {
                    Environment = "environment",
                    TotalCostCents = 0,
                    TotalCostFormatted = "totalCostFormatted",
                    TotalCpuSeconds = 0,
                    TotalGpuSeconds = 0,
                    TotalRuns = 0,
                },
            ],
            Period = new()
            {
                Month = 0,
                MonthName = "monthName",
                Year = 0,
            },
            Summary = new()
            {
                TotalCostCents = 0,
                TotalCostFormatted = "totalCostFormatted",
                TotalCpuHours = 0,
                TotalGpuHours = 0,
                TotalRuns = 0,
            },
        };

        V1GetUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ByEnvironmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ByEnvironment
        {
            Environment = "environment",
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuSeconds = 0,
            TotalGpuSeconds = 0,
            TotalRuns = 0,
        };

        string expectedEnvironment = "environment";
        long expectedTotalCostCents = 0;
        string expectedTotalCostFormatted = "totalCostFormatted";
        long expectedTotalCpuSeconds = 0;
        long expectedTotalGpuSeconds = 0;
        long expectedTotalRuns = 0;

        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedTotalCostCents, model.TotalCostCents);
        Assert.Equal(expectedTotalCostFormatted, model.TotalCostFormatted);
        Assert.Equal(expectedTotalCpuSeconds, model.TotalCpuSeconds);
        Assert.Equal(expectedTotalGpuSeconds, model.TotalGpuSeconds);
        Assert.Equal(expectedTotalRuns, model.TotalRuns);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ByEnvironment
        {
            Environment = "environment",
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuSeconds = 0,
            TotalGpuSeconds = 0,
            TotalRuns = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByEnvironment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ByEnvironment
        {
            Environment = "environment",
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuSeconds = 0,
            TotalGpuSeconds = 0,
            TotalRuns = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByEnvironment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEnvironment = "environment";
        long expectedTotalCostCents = 0;
        string expectedTotalCostFormatted = "totalCostFormatted";
        long expectedTotalCpuSeconds = 0;
        long expectedTotalGpuSeconds = 0;
        long expectedTotalRuns = 0;

        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedTotalCostCents, deserialized.TotalCostCents);
        Assert.Equal(expectedTotalCostFormatted, deserialized.TotalCostFormatted);
        Assert.Equal(expectedTotalCpuSeconds, deserialized.TotalCpuSeconds);
        Assert.Equal(expectedTotalGpuSeconds, deserialized.TotalGpuSeconds);
        Assert.Equal(expectedTotalRuns, deserialized.TotalRuns);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ByEnvironment
        {
            Environment = "environment",
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuSeconds = 0,
            TotalGpuSeconds = 0,
            TotalRuns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ByEnvironment { };

        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.TotalCostCents);
        Assert.False(model.RawData.ContainsKey("totalCostCents"));
        Assert.Null(model.TotalCostFormatted);
        Assert.False(model.RawData.ContainsKey("totalCostFormatted"));
        Assert.Null(model.TotalCpuSeconds);
        Assert.False(model.RawData.ContainsKey("totalCpuSeconds"));
        Assert.Null(model.TotalGpuSeconds);
        Assert.False(model.RawData.ContainsKey("totalGpuSeconds"));
        Assert.Null(model.TotalRuns);
        Assert.False(model.RawData.ContainsKey("totalRuns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ByEnvironment { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ByEnvironment
        {
            // Null should be interpreted as omitted for these properties
            Environment = null,
            TotalCostCents = null,
            TotalCostFormatted = null,
            TotalCpuSeconds = null,
            TotalGpuSeconds = null,
            TotalRuns = null,
        };

        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.TotalCostCents);
        Assert.False(model.RawData.ContainsKey("totalCostCents"));
        Assert.Null(model.TotalCostFormatted);
        Assert.False(model.RawData.ContainsKey("totalCostFormatted"));
        Assert.Null(model.TotalCpuSeconds);
        Assert.False(model.RawData.ContainsKey("totalCpuSeconds"));
        Assert.Null(model.TotalGpuSeconds);
        Assert.False(model.RawData.ContainsKey("totalGpuSeconds"));
        Assert.Null(model.TotalRuns);
        Assert.False(model.RawData.ContainsKey("totalRuns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ByEnvironment
        {
            // Null should be interpreted as omitted for these properties
            Environment = null,
            TotalCostCents = null,
            TotalCostFormatted = null,
            TotalCpuSeconds = null,
            TotalGpuSeconds = null,
            TotalRuns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ByEnvironment
        {
            Environment = "environment",
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuSeconds = 0,
            TotalGpuSeconds = 0,
            TotalRuns = 0,
        };

        ByEnvironment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Period
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };

        long expectedMonth = 0;
        string expectedMonthName = "monthName";
        long expectedYear = 0;

        Assert.Equal(expectedMonth, model.Month);
        Assert.Equal(expectedMonthName, model.MonthName);
        Assert.Equal(expectedYear, model.Year);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Period
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Period>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Period
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Period>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedMonth = 0;
        string expectedMonthName = "monthName";
        long expectedYear = 0;

        Assert.Equal(expectedMonth, deserialized.Month);
        Assert.Equal(expectedMonthName, deserialized.MonthName);
        Assert.Equal(expectedYear, deserialized.Year);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Period
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Period { };

        Assert.Null(model.Month);
        Assert.False(model.RawData.ContainsKey("month"));
        Assert.Null(model.MonthName);
        Assert.False(model.RawData.ContainsKey("monthName"));
        Assert.Null(model.Year);
        Assert.False(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Period { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Period
        {
            // Null should be interpreted as omitted for these properties
            Month = null,
            MonthName = null,
            Year = null,
        };

        Assert.Null(model.Month);
        Assert.False(model.RawData.ContainsKey("month"));
        Assert.Null(model.MonthName);
        Assert.False(model.RawData.ContainsKey("monthName"));
        Assert.Null(model.Year);
        Assert.False(model.RawData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Period
        {
            // Null should be interpreted as omitted for these properties
            Month = null,
            MonthName = null,
            Year = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Period
        {
            Month = 0,
            MonthName = "monthName",
            Year = 0,
        };

        Period copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Summary
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        long expectedTotalCostCents = 0;
        string expectedTotalCostFormatted = "totalCostFormatted";
        double expectedTotalCpuHours = 0;
        double expectedTotalGpuHours = 0;
        long expectedTotalRuns = 0;

        Assert.Equal(expectedTotalCostCents, model.TotalCostCents);
        Assert.Equal(expectedTotalCostFormatted, model.TotalCostFormatted);
        Assert.Equal(expectedTotalCpuHours, model.TotalCpuHours);
        Assert.Equal(expectedTotalGpuHours, model.TotalGpuHours);
        Assert.Equal(expectedTotalRuns, model.TotalRuns);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Summary
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Summary
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotalCostCents = 0;
        string expectedTotalCostFormatted = "totalCostFormatted";
        double expectedTotalCpuHours = 0;
        double expectedTotalGpuHours = 0;
        long expectedTotalRuns = 0;

        Assert.Equal(expectedTotalCostCents, deserialized.TotalCostCents);
        Assert.Equal(expectedTotalCostFormatted, deserialized.TotalCostFormatted);
        Assert.Equal(expectedTotalCpuHours, deserialized.TotalCpuHours);
        Assert.Equal(expectedTotalGpuHours, deserialized.TotalGpuHours);
        Assert.Equal(expectedTotalRuns, deserialized.TotalRuns);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Summary
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Summary { };

        Assert.Null(model.TotalCostCents);
        Assert.False(model.RawData.ContainsKey("totalCostCents"));
        Assert.Null(model.TotalCostFormatted);
        Assert.False(model.RawData.ContainsKey("totalCostFormatted"));
        Assert.Null(model.TotalCpuHours);
        Assert.False(model.RawData.ContainsKey("totalCpuHours"));
        Assert.Null(model.TotalGpuHours);
        Assert.False(model.RawData.ContainsKey("totalGpuHours"));
        Assert.Null(model.TotalRuns);
        Assert.False(model.RawData.ContainsKey("totalRuns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Summary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Summary
        {
            // Null should be interpreted as omitted for these properties
            TotalCostCents = null,
            TotalCostFormatted = null,
            TotalCpuHours = null,
            TotalGpuHours = null,
            TotalRuns = null,
        };

        Assert.Null(model.TotalCostCents);
        Assert.False(model.RawData.ContainsKey("totalCostCents"));
        Assert.Null(model.TotalCostFormatted);
        Assert.False(model.RawData.ContainsKey("totalCostFormatted"));
        Assert.Null(model.TotalCpuHours);
        Assert.False(model.RawData.ContainsKey("totalCpuHours"));
        Assert.Null(model.TotalGpuHours);
        Assert.False(model.RawData.ContainsKey("totalGpuHours"));
        Assert.Null(model.TotalRuns);
        Assert.False(model.RawData.ContainsKey("totalRuns"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Summary
        {
            // Null should be interpreted as omitted for these properties
            TotalCostCents = null,
            TotalCostFormatted = null,
            TotalCpuHours = null,
            TotalGpuHours = null,
            TotalRuns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Summary
        {
            TotalCostCents = 0,
            TotalCostFormatted = "totalCostFormatted",
            TotalCpuHours = 0,
            TotalGpuHours = 0,
            TotalRuns = 0,
        };

        Summary copied = new(model);

        Assert.Equal(model, copied);
    }
}
