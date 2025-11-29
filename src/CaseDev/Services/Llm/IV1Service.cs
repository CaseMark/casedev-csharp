using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm.V1;
using CaseDev.Services.Llm.V1;

namespace CaseDev.Services.Llm;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IChatService Chat { get; }

    /// <summary>
    /// Create vector embeddings from text using OpenAI-compatible models. Perfect
    /// for semantic search, document similarity, and building RAG systems for legal documents.
    /// </summary>
    Task CreateEmbedding(
        V1CreateEmbeddingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of all available language models from 40+ providers including
    /// OpenAI, Anthropic, Google, and Case.dev's specialized legal models. Returns
    /// OpenAI-compatible model metadata with pricing information.
    ///
    /// <para>This endpoint is compatible with OpenAI's models API format, making
    /// it easy to integrate with existing applications.</para>
    /// </summary>
    Task ListModels(
        V1ListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
