using System.Text.Json;
using CaseDev.Models.Actions.V1;

namespace CaseDev.Tests.Models.Actions.V1;

public class DefinitionTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        Definition value = new("string");
        value.Validate();
    }

    [Fact]
    public void JsonElementValidation_Works()
    {
        Definition value = new(JsonSerializer.Deserialize<JsonElement>("{}"));
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        Definition value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Definition>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementSerializationRoundtrip_Works()
    {
        Definition value = new(JsonSerializer.Deserialize<JsonElement>("{}"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Definition>(json);

        Assert.Equal(value, deserialized);
    }
}
