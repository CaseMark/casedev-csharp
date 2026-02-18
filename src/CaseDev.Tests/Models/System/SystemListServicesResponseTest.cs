using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.System;

namespace CaseDev.Tests.Models.System;

public class SystemListServicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SystemListServicesResponse
        {
            Services =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Href = "href",
                    Icon = "icon",
                    Name = "name",
                    Order = 0,
                },
            ],
        };

        List<Service> expectedServices =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Href = "href",
                Icon = "icon",
                Name = "name",
                Order = 0,
            },
        ];

        Assert.Equal(expectedServices.Count, model.Services.Count);
        for (int i = 0; i < expectedServices.Count; i++)
        {
            Assert.Equal(expectedServices[i], model.Services[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SystemListServicesResponse
        {
            Services =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Href = "href",
                    Icon = "icon",
                    Name = "name",
                    Order = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemListServicesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SystemListServicesResponse
        {
            Services =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Href = "href",
                    Icon = "icon",
                    Name = "name",
                    Order = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemListServicesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Service> expectedServices =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Href = "href",
                Icon = "icon",
                Name = "name",
                Order = 0,
            },
        ];

        Assert.Equal(expectedServices.Count, deserialized.Services.Count);
        for (int i = 0; i < expectedServices.Count; i++)
        {
            Assert.Equal(expectedServices[i], deserialized.Services[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SystemListServicesResponse
        {
            Services =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Href = "href",
                    Icon = "icon",
                    Name = "name",
                    Order = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SystemListServicesResponse
        {
            Services =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Href = "href",
                    Icon = "icon",
                    Name = "name",
                    Order = 0,
                },
            ],
        };

        SystemListServicesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ServiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Service
        {
            ID = "id",
            Description = "description",
            Href = "href",
            Icon = "icon",
            Name = "name",
            Order = 0,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedHref = "href";
        string expectedIcon = "icon";
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedIcon, model.Icon);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrder, model.Order);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Service
        {
            ID = "id",
            Description = "description",
            Href = "href",
            Icon = "icon",
            Name = "name",
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Service>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Service
        {
            ID = "id",
            Description = "description",
            Href = "href",
            Icon = "icon",
            Name = "name",
            Order = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Service>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedHref = "href";
        string expectedIcon = "icon";
        string expectedName = "name";
        long expectedOrder = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedIcon, deserialized.Icon);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrder, deserialized.Order);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Service
        {
            ID = "id",
            Description = "description",
            Href = "href",
            Icon = "icon",
            Name = "name",
            Order = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Service
        {
            ID = "id",
            Description = "description",
            Href = "href",
            Icon = "icon",
            Name = "name",
            Order = 0,
        };

        Service copied = new(model);

        Assert.Equal(model, copied);
    }
}
