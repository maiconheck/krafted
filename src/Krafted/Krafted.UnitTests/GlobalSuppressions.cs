// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Redundancy", "RCS1175:Unused this parameter.", Justification = "Needed for extension method", Scope = "member", Target = "~M:Krafted.XUnitExtension.DoesNotThrows(Xunit.Assert,System.Action)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "GuardAgainst", Scope = "member", Target = "~M:Krafted.UnitTest.IntegrationTest`1.#ctor(Krafted.Api.ProviderStateApiFactory{`0},System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "GuardAgainst", Scope = "member", Target = "~M:Krafted.UnitTest.IntegrationTest`1.DeserializeResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.UnitTest.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "GuardAgainst", Scope = "member", Target = "~M:Krafted.UnitTest.IntegrationTest`1.DeserializeDeleteResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.UnitTest.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Style", "RCS1196:Call extension method as instance method.", Justification = "GuardAgainst", Scope = "member", Target = "~M:Krafted.UnitTest.IntegrationTest`1.#ctor(Krafted.Api.ProviderStateApiFactory{`0},System.String)")]
[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "Documentation")]
[assembly: SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.UnitTest.Xunit.UseCultureAttribute.#ctor(System.String)")]
[assembly: SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.UnitTest.Xunit.UseCultureAttribute.#ctor(System.String,System.String)")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "Is an acronym, is not hungarian notation", Scope = "member", Target = "~M:Krafted.UnitTest.Xunit.UseCultureAttribute.#ctor(System.String,System.String)")]
