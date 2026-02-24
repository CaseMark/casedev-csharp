using System;
using Casedev;

namespace Casedev.Tests;

public class TestBase
{
    protected ICasedevClient client;

    public TestBase()
    {
        client = new CasedevClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
