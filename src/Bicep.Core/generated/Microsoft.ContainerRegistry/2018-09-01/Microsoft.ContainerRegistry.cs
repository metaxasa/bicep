// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using Bicep.Core;
using Bicep.Core.Resources;
using Bicep.Core.TypeSystem;
namespace Bicep.Resources.Types
{
    [ResourceTypeRegisterableAttribute]
    public class Microsoft_ContainerRegistry_2018_09_01
    {
        private const string ProviderNamespace = "Microsoft.ContainerRegistry";
        private const string ApiVersion = "2018-09-01";
        private static readonly ResourceTypeReference ResourceTypeReference_registries_tasks = new ResourceTypeReference(ProviderNamespace, new[]{"registries", "tasks"}, ApiVersion);
        private static Lazy<Microsoft_ContainerRegistry_2018_09_01> InstanceLazy = new Lazy<Microsoft_ContainerRegistry_2018_09_01>(() => new Microsoft_ContainerRegistry_2018_09_01());
        private Microsoft_ContainerRegistry_2018_09_01()
        {
            TaskProperties = new NamedObjectType("TaskProperties", new ITypeProperty[]{new TypeProperty("provisioningState", UnionType.Create(new StringLiteralType("'Creating'"), new StringLiteralType("'Updating'"), new StringLiteralType("'Deleting'"), new StringLiteralType("'Succeeded'"), new StringLiteralType("'Failed'"), new StringLiteralType("'Canceled'")), TypePropertyFlags.ReadOnly), new TypeProperty("creationDate", LanguageConstants.String, TypePropertyFlags.ReadOnly), new TypeProperty("status", UnionType.Create(new StringLiteralType("'Disabled'"), new StringLiteralType("'Enabled'")), TypePropertyFlags.None), new LazyTypeProperty("platform", () => PlatformProperties, TypePropertyFlags.Required), new LazyTypeProperty("agentConfiguration", () => AgentProperties, TypePropertyFlags.None), new TypeProperty("timeout", LanguageConstants.Int, TypePropertyFlags.None), new LazyTypeProperty("step", () => TaskStepProperties, TypePropertyFlags.Required), new LazyTypeProperty("trigger", () => TriggerProperties, TypePropertyFlags.None), new LazyTypeProperty("credentials", () => Credentials, TypePropertyFlags.None)}, null);
            PlatformProperties = new NamedObjectType("PlatformProperties", new ITypeProperty[]{new TypeProperty("os", UnionType.Create(new StringLiteralType("'Windows'"), new StringLiteralType("'Linux'")), TypePropertyFlags.Required), new TypeProperty("architecture", UnionType.Create(new StringLiteralType("'amd64'"), new StringLiteralType("'x86'"), new StringLiteralType("'arm'")), TypePropertyFlags.None), new TypeProperty("variant", UnionType.Create(new StringLiteralType("'v6'"), new StringLiteralType("'v7'"), new StringLiteralType("'v8'")), TypePropertyFlags.None)}, null);
            AgentProperties = new NamedObjectType("AgentProperties", new ITypeProperty[]{new TypeProperty("cpu", LanguageConstants.Int, TypePropertyFlags.None)}, null);
            TaskStepProperties = new DiscriminatedObjectType("TaskStepProperties", "type", new ITypeProperty[]{new LazyTypeProperty("TaskStepProperties", () => DockerBuildStep, TypePropertyFlags.None), new LazyTypeProperty("TaskStepProperties", () => FileTaskStep, TypePropertyFlags.None), new LazyTypeProperty("TaskStepProperties", () => EncodedTaskStep, TypePropertyFlags.None)});
            BaseImageDependency = new NamedObjectType("BaseImageDependency", new ITypeProperty[]{new TypeProperty("type", UnionType.Create(new StringLiteralType("'BuildTime'"), new StringLiteralType("'RunTime'")), TypePropertyFlags.None), new TypeProperty("registry", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("repository", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("tag", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("digest", LanguageConstants.String, TypePropertyFlags.None)}, null);
            DockerBuildStep = new NamedObjectType("DockerBuildStep", new ITypeProperty[]{new TypeProperty("imageNames", new TypedArrayType(LanguageConstants.String), TypePropertyFlags.None), new TypeProperty("isPushEnabled", LanguageConstants.Bool, TypePropertyFlags.None), new TypeProperty("noCache", LanguageConstants.Bool, TypePropertyFlags.None), new TypeProperty("dockerFilePath", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("target", LanguageConstants.String, TypePropertyFlags.None), new LazyTypeProperty("arguments", () => new TypedArrayType(Argument), TypePropertyFlags.None), new TypeProperty("type", new StringLiteralType("'Docker'"), TypePropertyFlags.Required), new LazyTypeProperty("baseImageDependencies", () => new TypedArrayType(BaseImageDependency), TypePropertyFlags.ReadOnly), new TypeProperty("contextPath", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("contextAccessToken", LanguageConstants.String, TypePropertyFlags.None)}, null);
            Argument = new NamedObjectType("Argument", new ITypeProperty[]{new TypeProperty("name", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("value", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("isSecret", LanguageConstants.Bool, TypePropertyFlags.None)}, null);
            FileTaskStep = new NamedObjectType("FileTaskStep", new ITypeProperty[]{new TypeProperty("taskFilePath", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("valuesFilePath", LanguageConstants.String, TypePropertyFlags.None), new LazyTypeProperty("values", () => new TypedArrayType(SetValue), TypePropertyFlags.None), new TypeProperty("type", new StringLiteralType("'FileTask'"), TypePropertyFlags.Required), new LazyTypeProperty("baseImageDependencies", () => new TypedArrayType(BaseImageDependency), TypePropertyFlags.ReadOnly), new TypeProperty("contextPath", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("contextAccessToken", LanguageConstants.String, TypePropertyFlags.None)}, null);
            SetValue = new NamedObjectType("SetValue", new ITypeProperty[]{new TypeProperty("name", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("value", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("isSecret", LanguageConstants.Bool, TypePropertyFlags.None)}, null);
            EncodedTaskStep = new NamedObjectType("EncodedTaskStep", new ITypeProperty[]{new TypeProperty("encodedTaskContent", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("encodedValuesContent", LanguageConstants.String, TypePropertyFlags.None), new LazyTypeProperty("values", () => new TypedArrayType(SetValue), TypePropertyFlags.None), new TypeProperty("type", new StringLiteralType("'EncodedTask'"), TypePropertyFlags.Required), new LazyTypeProperty("baseImageDependencies", () => new TypedArrayType(BaseImageDependency), TypePropertyFlags.ReadOnly), new TypeProperty("contextPath", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("contextAccessToken", LanguageConstants.String, TypePropertyFlags.None)}, null);
            TriggerProperties = new NamedObjectType("TriggerProperties", new ITypeProperty[]{new LazyTypeProperty("sourceTriggers", () => new TypedArrayType(SourceTrigger), TypePropertyFlags.None), new LazyTypeProperty("baseImageTrigger", () => BaseImageTrigger, TypePropertyFlags.None)}, null);
            SourceTrigger = new NamedObjectType("SourceTrigger", new ITypeProperty[]{new LazyTypeProperty("sourceRepository", () => SourceProperties, TypePropertyFlags.Required), new TypeProperty("sourceTriggerEvents", new TypedArrayType(UnionType.Create(new StringLiteralType("'commit'"), new StringLiteralType("'pullrequest'"))), TypePropertyFlags.Required), new TypeProperty("status", UnionType.Create(new StringLiteralType("'Disabled'"), new StringLiteralType("'Enabled'")), TypePropertyFlags.None), new TypeProperty("name", LanguageConstants.String, TypePropertyFlags.Required)}, null);
            SourceProperties = new NamedObjectType("SourceProperties", new ITypeProperty[]{new TypeProperty("sourceControlType", UnionType.Create(new StringLiteralType("'Github'"), new StringLiteralType("'VisualStudioTeamService'")), TypePropertyFlags.Required), new TypeProperty("repositoryUrl", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("branch", LanguageConstants.String, TypePropertyFlags.None), new LazyTypeProperty("sourceControlAuthProperties", () => AuthInfo, TypePropertyFlags.None)}, null);
            AuthInfo = new NamedObjectType("AuthInfo", new ITypeProperty[]{new TypeProperty("tokenType", UnionType.Create(new StringLiteralType("'PAT'"), new StringLiteralType("'OAuth'")), TypePropertyFlags.Required), new TypeProperty("token", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("refreshToken", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("scope", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("expiresIn", LanguageConstants.Int, TypePropertyFlags.None)}, null);
            BaseImageTrigger = new NamedObjectType("BaseImageTrigger", new ITypeProperty[]{new TypeProperty("baseImageTriggerType", UnionType.Create(new StringLiteralType("'All'"), new StringLiteralType("'Runtime'")), TypePropertyFlags.Required), new TypeProperty("status", UnionType.Create(new StringLiteralType("'Disabled'"), new StringLiteralType("'Enabled'")), TypePropertyFlags.None), new TypeProperty("name", LanguageConstants.String, TypePropertyFlags.Required)}, null);
            Credentials = new NamedObjectType("Credentials", new ITypeProperty[]{new LazyTypeProperty("sourceRegistry", () => SourceRegistryCredentials, TypePropertyFlags.None), new TypeProperty("customRegistries", new NamedObjectType("customRegistries", new ITypeProperty[]{}, new LazyTypeProperty("additionalProperties", () => CustomRegistryCredentials, TypePropertyFlags.None)), TypePropertyFlags.None)}, null);
            SourceRegistryCredentials = new NamedObjectType("SourceRegistryCredentials", new ITypeProperty[]{new TypeProperty("loginMode", UnionType.Create(new StringLiteralType("'None'"), new StringLiteralType("'Default'")), TypePropertyFlags.None)}, null);
            CustomRegistryCredentials = new NamedObjectType("CustomRegistryCredentials", new ITypeProperty[]{new LazyTypeProperty("userName", () => SecretObject, TypePropertyFlags.None), new LazyTypeProperty("password", () => SecretObject, TypePropertyFlags.None)}, null);
            SecretObject = new NamedObjectType("SecretObject", new ITypeProperty[]{new TypeProperty("value", LanguageConstants.String, TypePropertyFlags.None), new TypeProperty("type", new StringLiteralType("'Opaque'"), TypePropertyFlags.None)}, null);
            ResourceType_registries_tasks = new ResourceType("Microsoft.ContainerRegistry/registries/tasks", new ITypeProperty[]{new TypeProperty("id", LanguageConstants.String, TypePropertyFlags.SkipInlining | TypePropertyFlags.ReadOnly), new TypeProperty("name", LanguageConstants.String, TypePropertyFlags.SkipInlining | TypePropertyFlags.Required), new TypeProperty("type", new StringLiteralType("'Microsoft.ContainerRegistry/registries/tasks'"), TypePropertyFlags.SkipInlining | TypePropertyFlags.ReadOnly), new TypeProperty("location", LanguageConstants.String, TypePropertyFlags.Required), new TypeProperty("tags", new NamedObjectType("tags", new ITypeProperty[]{}, new TypeProperty("additionalProperties", LanguageConstants.String, TypePropertyFlags.None)), TypePropertyFlags.None), new LazyTypeProperty("properties", () => TaskProperties, TypePropertyFlags.Required), new TypeProperty("apiVersion", new StringLiteralType("'2018-09-01'"), TypePropertyFlags.SkipInlining | TypePropertyFlags.ReadOnly), new TypeProperty("dependsOn", new TypedArrayType(LanguageConstants.ResourceRef), TypePropertyFlags.WriteOnly)}, null, ResourceTypeReference_registries_tasks);
        }
        public static void Register(IResourceTypeRegistrar registrar)
        {
            registrar.RegisterType(ResourceTypeReference_registries_tasks, () => InstanceLazy.Value.ResourceType_registries_tasks);
        }
        private readonly ResourceType ResourceType_registries_tasks;
        private readonly TypeSymbol TaskProperties;
        private readonly TypeSymbol PlatformProperties;
        private readonly TypeSymbol AgentProperties;
        private readonly TypeSymbol TaskStepProperties;
        private readonly TypeSymbol BaseImageDependency;
        private readonly TypeSymbol DockerBuildStep;
        private readonly TypeSymbol Argument;
        private readonly TypeSymbol FileTaskStep;
        private readonly TypeSymbol SetValue;
        private readonly TypeSymbol EncodedTaskStep;
        private readonly TypeSymbol TriggerProperties;
        private readonly TypeSymbol SourceTrigger;
        private readonly TypeSymbol SourceProperties;
        private readonly TypeSymbol AuthInfo;
        private readonly TypeSymbol BaseImageTrigger;
        private readonly TypeSymbol Credentials;
        private readonly TypeSymbol SourceRegistryCredentials;
        private readonly TypeSymbol CustomRegistryCredentials;
        private readonly TypeSymbol SecretObject;
    }
}