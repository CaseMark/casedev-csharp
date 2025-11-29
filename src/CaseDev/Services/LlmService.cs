using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm;
using CaseDev.Services.Llm;

namespace CaseDev.Services;

/// <inheritdoc />
public sealed class LlmService : ILlmService
{
    /// <inheritdoc/>
    public ILlmService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LlmService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public LlmService(ICasedevClient client)
    {
        _client = client;
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }

    /// <inheritdoc/>
    public async Task GetConfig(
        LlmGetConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LlmGetConfigParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
