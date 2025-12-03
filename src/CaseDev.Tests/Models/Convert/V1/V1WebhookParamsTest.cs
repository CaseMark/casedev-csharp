using System.Text.Json;
using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        double expectedDurationSeconds = 0;
        long expectedFileSizeBytes = 0;
        string expectedStoredFilename = "stored_filename";

        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedFileSizeBytes, model.FileSizeBytes);
        Assert.Equal(expectedStoredFilename, model.StoredFilename);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);
        Assert.NotNull(deserialized);

        double expectedDurationSeconds = 0;
        long expectedFileSizeBytes = 0;
        string expectedStoredFilename = "stored_filename";

        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedFileSizeBytes, deserialized.FileSizeBytes);
        Assert.Equal(expectedStoredFilename, deserialized.StoredFilename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            DurationSeconds = 0,
            FileSizeBytes = 0,
            StoredFilename = "stored_filename",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { };

        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.FileSizeBytes);
        Assert.False(model.RawData.ContainsKey("file_size_bytes"));
        Assert.Null(model.StoredFilename);
        Assert.False(model.RawData.ContainsKey("stored_filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            DurationSeconds = null,
            FileSizeBytes = null,
            StoredFilename = null,
        };

        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.FileSizeBytes);
        Assert.False(model.RawData.ContainsKey("file_size_bytes"));
        Assert.Null(model.StoredFilename);
        Assert.False(model.RawData.ContainsKey("stored_filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            DurationSeconds = null,
            FileSizeBytes = null,
            StoredFilename = null,
        };

        model.Validate();
    }
}
