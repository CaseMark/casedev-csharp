using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;

namespace Casedev.Tests;

public class SseTest : TestBase
{
    public static TheoryData<string, string[]> Data() =>
        new()
        {
            // event and data
            { "event: event\n" + "data: {\"foo\":true}\n\n", ["{\"foo\": true}"] },
            // data missing event
            { "data: {\"foo\":true}\n\n", ["{\"foo\": true}"] },
            // event missing data
            { "event: event\n" + "\n", [] },
            // multiple events and data
            {
                "event: event\n"
                    + "data: {\"foo\":true}\n\n"
                    + "event: event\n"
                    + "data: {\"bar\": false}\n\n",
                ["{\"foo\": true}", "{\"bar\": false}"]
            },
            // multiple events missing data
            { "event: event\n" + "\n" + "event: event\n" + "\n", [] },
            // multiple data missing event
            {
                "data: { \"foo\":true}\n\ndata: {\"bar\": false }\n\n",
                ["{ \"foo\": true }", "{ \"bar\": false }"]
            },
            // json-escaped double newline
            {
                "event: event\n" + "data: {\ndata: \"foo\":\ndata: true }\n\n\n",
                ["{ \"foo\":\ntrue }"]
            },
            // multiple data lines
            {
                "event: event\n" + "data: { \ndata: \"foo\":\ndata: true }\n\n\n",
                ["{ \"foo\":\ntrue }"]
            },
            // special newline character
            {
                "event: event\n"
                    + "data: {\"content\": \" culpa\"}\n\n"
                    + "event: event\n"
                    + "data: {\"content\": \" \u2028\"}\n\n"
                    + "event: event\n"
                    + "data: {\"content\": \"foo\"}\n\n",
                [
                    "{\"content\": \" culpa\"}",
                    "{\"content\": \" \u2028\"}",
                    "{\"content\": \"foo\"}",
                ]
            },
            // multi-byte character
            {
                "event: event\n"
                    + "data: {\"content\": "
                    + "\"\u0438\u0437\u0432\u0435\u0441\u0442\u043d\u0438\"}\n\n}",
                ["{\"content\":\"известни\"}"]
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Sse_Works(
        string events,
        string[] expectedMessageStrings,
        CancellationToken cancellationToken = default
    )
    {
        var expectedMessages = new List<JsonElement>();
        foreach (var message in expectedMessageStrings)
        {
            expectedMessages.Add(JsonSerializer.Deserialize<JsonElement>(message));
        }

        var resp = new HttpResponseMessage() { Content = new StringContent(events) };

        var actualMessages = new List<JsonElement>();
        await foreach (var message in Sse.Enumerate<JsonElement>(resp, cancellationToken))
        {
            actualMessages.Add(message);
        }

        Assert.Equal(expectedMessages.Count, actualMessages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedMessages[i], actualMessages[i]));
        }
    }
}
