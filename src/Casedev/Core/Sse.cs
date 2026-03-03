using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Casedev.Exceptions;

namespace Casedev.Core;

static class Sse
{
    internal static async IAsyncEnumerable<T> Enumerate<T>(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);

        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            T? message;
            try
            {
                message = JsonSerializer.Deserialize<T>(item.Data, ModelBase.SerializerOptions);
            }
            catch (JsonException e)
            {
                throw new CasedevInvalidDataException(
                    $"Message must be of type {typeof(T).FullName}",
                    e
                );
            }
            yield return message ?? throw new CasedevInvalidDataException("Message cannot be null");
        }
    }
}
