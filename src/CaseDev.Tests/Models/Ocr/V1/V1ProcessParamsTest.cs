using CaseDev.Models.Ocr.V1;

namespace CaseDev.Tests.Models.Ocr.V1;

public class FeaturesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        bool expectedForms = false;
        bool expectedLayout = true;
        bool expectedTables = true;
        bool expectedText = true;

        Assert.Equal(expectedForms, model.Forms);
        Assert.Equal(expectedLayout, model.Layout);
        Assert.Equal(expectedTables, model.Tables);
        Assert.Equal(expectedText, model.Text);
    }
}
