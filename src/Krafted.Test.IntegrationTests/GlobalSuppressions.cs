// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfAnyNull(() => factory)", Scope = "member", Target = "~M:Krafted.Test.IntegrationTests.IntegrationTest`1.#ctor(Krafted.Test.IntegrationTests.ProviderStateApiFactory{`0},System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => response)", Scope = "member", Target = "~M:Krafted.Test.IntegrationTests.IntegrationTest`1.DeserializeResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.UnitTest.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfAnyNull(() => response)", Scope = "member", Target = "~M:Krafted.Test.IntegrationTests.IntegrationTest`1.DeserializeDeleteResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.UnitTest.Result.ResponseCommandResult}")]