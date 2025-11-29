using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Services.Vault;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGraphragService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGraphragService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve GraphRAG (Graph Retrieval-Augmented Generation) statistics for a
    /// specific vault. This includes metrics about the knowledge graph structure,
    /// entity relationships, and processing status that enable advanced semantic
    /// search and AI-powered document analysis.
    /// </summary>
    Task GetStats(GraphragGetStatsParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetStats(GraphragGetStatsParams, CancellationToken)"/>
    Task GetStats(
        string id,
        GraphragGetStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initialize a GraphRAG workspace for a vault to enable advanced knowledge graph
    /// and retrieval-augmented generation capabilities. This creates the necessary
    /// infrastructure for semantic document analysis and graph-based querying within
    /// the vault.
    /// </summary>
    Task Init(GraphragInitParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Init(GraphragInitParams, CancellationToken)"/>
    Task Init(
        string id,
        GraphragInitParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
