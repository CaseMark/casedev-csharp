using System.Text.Json;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Deployments;
using CaseDev.Models.Compute.V1.Environments;
using CaseDev.Models.Format.V1;
using CaseDev.Models.Format.V1.Templates;
using CaseDev.Models.Llm.V1;
using CaseDev.Models.Llm.V1.Chat;
using CaseDev.Models.Privilege.V1;
using CaseDev.Models.Translate.V1;
using CaseDev.Models.Voice.V1;
using Graphrag = CaseDev.Models.Vault.Graphrag;
using Instances = CaseDev.Models.Compute.V1.Instances;
using MemoryV1 = CaseDev.Models.Memory.V1;
using Objects = CaseDev.Models.Vault.Objects;
using OcrV1 = CaseDev.Models.Ocr.V1;
using Projects = CaseDev.Models.Applications.V1.Projects;
using SearchV1 = CaseDev.Models.Search.V1;
using Speak = CaseDev.Models.Voice.V1.Speak;
using SuperdocV1 = CaseDev.Models.Superdoc.V1;
using Transcription = CaseDev.Models.Voice.Transcription;
using V1 = CaseDev.Models.Legal.V1;
using V1Projects = CaseDev.Models.Database.V1.Projects;
using Vault = CaseDev.Models.Vault;

namespace CaseDev.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
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
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Target>(),
            new ApiEnumConverter<string, DeploymentListParamsTarget>(),
            new ApiEnumConverter<string, Projects::Target>(),
            new ApiEnumConverter<string, Projects::Type>(),
            new ApiEnumConverter<
                string,
                Projects::ProjectCreateDeploymentParamsEnvironmentVariableTarget
            >(),
            new ApiEnumConverter<
                string,
                Projects::ProjectCreateDeploymentParamsEnvironmentVariableType
            >(),
            new ApiEnumConverter<string, Projects::ProjectCreateEnvParamsTarget>(),
            new ApiEnumConverter<string, Projects::ProjectCreateEnvParamsType>(),
            new ApiEnumConverter<string, Projects::ProjectListDeploymentsParamsTarget>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Instances::Status>(),
            new ApiEnumConverter<string, V1Projects::Status>(),
            new ApiEnumConverter<string, V1Projects::Type>(),
            new ApiEnumConverter<string, V1Projects::ProjectRetrieveResponseStatus>(),
            new ApiEnumConverter<string, V1Projects::ProjectLinkedDeploymentType>(),
            new ApiEnumConverter<string, V1Projects::ProjectStatus>(),
            new ApiEnumConverter<string, V1Projects::Region>(),
            new ApiEnumConverter<string, OutputFormat>(),
            new ApiEnumConverter<string, InputFormat>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, V1::Level>(),
            new ApiEnumConverter<string, V1::Status>(),
            new ApiEnumConverter<string, V1::VerificationSource>(),
            new ApiEnumConverter<string, EncodingFormat>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, MemoryV1::Event>(),
            new ApiEnumConverter<string, MemoryV1::Role>(),
            new ApiEnumConverter<string, OcrV1::Status>(),
            new ApiEnumConverter<string, OcrV1::V1ProcessResponseStatus>(),
            new ApiEnumConverter<string, OcrV1::Type>(),
            new ApiEnumConverter<string, OcrV1::Engine>(),
            new ApiEnumConverter<string, OcrV1::TablesFormat>(),
            new ApiEnumConverter<string, Recommendation>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, Jurisdiction>(),
            new ApiEnumConverter<string, SearchV1::V1RetrieveResearchResponseModel>(),
            new ApiEnumConverter<string, SearchV1::Status>(),
            new ApiEnumConverter<string, SearchV1::SearchType>(),
            new ApiEnumConverter<string, SearchV1::Model>(),
            new ApiEnumConverter<string, SearchV1::Type>(),
            new ApiEnumConverter<string, SuperdocV1::Type>(),
            new ApiEnumConverter<string, SuperdocV1::OutputFormat>(),
            new ApiEnumConverter<string, SuperdocV1::From>(),
            new ApiEnumConverter<string, SuperdocV1::To>(),
            new ApiEnumConverter<string, Model>(),
            new ApiEnumConverter<string, V1TranslateParamsFormat>(),
            new ApiEnumConverter<string, V1TranslateParamsModel>(),
            new ApiEnumConverter<string, Vault::Status>(),
            new ApiEnumConverter<string, Vault::VaultIngestResponseStatus>(),
            new ApiEnumConverter<bool, Vault::Success>(),
            new ApiEnumConverter<bool, Vault::UnionMember1Success>(),
            new ApiEnumConverter<string, Vault::Method>(),
            new ApiEnumConverter<string, Graphrag::Status>(),
            new ApiEnumConverter<string, Objects::Status>(),
            new ApiEnumConverter<string, Objects::Force>(),
            new ApiEnumConverter<string, Objects::Operation>(),
            new ApiEnumConverter<string, Transcription::Status>(),
            new ApiEnumConverter<string, Transcription::TranscriptionRetrieveResponseStatus>(),
            new ApiEnumConverter<string, Transcription::BoostParam>(),
            new ApiEnumConverter<string, Transcription::TranscriptionCreateParamsFormat>(),
            new ApiEnumConverter<string, Sort>(),
            new ApiEnumConverter<string, SortDirection>(),
            new ApiEnumConverter<string, VoiceType>(),
            new ApiEnumConverter<string, Speak::ModelID>(),
            new ApiEnumConverter<string, Speak::OutputFormat>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
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
