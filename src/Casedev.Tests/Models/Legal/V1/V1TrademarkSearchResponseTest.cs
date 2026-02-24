using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1TrademarkSearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            NiceClasses = [0],
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
            Status = "status",
            StatusDate = "2019-12-27",
            UsptoUrl = "usptoUrl",
        };

        string expectedAttorney = "attorney";
        string expectedFilingDate = "2019-12-27";
        List<GoodsAndService> expectedGoodsAndServices =
        [
            new() { ClassNumber = "classNumber", Description = "description" },
        ];
        string expectedImageUrl = "imageUrl";
        string expectedMarkText = "markText";
        string expectedMarkType = "markType";
        List<long> expectedNiceClasses = [0];
        Owner expectedOwner = new()
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };
        string expectedRegistrationDate = "2019-12-27";
        string expectedRegistrationNumber = "registrationNumber";
        string expectedSerialNumber = "serialNumber";
        string expectedStatus = "status";
        string expectedStatusDate = "2019-12-27";
        string expectedUsptoUrl = "usptoUrl";

        Assert.Equal(expectedAttorney, model.Attorney);
        Assert.Equal(expectedFilingDate, model.FilingDate);
        Assert.NotNull(model.GoodsAndServices);
        Assert.Equal(expectedGoodsAndServices.Count, model.GoodsAndServices.Count);
        for (int i = 0; i < expectedGoodsAndServices.Count; i++)
        {
            Assert.Equal(expectedGoodsAndServices[i], model.GoodsAndServices[i]);
        }
        Assert.Equal(expectedImageUrl, model.ImageUrl);
        Assert.Equal(expectedMarkText, model.MarkText);
        Assert.Equal(expectedMarkType, model.MarkType);
        Assert.NotNull(model.NiceClasses);
        Assert.Equal(expectedNiceClasses.Count, model.NiceClasses.Count);
        for (int i = 0; i < expectedNiceClasses.Count; i++)
        {
            Assert.Equal(expectedNiceClasses[i], model.NiceClasses[i]);
        }
        Assert.Equal(expectedOwner, model.Owner);
        Assert.Equal(expectedRegistrationDate, model.RegistrationDate);
        Assert.Equal(expectedRegistrationNumber, model.RegistrationNumber);
        Assert.Equal(expectedSerialNumber, model.SerialNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusDate, model.StatusDate);
        Assert.Equal(expectedUsptoUrl, model.UsptoUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            NiceClasses = [0],
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
            Status = "status",
            StatusDate = "2019-12-27",
            UsptoUrl = "usptoUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TrademarkSearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            NiceClasses = [0],
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
            Status = "status",
            StatusDate = "2019-12-27",
            UsptoUrl = "usptoUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1TrademarkSearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttorney = "attorney";
        string expectedFilingDate = "2019-12-27";
        List<GoodsAndService> expectedGoodsAndServices =
        [
            new() { ClassNumber = "classNumber", Description = "description" },
        ];
        string expectedImageUrl = "imageUrl";
        string expectedMarkText = "markText";
        string expectedMarkType = "markType";
        List<long> expectedNiceClasses = [0];
        Owner expectedOwner = new()
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };
        string expectedRegistrationDate = "2019-12-27";
        string expectedRegistrationNumber = "registrationNumber";
        string expectedSerialNumber = "serialNumber";
        string expectedStatus = "status";
        string expectedStatusDate = "2019-12-27";
        string expectedUsptoUrl = "usptoUrl";

        Assert.Equal(expectedAttorney, deserialized.Attorney);
        Assert.Equal(expectedFilingDate, deserialized.FilingDate);
        Assert.NotNull(deserialized.GoodsAndServices);
        Assert.Equal(expectedGoodsAndServices.Count, deserialized.GoodsAndServices.Count);
        for (int i = 0; i < expectedGoodsAndServices.Count; i++)
        {
            Assert.Equal(expectedGoodsAndServices[i], deserialized.GoodsAndServices[i]);
        }
        Assert.Equal(expectedImageUrl, deserialized.ImageUrl);
        Assert.Equal(expectedMarkText, deserialized.MarkText);
        Assert.Equal(expectedMarkType, deserialized.MarkType);
        Assert.NotNull(deserialized.NiceClasses);
        Assert.Equal(expectedNiceClasses.Count, deserialized.NiceClasses.Count);
        for (int i = 0; i < expectedNiceClasses.Count; i++)
        {
            Assert.Equal(expectedNiceClasses[i], deserialized.NiceClasses[i]);
        }
        Assert.Equal(expectedOwner, deserialized.Owner);
        Assert.Equal(expectedRegistrationDate, deserialized.RegistrationDate);
        Assert.Equal(expectedRegistrationNumber, deserialized.RegistrationNumber);
        Assert.Equal(expectedSerialNumber, deserialized.SerialNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusDate, deserialized.StatusDate);
        Assert.Equal(expectedUsptoUrl, deserialized.UsptoUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            NiceClasses = [0],
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
            Status = "status",
            StatusDate = "2019-12-27",
            UsptoUrl = "usptoUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            Status = "status",
            StatusDate = "2019-12-27",
        };

        Assert.Null(model.GoodsAndServices);
        Assert.False(model.RawData.ContainsKey("goodsAndServices"));
        Assert.Null(model.NiceClasses);
        Assert.False(model.RawData.ContainsKey("niceClasses"));
        Assert.Null(model.SerialNumber);
        Assert.False(model.RawData.ContainsKey("serialNumber"));
        Assert.Null(model.UsptoUrl);
        Assert.False(model.RawData.ContainsKey("usptoUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            Status = "status",
            StatusDate = "2019-12-27",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            Status = "status",
            StatusDate = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            GoodsAndServices = null,
            NiceClasses = null,
            SerialNumber = null,
            UsptoUrl = null,
        };

        Assert.Null(model.GoodsAndServices);
        Assert.False(model.RawData.ContainsKey("goodsAndServices"));
        Assert.Null(model.NiceClasses);
        Assert.False(model.RawData.ContainsKey("niceClasses"));
        Assert.Null(model.SerialNumber);
        Assert.False(model.RawData.ContainsKey("serialNumber"));
        Assert.Null(model.UsptoUrl);
        Assert.False(model.RawData.ContainsKey("usptoUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            Status = "status",
            StatusDate = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            GoodsAndServices = null,
            NiceClasses = null,
            SerialNumber = null,
            UsptoUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            NiceClasses = [0],
            SerialNumber = "serialNumber",
            UsptoUrl = "usptoUrl",
        };

        Assert.Null(model.Attorney);
        Assert.False(model.RawData.ContainsKey("attorney"));
        Assert.Null(model.FilingDate);
        Assert.False(model.RawData.ContainsKey("filingDate"));
        Assert.Null(model.ImageUrl);
        Assert.False(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.MarkText);
        Assert.False(model.RawData.ContainsKey("markText"));
        Assert.Null(model.MarkType);
        Assert.False(model.RawData.ContainsKey("markType"));
        Assert.Null(model.Owner);
        Assert.False(model.RawData.ContainsKey("owner"));
        Assert.Null(model.RegistrationDate);
        Assert.False(model.RawData.ContainsKey("registrationDate"));
        Assert.Null(model.RegistrationNumber);
        Assert.False(model.RawData.ContainsKey("registrationNumber"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusDate);
        Assert.False(model.RawData.ContainsKey("statusDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            NiceClasses = [0],
            SerialNumber = "serialNumber",
            UsptoUrl = "usptoUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            NiceClasses = [0],
            SerialNumber = "serialNumber",
            UsptoUrl = "usptoUrl",

            Attorney = null,
            FilingDate = null,
            ImageUrl = null,
            MarkText = null,
            MarkType = null,
            Owner = null,
            RegistrationDate = null,
            RegistrationNumber = null,
            Status = null,
            StatusDate = null,
        };

        Assert.Null(model.Attorney);
        Assert.True(model.RawData.ContainsKey("attorney"));
        Assert.Null(model.FilingDate);
        Assert.True(model.RawData.ContainsKey("filingDate"));
        Assert.Null(model.ImageUrl);
        Assert.True(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.MarkText);
        Assert.True(model.RawData.ContainsKey("markText"));
        Assert.Null(model.MarkType);
        Assert.True(model.RawData.ContainsKey("markType"));
        Assert.Null(model.Owner);
        Assert.True(model.RawData.ContainsKey("owner"));
        Assert.Null(model.RegistrationDate);
        Assert.True(model.RawData.ContainsKey("registrationDate"));
        Assert.Null(model.RegistrationNumber);
        Assert.True(model.RawData.ContainsKey("registrationNumber"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusDate);
        Assert.True(model.RawData.ContainsKey("statusDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            NiceClasses = [0],
            SerialNumber = "serialNumber",
            UsptoUrl = "usptoUrl",

            Attorney = null,
            FilingDate = null,
            ImageUrl = null,
            MarkText = null,
            MarkType = null,
            Owner = null,
            RegistrationDate = null,
            RegistrationNumber = null,
            Status = null,
            StatusDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1TrademarkSearchResponse
        {
            Attorney = "attorney",
            FilingDate = "2019-12-27",
            GoodsAndServices = [new() { ClassNumber = "classNumber", Description = "description" }],
            ImageUrl = "imageUrl",
            MarkText = "markText",
            MarkType = "markType",
            NiceClasses = [0],
            Owner = new()
            {
                Address = "address",
                EntityType = "entityType",
                Name = "name",
            },
            RegistrationDate = "2019-12-27",
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
            Status = "status",
            StatusDate = "2019-12-27",
            UsptoUrl = "usptoUrl",
        };

        V1TrademarkSearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoodsAndServiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoodsAndService
        {
            ClassNumber = "classNumber",
            Description = "description",
        };

        string expectedClassNumber = "classNumber";
        string expectedDescription = "description";

        Assert.Equal(expectedClassNumber, model.ClassNumber);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoodsAndService
        {
            ClassNumber = "classNumber",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoodsAndService>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoodsAndService
        {
            ClassNumber = "classNumber",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoodsAndService>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClassNumber = "classNumber";
        string expectedDescription = "description";

        Assert.Equal(expectedClassNumber, deserialized.ClassNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoodsAndService
        {
            ClassNumber = "classNumber",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoodsAndService { };

        Assert.Null(model.ClassNumber);
        Assert.False(model.RawData.ContainsKey("classNumber"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoodsAndService { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GoodsAndService { ClassNumber = null, Description = null };

        Assert.Null(model.ClassNumber);
        Assert.True(model.RawData.ContainsKey("classNumber"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoodsAndService { ClassNumber = null, Description = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoodsAndService
        {
            ClassNumber = "classNumber",
            Description = "description",
        };

        GoodsAndService copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Owner
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };

        string expectedAddress = "address";
        string expectedEntityType = "entityType";
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Owner
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Owner>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Owner
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Owner>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAddress = "address";
        string expectedEntityType = "entityType";
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Owner
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Owner { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Owner { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Owner
        {
            Address = null,
            EntityType = null,
            Name = null,
        };

        Assert.Null(model.Address);
        Assert.True(model.RawData.ContainsKey("address"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Owner
        {
            Address = null,
            EntityType = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Owner
        {
            Address = "address",
            EntityType = "entityType",
            Name = "name",
        };

        Owner copied = new(model);

        Assert.Equal(model, copied);
    }
}
