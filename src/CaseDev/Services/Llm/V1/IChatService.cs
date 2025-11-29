using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Services.Llm.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a completion for the provided prompt and parameters. Compatible with
    /// OpenAI's chat completions API. Supports 40+ models including GPT-4, Claude,
    /// Gemini, and CaseMark legal AI models. Includes streaming support, token counting,
    /// and usage tracking.
    /// </summary>
    Task<ChatCreateCompletionResponse> CreateCompletion(
        ChatCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    );
}
