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
}
