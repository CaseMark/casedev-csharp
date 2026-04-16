using System.Text.Json;
using Casedev.Exceptions;
using Casedev.Models.Agent.V1.Run;
using Casedev.Models.Applications.V1.Deployments;
using Casedev.Models.Format.V1;
using Casedev.Models.Llm.V1;
using Casedev.Models.Matters.V1.Log;
using Casedev.Models.Matters.V1.MatterParties;
using Casedev.Models.Matters.V1.Shares;
using Casedev.Models.Matters.V1.Types;
using Casedev.Models.Privilege.V1;
using Casedev.Models.Skills;
using Casedev.Models.Translate.V1;
using Casedev.Models.Usage.V1;
using Casedev.Models.Voice.V1;
using BoostList = Casedev.Models.Voice.BoostList;
using Chat = Casedev.Models.Agent.V1.Chat;
using Environments = Casedev.Models.Compute.V1.Environments;
using Execute = Casedev.Models.Agent.V1.Execute;
using Graphrag = Casedev.Models.Vault.Graphrag;
using Instances = Casedev.Models.Compute.V1.Instances;
using MattersV1 = Casedev.Models.Matters.V1;
using Memory = Casedev.Models.Vault.Memory;
using MemoryV1 = Casedev.Models.Memory.V1;
using Objects = Casedev.Models.Vault.Objects;
using OcrV1 = Casedev.Models.Ocr.V1;
using Parties = Casedev.Models.Matters.V1.Parties;
using Projects = Casedev.Models.Applications.V1.Projects;
using Run = Casedev.Models.Agent.V2.Run;
using SearchV1 = Casedev.Models.Search.V1;
using Speak = Casedev.Models.Voice.V1.Speak;
using SuperdocV1 = Casedev.Models.Superdoc.V1;
using Templates = Casedev.Models.Format.V1.Templates;
using Transcription = Casedev.Models.Voice.Transcription;
using V1 = Casedev.Models.Legal.V1;
using V1Chat = Casedev.Models.Llm.V1.Chat;
using V1Projects = Casedev.Models.Database.V1.Projects;
using V2Chat = Casedev.Models.Agent.V2.Chat;
using V2Execute = Casedev.Models.Agent.V2.Execute;
using Vault = Casedev.Models.Vault;
using WorkItems = Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Core;

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
            new ApiEnumConverter<string, RunCreateResponseStatus>(),
            new ApiEnumConverter<string, RunListResponseRunStatus>(),
            new ApiEnumConverter<string, RunCancelResponseStatus>(),
            new ApiEnumConverter<string, RunExecResponseStatus>(),
            new ApiEnumConverter<string, Provider>(),
            new ApiEnumConverter<string, RuntimeState>(),
            new ApiEnumConverter<string, RunGetDetailsResponseStatus>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Kind>(),
            new ApiEnumConverter<string, RunGetStatusResponseStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Execute::Status>(),
            new ApiEnumConverter<string, Chat::Type>(),
            new ApiEnumConverter<string, Chat::ChatSendMessageParamsPartType>(),
            new ApiEnumConverter<string, Run::Status>(),
            new ApiEnumConverter<string, Run::Provider>(),
            new ApiEnumConverter<string, Run::RuntimeState>(),
            new ApiEnumConverter<string, Run::RunExecResponseStatus>(),
            new ApiEnumConverter<string, Run::RunGetStatusResponseStatus>(),
            new ApiEnumConverter<string, V2Execute::Provider>(),
            new ApiEnumConverter<string, V2Execute::RuntimeState>(),
            new ApiEnumConverter<string, V2Execute::Status>(),
            new ApiEnumConverter<string, V2Chat::Provider>(),
            new ApiEnumConverter<string, V2Chat::Type>(),
            new ApiEnumConverter<string, V2Chat::ChatSendMessageParamsPartType>(),
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
            new ApiEnumConverter<string, Environments::Status>(),
            new ApiEnumConverter<string, Instances::Status>(),
            new ApiEnumConverter<string, V1Projects::Status>(),
            new ApiEnumConverter<string, V1Projects::Type>(),
            new ApiEnumConverter<string, V1Projects::ProjectRetrieveResponseStatus>(),
            new ApiEnumConverter<string, V1Projects::ProjectLinkedDeploymentType>(),
            new ApiEnumConverter<string, V1Projects::ProjectStatus>(),
            new ApiEnumConverter<string, V1Projects::Region>(),
            new ApiEnumConverter<string, OutputFormat>(),
            new ApiEnumConverter<string, InputFormat>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, V1::Currency>(),
            new ApiEnumConverter<string, V1::V1DocketResponseType>(),
            new ApiEnumConverter<string, V1::Status>(),
            new ApiEnumConverter<string, V1::Level>(),
            new ApiEnumConverter<string, V1::V1SecFilingResponseType>(),
            new ApiEnumConverter<string, V1::V1VerifyResponseCitationStatus>(),
            new ApiEnumConverter<string, V1::VerificationSource>(),
            new ApiEnumConverter<string, V1::Type>(),
            new ApiEnumConverter<string, V1::Unit>(),
            new ApiEnumConverter<string, V1::OutputType>(),
            new ApiEnumConverter<string, V1::ApplicationType>(),
            new ApiEnumConverter<string, V1::SortBy>(),
            new ApiEnumConverter<string, V1::SortOrder>(),
            new ApiEnumConverter<string, V1::V1SecFilingParamsType>(),
            new ApiEnumConverter<string, MattersV1::Status>(),
            new ApiEnumConverter<string, MattersV1::V1UpdateParamsStatus>(),
            new ApiEnumConverter<string, Parties::Type>(),
            new ApiEnumConverter<string, Parties::PartyListParamsType>(),
            new ApiEnumConverter<string, OrchestrationMode>(),
            new ApiEnumConverter<string, TypeUpdateParamsOrchestrationMode>(),
            new ApiEnumConverter<string, LogExportParamsFormat>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, Permission>(),
            new ApiEnumConverter<string, WorkItems::Priority>(),
            new ApiEnumConverter<string, WorkItems::Type>(),
            new ApiEnumConverter<string, WorkItems::WorkItemUpdateParamsPriority>(),
            new ApiEnumConverter<string, WorkItems::Status>(),
            new ApiEnumConverter<string, WorkItems::WorkItemUpdateParamsType>(),
            new ApiEnumConverter<string, WorkItems::Decision>(),
            new ApiEnumConverter<string, EncodingFormat>(),
            new ApiEnumConverter<string, V1Chat::Role>(),
            new ApiEnumConverter<string, MemoryV1::Event>(),
            new ApiEnumConverter<string, MemoryV1::Role>(),
            new ApiEnumConverter<string, OcrV1::Status>(),
            new ApiEnumConverter<string, OcrV1::V1ProcessResponseStatus>(),
            new ApiEnumConverter<string, OcrV1::IncludeText>(),
            new ApiEnumConverter<string, OcrV1::Type>(),
            new ApiEnumConverter<string, OcrV1::Engine>(),
            new ApiEnumConverter<string, OcrV1::TablesFormat>(),
            new ApiEnumConverter<string, Recommendation>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, Jurisdiction>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, ResultSource>(),
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
            new ApiEnumConverter<string, Granularity>(),
            new ApiEnumConverter<string, Vault::Status>(),
            new ApiEnumConverter<string, Vault::VaultIngestResponseStatus>(),
            new ApiEnumConverter<bool, Vault::Success>(),
            new ApiEnumConverter<bool, Vault::VaultConfirmUploadFailureSuccess>(),
            new ApiEnumConverter<string, Vault::Method>(),
            new ApiEnumConverter<string, Graphrag::Status>(),
            new ApiEnumConverter<string, Objects::Status>(),
            new ApiEnumConverter<string, Objects::Force>(),
            new ApiEnumConverter<string, Objects::Operation>(),
            new ApiEnumConverter<string, Memory::Type>(),
            new ApiEnumConverter<string, BoostList::BoostParam>(),
            new ApiEnumConverter<string, BoostList::Source>(),
            new ApiEnumConverter<string, BoostList::BoostListGenerateResponseItemBoostParam>(),
            new ApiEnumConverter<string, BoostList::BoostListGenerateResponseSource>(),
            new ApiEnumConverter<string, BoostList::Category>(),
            new ApiEnumConverter<string, BoostList::BoostListGenerateParamsCategory>(),
            new ApiEnumConverter<string, Transcription::Status>(),
            new ApiEnumConverter<string, Transcription::TranscriptionRetrieveResponseStatus>(),
            new ApiEnumConverter<string, Transcription::BoostParam>(),
            new ApiEnumConverter<string, Transcription::TranscriptionCreateParamsFormat>(),
            new ApiEnumConverter<string, Transcription::IncludeText>(),
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
