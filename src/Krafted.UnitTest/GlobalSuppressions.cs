// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "Necessary for the extension method", Scope = "member", Target = "~M:Krafted.UnitTest.Data.Connection.SqlServer.AssertExtension.DoesNotThrow(Xunit.Assert,System.Action)")]
[assembly: SuppressMessage("Redundancy", "RCS1175:Unused this parameter.", Justification = "Necessary for the extension method", Scope = "member", Target = "~M:Krafted.UnitTest.Data.Connection.SqlServer.AssertExtension.DoesNotThrow(Xunit.Assert,System.Action)")]
[assembly: SuppressMessage("Usage", "CA1806:Do not ignore method results", Justification = "Just to test", Scope = "member", Target = "~M:Krafted.UnitTest.Data.Connection.SqlServer.SqlServerConnectionProviderTest.NewInstance_FilledConnectionString_ArgumentExceptionShouldNotBeThrow(System.String)")]
[assembly: SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "Just to test", Scope = "member", Target = "~M:Krafted.UnitTest.Data.Repositories.Dapper.RepositoryTest.Transaction_Call_ShouldBeReceived")]
[assembly: SuppressMessage("Usage", "CA1806:Do not ignore method results", Justification = "Just to test", Scope = "member", Target = "~M:Krafted.UnitTest.Data.Connection.SqlServer.SqlServerConnectionProviderTest.NewInstance_NotFilledConnectionString_ExceptionShouldBeThrow(System.String)")]
[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "Just to test", Scope = "type", Target = "~T:Krafted.UnitTest.Api.ProviderStateApiFactoryTest")]
[assembly: SuppressMessage("Usage", "CC0022:Should dispose object", Justification = "Just to test", Scope = "member", Target = "~T:Krafted.UnitTest.Krafted.Net.Http.HttpResponseMessageExtensionTest")]
