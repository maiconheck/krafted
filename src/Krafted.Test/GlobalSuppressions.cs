// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Readability", "RCS1008:Use explicit type instead of 'var' (when the type is not obvious).", Justification = "The type is obvious", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.DeserializeResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Readability", "RCS1008:Use explicit type instead of 'var' (when the type is not obvious).", Justification = "The type is obvious", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.DeserializeDeleteResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "response.ThrowIfNull(nameof(response))", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.DeserializeResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.#ctor(Krafted.Api.ProviderStateApiFactory{`0},System.String,System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "response.ThrowIfNull(nameof(response))", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.DeserializeDeleteResponseAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "response.ThrowIfNull(nameof(response))", Scope = "member", Target = "~M:Krafted.Test.IntegrationTest`1.EnsureCorrectContentType(System.Net.Http.HttpResponseMessage)~System.Net.Http.HttpResponseMessage")]