# Casedev C# API Library

The Casedev C# SDK provides convenient access to the [Casedev REST API](https://docs.case.dev) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.case.dev](https://docs.case.dev).

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Casedev):

```bash
dotnet add package Casedev
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Casedev;
using Casedev.Models.Llm.V1.Chat;

CasedevClient client = new();

ChatCreateCompletionParams parameters = new()
{
    Messages =
    [
        new()
        {
            Role = Role.User,
            Content = "Hello!",
        },
    ],
};

var response = await client.Llm.V1.Chat.CreateCompletion(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Casedev;

// Configured using the CASEDEV_API_KEY and CASEDEV_BASE_URL environment variables
CasedevClient client = new();
```

Or manually:

```csharp
using Casedev;

CasedevClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable | Required | Default value            |
| --------- | -------------------- | -------- | ------------------------ |
| `ApiKey`  | `CASEDEV_API_KEY`    | true     | -                        |
| `BaseUrl` | `CASEDEV_BASE_URL`   | true     | `"https://api.case.dev"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var vault = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Vault.Create(parameters);

Console.WriteLine(vault);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Casedev API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Llm.V1.Chat.CreateCompletion` should be called with an instance of `ChatCreateCompletionParams`, and it will return an instance of `Task<ChatCreateCompletionResponse>`.

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using Casedev.Models.Format.V1;

V1CreateDocumentParams parameters = new()
{
    Content = "content",
    OutputFormat = OutputFormat.Pdf,
};

var response = await client.Format.V1.CreateDocument(parameters);

Console.WriteLine(response);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Format.V1.CreateDocument(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Vault.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Casedev.Models.Vault;

var response = await client.WithRawResponse.Vault.Create(parameters);
VaultCreateResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `CasedevApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `CasedevBadRequestException`           |
| 401    | `CasedevUnauthorizedException`         |
| 403    | `CasedevForbiddenException`            |
| 404    | `CasedevNotFoundException`             |
| 422    | `CasedevUnprocessableEntityException`  |
| 429    | `CasedevRateLimitException`            |
| 5xx    | `Casedev5xxException`                  |
| others | `CasedevUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Casedev4xxException`.

false

- `CasedevIOException`: I/O networking errors.

- `CasedevInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `CasedevException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Casedev;

CasedevClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var vault = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Vault.Create(parameters);

Console.WriteLine(vault);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Casedev;

CasedevClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var vault = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Vault.Create(parameters);

Console.WriteLine(vault);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Casedev;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

CasedevClient client = new() { HttpClient = httpClient };
```

### Environments

The SDK sends requests to the production environment by default. To send requests to a different environment, configure the client like so:

```csharp
using Casedev;
using Casedev.Core;

CasedevClient client = new() { BaseUrl = EnvironmentUrl.Local };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `CasedevInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var response = client.Llm.V1.Chat.CreateCompletion(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Casedev;

CasedevClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Llm.V1.Chat.CreateCompletion(parameters);

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/CaseMark/casedev-csharp/issues) with questions, bugs, or suggestions.
