using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Database.V1;

namespace Router.Tests.Models.Database.V1;

public class V1GetUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1GetUsageResponse
        {
            Period = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Pricing = new()
            {
                BranchPerMonth = 0,
                ComputePerCuHour = 0,
                FreeBranches = 0,
                StoragePerGBMonth = 0,
                TransferPerGB = 0,
            },
            ProjectCount = 0,
            Projects =
            [
                new()
                {
                    ID = "id",
                    BranchCount = 0,
                    ComputeCuHours = 0,
                    Costs = new()
                    {
                        Branches = "branches",
                        Compute = "compute",
                        Storage = "storage",
                        Total = "total",
                        Transfer = "transfer",
                    },
                    LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectID = "projectId",
                    ProjectName = "projectName",
                    StorageGBMonths = 0,
                    TransferGB = 0,
                },
            ],
            Totals = new()
            {
                BranchCostDollars = "branchCostDollars",
                ComputeCostDollars = "computeCostDollars",
                ComputeCuHours = 0,
                StorageCostDollars = "storageCostDollars",
                StorageGBMonths = 0,
                TotalBranches = 0,
                TotalCostDollars = "totalCostDollars",
                TransferCostDollars = "transferCostDollars",
                TransferGB = 0,
            },
        };

        Period expectedPeriod = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Pricing expectedPricing = new()
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };
        long expectedProjectCount = 0;
        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                BranchCount = 0,
                ComputeCuHours = 0,
                Costs = new()
                {
                    Branches = "branches",
                    Compute = "compute",
                    Storage = "storage",
                    Total = "total",
                    Transfer = "transfer",
                },
                LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProjectID = "projectId",
                ProjectName = "projectName",
                StorageGBMonths = 0,
                TransferGB = 0,
            },
        ];
        Totals expectedTotals = new()
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedPricing, model.Pricing);
        Assert.Equal(expectedProjectCount, model.ProjectCount);
        Assert.NotNull(model.Projects);
        Assert.Equal(expectedProjects.Count, model.Projects.Count);
        for (int i = 0; i < expectedProjects.Count; i++)
        {
            Assert.Equal(expectedProjects[i], model.Projects[i]);
        }
        Assert.Equal(expectedTotals, model.Totals);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1GetUsageResponse
        {
            Period = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Pricing = new()
            {
                BranchPerMonth = 0,
                ComputePerCuHour = 0,
                FreeBranches = 0,
                StoragePerGBMonth = 0,
                TransferPerGB = 0,
            },
            ProjectCount = 0,
            Projects =
            [
                new()
                {
                    ID = "id",
                    BranchCount = 0,
                    ComputeCuHours = 0,
                    Costs = new()
                    {
                        Branches = "branches",
                        Compute = "compute",
                        Storage = "storage",
                        Total = "total",
                        Transfer = "transfer",
                    },
                    LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectID = "projectId",
                    ProjectName = "projectName",
                    StorageGBMonths = 0,
                    TransferGB = 0,
                },
            ],
            Totals = new()
            {
                BranchCostDollars = "branchCostDollars",
                ComputeCostDollars = "computeCostDollars",
                ComputeCuHours = 0,
                StorageCostDollars = "storageCostDollars",
                StorageGBMonths = 0,
                TotalBranches = 0,
                TotalCostDollars = "totalCostDollars",
                TransferCostDollars = "transferCostDollars",
                TransferGB = 0,
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
            Period = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Pricing = new()
            {
                BranchPerMonth = 0,
                ComputePerCuHour = 0,
                FreeBranches = 0,
                StoragePerGBMonth = 0,
                TransferPerGB = 0,
            },
            ProjectCount = 0,
            Projects =
            [
                new()
                {
                    ID = "id",
                    BranchCount = 0,
                    ComputeCuHours = 0,
                    Costs = new()
                    {
                        Branches = "branches",
                        Compute = "compute",
                        Storage = "storage",
                        Total = "total",
                        Transfer = "transfer",
                    },
                    LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectID = "projectId",
                    ProjectName = "projectName",
                    StorageGBMonths = 0,
                    TransferGB = 0,
                },
            ],
            Totals = new()
            {
                BranchCostDollars = "branchCostDollars",
                ComputeCostDollars = "computeCostDollars",
                ComputeCuHours = 0,
                StorageCostDollars = "storageCostDollars",
                StorageGBMonths = 0,
                TotalBranches = 0,
                TotalCostDollars = "totalCostDollars",
                TransferCostDollars = "transferCostDollars",
                TransferGB = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Period expectedPeriod = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Pricing expectedPricing = new()
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };
        long expectedProjectCount = 0;
        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                BranchCount = 0,
                ComputeCuHours = 0,
                Costs = new()
                {
                    Branches = "branches",
                    Compute = "compute",
                    Storage = "storage",
                    Total = "total",
                    Transfer = "transfer",
                },
                LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProjectID = "projectId",
                ProjectName = "projectName",
                StorageGBMonths = 0,
                TransferGB = 0,
            },
        ];
        Totals expectedTotals = new()
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedPricing, deserialized.Pricing);
        Assert.Equal(expectedProjectCount, deserialized.ProjectCount);
        Assert.NotNull(deserialized.Projects);
        Assert.Equal(expectedProjects.Count, deserialized.Projects.Count);
        for (int i = 0; i < expectedProjects.Count; i++)
        {
            Assert.Equal(expectedProjects[i], deserialized.Projects[i]);
        }
        Assert.Equal(expectedTotals, deserialized.Totals);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1GetUsageResponse
        {
            Period = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Pricing = new()
            {
                BranchPerMonth = 0,
                ComputePerCuHour = 0,
                FreeBranches = 0,
                StoragePerGBMonth = 0,
                TransferPerGB = 0,
            },
            ProjectCount = 0,
            Projects =
            [
                new()
                {
                    ID = "id",
                    BranchCount = 0,
                    ComputeCuHours = 0,
                    Costs = new()
                    {
                        Branches = "branches",
                        Compute = "compute",
                        Storage = "storage",
                        Total = "total",
                        Transfer = "transfer",
                    },
                    LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectID = "projectId",
                    ProjectName = "projectName",
                    StorageGBMonths = 0,
                    TransferGB = 0,
                },
            ],
            Totals = new()
            {
                BranchCostDollars = "branchCostDollars",
                ComputeCostDollars = "computeCostDollars",
                ComputeCuHours = 0,
                StorageCostDollars = "storageCostDollars",
                StorageGBMonths = 0,
                TotalBranches = 0,
                TotalCostDollars = "totalCostDollars",
                TransferCostDollars = "transferCostDollars",
                TransferGB = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetUsageResponse { };

        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.ProjectCount);
        Assert.False(model.RawData.ContainsKey("projectCount"));
        Assert.Null(model.Projects);
        Assert.False(model.RawData.ContainsKey("projects"));
        Assert.Null(model.Totals);
        Assert.False(model.RawData.ContainsKey("totals"));
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
            Period = null,
            Pricing = null,
            ProjectCount = null,
            Projects = null,
            Totals = null,
        };

        Assert.Null(model.Period);
        Assert.False(model.RawData.ContainsKey("period"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.ProjectCount);
        Assert.False(model.RawData.ContainsKey("projectCount"));
        Assert.Null(model.Projects);
        Assert.False(model.RawData.ContainsKey("projects"));
        Assert.Null(model.Totals);
        Assert.False(model.RawData.ContainsKey("totals"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetUsageResponse
        {
            // Null should be interpreted as omitted for these properties
            Period = null,
            Pricing = null,
            ProjectCount = null,
            Projects = null,
            Totals = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1GetUsageResponse
        {
            Period = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Pricing = new()
            {
                BranchPerMonth = 0,
                ComputePerCuHour = 0,
                FreeBranches = 0,
                StoragePerGBMonth = 0,
                TransferPerGB = 0,
            },
            ProjectCount = 0,
            Projects =
            [
                new()
                {
                    ID = "id",
                    BranchCount = 0,
                    ComputeCuHours = 0,
                    Costs = new()
                    {
                        Branches = "branches",
                        Compute = "compute",
                        Storage = "storage",
                        Total = "total",
                        Transfer = "transfer",
                    },
                    LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectID = "projectId",
                    ProjectName = "projectName",
                    StorageGBMonths = 0,
                    TransferGB = 0,
                },
            ],
            Totals = new()
            {
                BranchCostDollars = "branchCostDollars",
                ComputeCostDollars = "computeCostDollars",
                ComputeCuHours = 0,
                StorageCostDollars = "storageCostDollars",
                StorageGBMonths = 0,
                TotalBranches = 0,
                TotalCostDollars = "totalCostDollars",
                TransferCostDollars = "transferCostDollars",
                TransferGB = 0,
            },
        };

        V1GetUsageResponse copied = new(model);

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
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Period
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Period>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Period
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Period { };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
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
            End = null,
            Start = null,
        };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Period
        {
            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Period
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Period copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pricing
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };

        double expectedBranchPerMonth = 0;
        double expectedComputePerCuHour = 0;
        long expectedFreeBranches = 0;
        double expectedStoragePerGBMonth = 0;
        double expectedTransferPerGB = 0;

        Assert.Equal(expectedBranchPerMonth, model.BranchPerMonth);
        Assert.Equal(expectedComputePerCuHour, model.ComputePerCuHour);
        Assert.Equal(expectedFreeBranches, model.FreeBranches);
        Assert.Equal(expectedStoragePerGBMonth, model.StoragePerGBMonth);
        Assert.Equal(expectedTransferPerGB, model.TransferPerGB);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pricing
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pricing
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBranchPerMonth = 0;
        double expectedComputePerCuHour = 0;
        long expectedFreeBranches = 0;
        double expectedStoragePerGBMonth = 0;
        double expectedTransferPerGB = 0;

        Assert.Equal(expectedBranchPerMonth, deserialized.BranchPerMonth);
        Assert.Equal(expectedComputePerCuHour, deserialized.ComputePerCuHour);
        Assert.Equal(expectedFreeBranches, deserialized.FreeBranches);
        Assert.Equal(expectedStoragePerGBMonth, deserialized.StoragePerGBMonth);
        Assert.Equal(expectedTransferPerGB, deserialized.TransferPerGB);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pricing
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pricing { };

        Assert.Null(model.BranchPerMonth);
        Assert.False(model.RawData.ContainsKey("branchPerMonth"));
        Assert.Null(model.ComputePerCuHour);
        Assert.False(model.RawData.ContainsKey("computePerCuHour"));
        Assert.Null(model.FreeBranches);
        Assert.False(model.RawData.ContainsKey("freeBranches"));
        Assert.Null(model.StoragePerGBMonth);
        Assert.False(model.RawData.ContainsKey("storagePerGbMonth"));
        Assert.Null(model.TransferPerGB);
        Assert.False(model.RawData.ContainsKey("transferPerGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pricing { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            BranchPerMonth = null,
            ComputePerCuHour = null,
            FreeBranches = null,
            StoragePerGBMonth = null,
            TransferPerGB = null,
        };

        Assert.Null(model.BranchPerMonth);
        Assert.False(model.RawData.ContainsKey("branchPerMonth"));
        Assert.Null(model.ComputePerCuHour);
        Assert.False(model.RawData.ContainsKey("computePerCuHour"));
        Assert.Null(model.FreeBranches);
        Assert.False(model.RawData.ContainsKey("freeBranches"));
        Assert.Null(model.StoragePerGBMonth);
        Assert.False(model.RawData.ContainsKey("storagePerGbMonth"));
        Assert.Null(model.TransferPerGB);
        Assert.False(model.RawData.ContainsKey("transferPerGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            BranchPerMonth = null,
            ComputePerCuHour = null,
            FreeBranches = null,
            StoragePerGBMonth = null,
            TransferPerGB = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pricing
        {
            BranchPerMonth = 0,
            ComputePerCuHour = 0,
            FreeBranches = 0,
            StoragePerGBMonth = 0,
            TransferPerGB = 0,
        };

        Pricing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            ProjectName = "projectName",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        string expectedID = "id";
        long expectedBranchCount = 0;
        double expectedComputeCuHours = 0;
        Costs expectedCosts = new()
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };
        DateTimeOffset expectedLastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectID = "projectId";
        string expectedProjectName = "projectName";
        double expectedStorageGBMonths = 0;
        double expectedTransferGB = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBranchCount, model.BranchCount);
        Assert.Equal(expectedComputeCuHours, model.ComputeCuHours);
        Assert.Equal(expectedCosts, model.Costs);
        Assert.Equal(expectedLastUpdated, model.LastUpdated);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedProjectName, model.ProjectName);
        Assert.Equal(expectedStorageGBMonths, model.StorageGBMonths);
        Assert.Equal(expectedTransferGB, model.TransferGB);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            ProjectName = "projectName",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            ProjectName = "projectName",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBranchCount = 0;
        double expectedComputeCuHours = 0;
        Costs expectedCosts = new()
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };
        DateTimeOffset expectedLastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectID = "projectId";
        string expectedProjectName = "projectName";
        double expectedStorageGBMonths = 0;
        double expectedTransferGB = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBranchCount, deserialized.BranchCount);
        Assert.Equal(expectedComputeCuHours, deserialized.ComputeCuHours);
        Assert.Equal(expectedCosts, deserialized.Costs);
        Assert.Equal(expectedLastUpdated, deserialized.LastUpdated);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedProjectName, deserialized.ProjectName);
        Assert.Equal(expectedStorageGBMonths, deserialized.StorageGBMonths);
        Assert.Equal(expectedTransferGB, deserialized.TransferGB);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            ProjectName = "projectName",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Project { ProjectName = "projectName" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BranchCount);
        Assert.False(model.RawData.ContainsKey("branchCount"));
        Assert.Null(model.ComputeCuHours);
        Assert.False(model.RawData.ContainsKey("computeCuHours"));
        Assert.Null(model.Costs);
        Assert.False(model.RawData.ContainsKey("costs"));
        Assert.Null(model.LastUpdated);
        Assert.False(model.RawData.ContainsKey("lastUpdated"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.StorageGBMonths);
        Assert.False(model.RawData.ContainsKey("storageGbMonths"));
        Assert.Null(model.TransferGB);
        Assert.False(model.RawData.ContainsKey("transferGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Project { ProjectName = "projectName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Project
        {
            ProjectName = "projectName",

            // Null should be interpreted as omitted for these properties
            ID = null,
            BranchCount = null,
            ComputeCuHours = null,
            Costs = null,
            LastUpdated = null,
            ProjectID = null,
            StorageGBMonths = null,
            TransferGB = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BranchCount);
        Assert.False(model.RawData.ContainsKey("branchCount"));
        Assert.Null(model.ComputeCuHours);
        Assert.False(model.RawData.ContainsKey("computeCuHours"));
        Assert.Null(model.Costs);
        Assert.False(model.RawData.ContainsKey("costs"));
        Assert.Null(model.LastUpdated);
        Assert.False(model.RawData.ContainsKey("lastUpdated"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("projectId"));
        Assert.Null(model.StorageGBMonths);
        Assert.False(model.RawData.ContainsKey("storageGbMonths"));
        Assert.Null(model.TransferGB);
        Assert.False(model.RawData.ContainsKey("transferGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Project
        {
            ProjectName = "projectName",

            // Null should be interpreted as omitted for these properties
            ID = null,
            BranchCount = null,
            ComputeCuHours = null,
            Costs = null,
            LastUpdated = null,
            ProjectID = null,
            StorageGBMonths = null,
            TransferGB = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        Assert.Null(model.ProjectName);
        Assert.False(model.RawData.ContainsKey("projectName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            StorageGBMonths = 0,
            TransferGB = 0,

            ProjectName = null,
        };

        Assert.Null(model.ProjectName);
        Assert.True(model.RawData.ContainsKey("projectName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            StorageGBMonths = 0,
            TransferGB = 0,

            ProjectName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Project
        {
            ID = "id",
            BranchCount = 0,
            ComputeCuHours = 0,
            Costs = new()
            {
                Branches = "branches",
                Compute = "compute",
                Storage = "storage",
                Total = "total",
                Transfer = "transfer",
            },
            LastUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectID = "projectId",
            ProjectName = "projectName",
            StorageGBMonths = 0,
            TransferGB = 0,
        };

        Project copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CostsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Costs
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };

        string expectedBranches = "branches";
        string expectedCompute = "compute";
        string expectedStorage = "storage";
        string expectedTotal = "total";
        string expectedTransfer = "transfer";

        Assert.Equal(expectedBranches, model.Branches);
        Assert.Equal(expectedCompute, model.Compute);
        Assert.Equal(expectedStorage, model.Storage);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedTransfer, model.Transfer);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Costs
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Costs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Costs
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Costs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBranches = "branches";
        string expectedCompute = "compute";
        string expectedStorage = "storage";
        string expectedTotal = "total";
        string expectedTransfer = "transfer";

        Assert.Equal(expectedBranches, deserialized.Branches);
        Assert.Equal(expectedCompute, deserialized.Compute);
        Assert.Equal(expectedStorage, deserialized.Storage);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedTransfer, deserialized.Transfer);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Costs
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Costs { };

        Assert.Null(model.Branches);
        Assert.False(model.RawData.ContainsKey("branches"));
        Assert.Null(model.Compute);
        Assert.False(model.RawData.ContainsKey("compute"));
        Assert.Null(model.Storage);
        Assert.False(model.RawData.ContainsKey("storage"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Transfer);
        Assert.False(model.RawData.ContainsKey("transfer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Costs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Costs
        {
            // Null should be interpreted as omitted for these properties
            Branches = null,
            Compute = null,
            Storage = null,
            Total = null,
            Transfer = null,
        };

        Assert.Null(model.Branches);
        Assert.False(model.RawData.ContainsKey("branches"));
        Assert.Null(model.Compute);
        Assert.False(model.RawData.ContainsKey("compute"));
        Assert.Null(model.Storage);
        Assert.False(model.RawData.ContainsKey("storage"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Transfer);
        Assert.False(model.RawData.ContainsKey("transfer"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Costs
        {
            // Null should be interpreted as omitted for these properties
            Branches = null,
            Compute = null,
            Storage = null,
            Total = null,
            Transfer = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Costs
        {
            Branches = "branches",
            Compute = "compute",
            Storage = "storage",
            Total = "total",
            Transfer = "transfer",
        };

        Costs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Totals
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        string expectedBranchCostDollars = "branchCostDollars";
        string expectedComputeCostDollars = "computeCostDollars";
        double expectedComputeCuHours = 0;
        string expectedStorageCostDollars = "storageCostDollars";
        double expectedStorageGBMonths = 0;
        long expectedTotalBranches = 0;
        string expectedTotalCostDollars = "totalCostDollars";
        string expectedTransferCostDollars = "transferCostDollars";
        double expectedTransferGB = 0;

        Assert.Equal(expectedBranchCostDollars, model.BranchCostDollars);
        Assert.Equal(expectedComputeCostDollars, model.ComputeCostDollars);
        Assert.Equal(expectedComputeCuHours, model.ComputeCuHours);
        Assert.Equal(expectedStorageCostDollars, model.StorageCostDollars);
        Assert.Equal(expectedStorageGBMonths, model.StorageGBMonths);
        Assert.Equal(expectedTotalBranches, model.TotalBranches);
        Assert.Equal(expectedTotalCostDollars, model.TotalCostDollars);
        Assert.Equal(expectedTransferCostDollars, model.TransferCostDollars);
        Assert.Equal(expectedTransferGB, model.TransferGB);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Totals
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Totals>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Totals
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Totals>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBranchCostDollars = "branchCostDollars";
        string expectedComputeCostDollars = "computeCostDollars";
        double expectedComputeCuHours = 0;
        string expectedStorageCostDollars = "storageCostDollars";
        double expectedStorageGBMonths = 0;
        long expectedTotalBranches = 0;
        string expectedTotalCostDollars = "totalCostDollars";
        string expectedTransferCostDollars = "transferCostDollars";
        double expectedTransferGB = 0;

        Assert.Equal(expectedBranchCostDollars, deserialized.BranchCostDollars);
        Assert.Equal(expectedComputeCostDollars, deserialized.ComputeCostDollars);
        Assert.Equal(expectedComputeCuHours, deserialized.ComputeCuHours);
        Assert.Equal(expectedStorageCostDollars, deserialized.StorageCostDollars);
        Assert.Equal(expectedStorageGBMonths, deserialized.StorageGBMonths);
        Assert.Equal(expectedTotalBranches, deserialized.TotalBranches);
        Assert.Equal(expectedTotalCostDollars, deserialized.TotalCostDollars);
        Assert.Equal(expectedTransferCostDollars, deserialized.TransferCostDollars);
        Assert.Equal(expectedTransferGB, deserialized.TransferGB);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Totals
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Totals { };

        Assert.Null(model.BranchCostDollars);
        Assert.False(model.RawData.ContainsKey("branchCostDollars"));
        Assert.Null(model.ComputeCostDollars);
        Assert.False(model.RawData.ContainsKey("computeCostDollars"));
        Assert.Null(model.ComputeCuHours);
        Assert.False(model.RawData.ContainsKey("computeCuHours"));
        Assert.Null(model.StorageCostDollars);
        Assert.False(model.RawData.ContainsKey("storageCostDollars"));
        Assert.Null(model.StorageGBMonths);
        Assert.False(model.RawData.ContainsKey("storageGbMonths"));
        Assert.Null(model.TotalBranches);
        Assert.False(model.RawData.ContainsKey("totalBranches"));
        Assert.Null(model.TotalCostDollars);
        Assert.False(model.RawData.ContainsKey("totalCostDollars"));
        Assert.Null(model.TransferCostDollars);
        Assert.False(model.RawData.ContainsKey("transferCostDollars"));
        Assert.Null(model.TransferGB);
        Assert.False(model.RawData.ContainsKey("transferGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Totals { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Totals
        {
            // Null should be interpreted as omitted for these properties
            BranchCostDollars = null,
            ComputeCostDollars = null,
            ComputeCuHours = null,
            StorageCostDollars = null,
            StorageGBMonths = null,
            TotalBranches = null,
            TotalCostDollars = null,
            TransferCostDollars = null,
            TransferGB = null,
        };

        Assert.Null(model.BranchCostDollars);
        Assert.False(model.RawData.ContainsKey("branchCostDollars"));
        Assert.Null(model.ComputeCostDollars);
        Assert.False(model.RawData.ContainsKey("computeCostDollars"));
        Assert.Null(model.ComputeCuHours);
        Assert.False(model.RawData.ContainsKey("computeCuHours"));
        Assert.Null(model.StorageCostDollars);
        Assert.False(model.RawData.ContainsKey("storageCostDollars"));
        Assert.Null(model.StorageGBMonths);
        Assert.False(model.RawData.ContainsKey("storageGbMonths"));
        Assert.Null(model.TotalBranches);
        Assert.False(model.RawData.ContainsKey("totalBranches"));
        Assert.Null(model.TotalCostDollars);
        Assert.False(model.RawData.ContainsKey("totalCostDollars"));
        Assert.Null(model.TransferCostDollars);
        Assert.False(model.RawData.ContainsKey("transferCostDollars"));
        Assert.Null(model.TransferGB);
        Assert.False(model.RawData.ContainsKey("transferGb"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Totals
        {
            // Null should be interpreted as omitted for these properties
            BranchCostDollars = null,
            ComputeCostDollars = null,
            ComputeCuHours = null,
            StorageCostDollars = null,
            StorageGBMonths = null,
            TotalBranches = null,
            TotalCostDollars = null,
            TransferCostDollars = null,
            TransferGB = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Totals
        {
            BranchCostDollars = "branchCostDollars",
            ComputeCostDollars = "computeCostDollars",
            ComputeCuHours = 0,
            StorageCostDollars = "storageCostDollars",
            StorageGBMonths = 0,
            TotalBranches = 0,
            TotalCostDollars = "totalCostDollars",
            TransferCostDollars = "transferCostDollars",
            TransferGB = 0,
        };

        Totals copied = new(model);

        Assert.Equal(model, copied);
    }
}
