// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => response)", Scope = "member", Target = "~M:Krafted.Net.Http.HttpResponseMessageExtension.DeserializeAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => response)", Scope = "member", Target = "~M:Krafted.Net.Http.HttpResponseMessageExtension.DeserializeDeleteAsync(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{Krafted.Test.Result.ResponseCommandResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => response)", Scope = "member", Target = "~M:Krafted.Net.Http.HttpResponseMessageExtension.EnsureContentType(System.Net.Http.HttpResponseMessage,System.String)~System.Net.Http.HttpResponseMessage")]