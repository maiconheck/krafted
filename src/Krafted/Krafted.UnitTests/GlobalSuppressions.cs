// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "Documentation")]
[assembly: SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.UnitTests.Xunit.UseCultureAttribute.#ctor(System.String)")]
[assembly: SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.UnitTests.Xunit.UseCultureAttribute.#ctor(System.String,System.String)")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "Is an acronym, is not hungarian notation", Scope = "member", Target = "~M:Krafted.UnitTests.Xunit.UseCultureAttribute.#ctor(System.String,System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.UnitTests.TestDouble.HttpMessageHandlerMock.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
