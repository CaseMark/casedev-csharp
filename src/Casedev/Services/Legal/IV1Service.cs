using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Services.Legal;

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
    /// Search for legal sources including cases, statutes, and regulations from
    /// authoritative legal databases. Returns ranked candidates. Always verify with
    /// legal.verify() before citing.
    /// </summary>
    Task<V1FindResponse> Find(
        V1FindParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Parses legal citations from text and returns structured Bluebook components
    /// (case name, reporter, volume, page, year, court). Accepts either a single
    /// citation or a full text block.
    /// </summary>
    Task<V1GetCitationsResponse> GetCitations(
        V1GetCitationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Extract all legal citations and references from a document URL. Returns structured
    /// citation data including case citations, statute references, and regulatory citations.
    /// </summary>
    Task<V1GetCitationsFromUrlResponse> GetCitationsFromUrl(
        V1GetCitationsFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the full text content of a legal document. Use after verifying the
    /// source with legal.verify(). Returns complete text with optional highlights
    /// and AI summary.
    /// </summary>
    Task<V1GetFullTextResponse> GetFullText(
        V1GetFullTextParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search for a jurisdiction by name. Returns matching jurisdictions with their
    /// IDs for use in legal.find() and other legal research endpoints.
    /// </summary>
    Task<V1ListJurisdictionsResponse> ListJurisdictions(
        V1ListJurisdictionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search the USPTO Open Data Portal for US patent applications and granted
    /// patents. Supports free-text queries, field-specific search, filters by assignee/inventor/status/type,
    /// date ranges, and pagination. Covers applications filed on or after January
    /// 1, 2001. Data is refreshed daily.
    /// </summary>
    Task<V1PatentSearchResponse> PatentSearch(
        V1PatentSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform comprehensive legal research with multiple query variations. Uses
    /// advanced deep search to find relevant sources across different phrasings of
    /// the legal issue.
    /// </summary>
    Task<V1ResearchResponse> Research(
        V1ResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Find cases and documents similar to a given legal source. Useful for finding
    /// citing cases, related precedents, or similar statutes.
    /// </summary>
    Task<V1SimilarResponse> Similar(
        V1SimilarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Look up trademark status and details from the USPTO Trademark Status & Document
    /// Retrieval (TSDR) system. Supports lookup by serial number or registration
    /// number. Returns mark text, status, owner, goods/services, Nice classification,
    /// filing/registration dates, and more.
    /// </summary>
    Task<V1TrademarkSearchResponse> TrademarkSearch(
        V1TrademarkSearchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates legal citations against authoritative case law sources (CourtListener
    /// database of ~10M cases). Returns verification status and case metadata for
    /// each citation found in the input text. Accepts either a single citation or
    /// a full text block containing multiple citations.
    /// </summary>
    Task<V1VerifyResponse> Verify(
        V1VerifyParams parameters,
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
    /// Returns a raw HTTP response for `post /legal/v1/find`, but is otherwise the
    /// same as <see cref="IV1Service.Find(V1FindParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1FindResponse>> Find(
        V1FindParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/citations`, but is otherwise the
    /// same as <see cref="IV1Service.GetCitations(V1GetCitationsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1GetCitationsResponse>> GetCitations(
        V1GetCitationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/citations-from-url`, but is otherwise the
    /// same as <see cref="IV1Service.GetCitationsFromUrl(V1GetCitationsFromUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1GetCitationsFromUrlResponse>> GetCitationsFromUrl(
        V1GetCitationsFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/full-text`, but is otherwise the
    /// same as <see cref="IV1Service.GetFullText(V1GetFullTextParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1GetFullTextResponse>> GetFullText(
        V1GetFullTextParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/jurisdictions`, but is otherwise the
    /// same as <see cref="IV1Service.ListJurisdictions(V1ListJurisdictionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListJurisdictionsResponse>> ListJurisdictions(
        V1ListJurisdictionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/patent-search`, but is otherwise the
    /// same as <see cref="IV1Service.PatentSearch(V1PatentSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1PatentSearchResponse>> PatentSearch(
        V1PatentSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/research`, but is otherwise the
    /// same as <see cref="IV1Service.Research(V1ResearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ResearchResponse>> Research(
        V1ResearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/similar`, but is otherwise the
    /// same as <see cref="IV1Service.Similar(V1SimilarParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1SimilarResponse>> Similar(
        V1SimilarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/trademark-search`, but is otherwise the
    /// same as <see cref="IV1Service.TrademarkSearch(V1TrademarkSearchParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1TrademarkSearchResponse>> TrademarkSearch(
        V1TrademarkSearchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /legal/v1/verify`, but is otherwise the
    /// same as <see cref="IV1Service.Verify(V1VerifyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1VerifyResponse>> Verify(
        V1VerifyParams parameters,
        CancellationToken cancellationToken = default
    );
}
