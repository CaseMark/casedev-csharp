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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

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
    Task<V1RetrieveResearchResponse> RetrieveResearch(
        V1RetrieveResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveResearch(V1RetrieveResearchParams, CancellationToken)"/>
    Task<V1RetrieveResearchResponse> RetrieveResearch(
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

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /search/v1/answer`, but is otherwise the
    /// same as <see cref="IV1Service.Answer(V1AnswerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1AnswerResponse>> Answer(
        V1AnswerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /search/v1/contents`, but is otherwise the
    /// same as <see cref="IV1Service.Contents(V1ContentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ContentsResponse>> Contents(
        V1ContentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /search/v1/research`, but is otherwise the
    /// same as <see cref="IV1Service.Research(V1ResearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ResearchResponse>> Research(
        V1ResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /search/v1/research/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.RetrieveResearch(V1RetrieveResearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1RetrieveResearchResponse>> RetrieveResearch(
        V1RetrieveResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveResearch(V1RetrieveResearchParams, CancellationToken)"/>
    Task<HttpResponse<V1RetrieveResearchResponse>> RetrieveResearch(
        string id,
        V1RetrieveResearchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /search/v1/search`, but is otherwise the
    /// same as <see cref="IV1Service.Search(V1SearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1SearchResponse>> Search(
        V1SearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /search/v1/similar`, but is otherwise the
    /// same as <see cref="IV1Service.Similar(V1SimilarParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1SimilarResponse>> Similar(
        V1SimilarParams parameters,
        CancellationToken cancellationToken = default
    );
}
