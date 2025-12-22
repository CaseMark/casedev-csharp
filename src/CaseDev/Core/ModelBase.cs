using System.Text.Json;
using CaseDev.Exceptions;
using CaseDev.Models.Compute.V1.Environments;
using CaseDev.Models.Format.V1;
using CaseDev.Models.Format.V1.Templates;
using CaseDev.Models.Llm.V1;
using CaseDev.Models.Llm.V1.Chat;
using CaseDev.Models.Vault.Objects;
using CaseDev.Models.Voice.V1;
using Speak = CaseDev.Models.Voice.V1.Speak;
using Transcription = CaseDev.Models.Voice.Transcription;
using V1 = CaseDev.Models.Convert.V1;
using Vault = CaseDev.Models.Vault;

namespace CaseDev.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, V1::V1ProcessResponseStatus>(),
            new ApiEnumConverter<string, V1::Status>(),
            new ApiEnumConverter<string, OutputFormat>(),
            new ApiEnumConverter<string, InputFormat>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, EncodingFormat>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Status>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Type>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Engine>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.SearchType>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.Model>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.Type>(),
            new ApiEnumConverter<string, Vault::Status>(),
            new ApiEnumConverter<string, Vault::Method>(),
            new ApiEnumConverter<string, Operation>(),
            new ApiEnumConverter<string, Transcription::Status>(),
            new ApiEnumConverter<string, Transcription::BoostParam>(),
            new ApiEnumConverter<string, Transcription::TranscriptionCreateParamsFormat>(),
            new ApiEnumConverter<string, Sort>(),
            new ApiEnumConverter<string, SortDirection>(),
            new ApiEnumConverter<string, VoiceType>(),
            new ApiEnumConverter<string, Speak::ModelID>(),
            new ApiEnumConverter<string, Speak::OutputFormat>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Templates.V1.Status>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Templates.V1.OptionsFormat>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.Mode>(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1ExecuteResponseStatus
            >(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.TriggerType>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.Visibility>(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1UpdateParamsTriggerType
            >(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1UpdateParamsVisibility
            >(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1ListParamsVisibility
            >(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.Status>(),
        },
    };

    private protected static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
