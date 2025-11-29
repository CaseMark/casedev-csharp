using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Search.V1;

namespace CaseDev.Services.Search;

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

    /// <summary>
    /// Generate comprehensive answers to questions using web search results. Supports
    /// two modes: native provider answers or custom LLM-powered answers using Case.dev's
    /// AI gateway. Perfect for legal research, fact-checking, and gathering supporting
    /// evidence for cases.
    /// </summary>
    Task<V1AnswerResponse> Answer(
        V1AnswerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Scrapes and extracts text content from web pages, PDFs, and documents. Useful
    /// for legal research, evidence collection, and document analysis. Supports live
    /// crawling, subpage extraction, and content summarization.
    /// </summary>
    Task<V1ContentsResponse> Contents(
        V1ContentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Performs deep research by conducting multi-step analysis, gathering information
    /// from multiple sources, and providing comprehensive insights. Ideal for legal
    /// research, case analysis, and due diligence investigations.
    /// </summary>
    Task<V1ResearchResponse> Research(
        V1ResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the status and results of a deep research task by ID. Supports both
    /// standard JSON responses and streaming for real-time updates as the research
    /// progresses. Research tasks analyze topics comprehensively using web search
    /// and AI synthesis.
    /// </summary>
    Task RetrieveResearch(
        V1RetrieveResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveResearch(V1RetrieveResearchParams, CancellationToken)"/>
    Task RetrieveResearch(
        string id,
        V1RetrieveResearchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes intelligent web search queries with advanced filtering and customization
    /// options. Ideal for legal research, case law discovery, and gathering supporting
    /// documentation for litigation or compliance matters.
    /// </summary>
    Task<V1SearchResponse> Search(
        V1SearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Find web pages and documents similar to a given URL. Useful for legal research
    /// to discover related case law, statutes, or legal commentary that shares similar
    /// themes or content structure.
    /// </summary>
    Task<V1SimilarResponse> Similar(
        V1SimilarParams parameters,
        CancellationToken cancellationToken = default
    );
}
