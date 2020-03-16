// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "This parameter is necessary for the extension method.", Scope = "member", Target = "~M:Krafted.IntegrationTest.Migration.KraftedDataBase.UseMigration(Microsoft.AspNetCore.Builder.IApplicationBuilder,System.String)")]
[assembly: SuppressMessage("Redundancy", "RCS1175:Unused this parameter.", Justification = "Needed for extension method", Scope = "member", Target = "~M:Krafted.IntegrationTest.Migration.KraftedDataBase.UseMigration(Microsoft.AspNetCore.Builder.IApplicationBuilder,System.String)")]
[assembly: SuppressMessage("Usage", "CA1806:Do not ignore method results", Justification = "Just to test", Scope = "member", Target = "~M:Krafted.IntegrationTest.Krafted.Data.Connection.SqlServer.SqlServerConnectionProviderTest.NewInstance_FilledConnectionString_DoesNotThrowsException(System.String)")]
[assembly: SuppressMessage("Design", "CC0091:Use static method", Justification = "Startup class", Scope = "type", Target = "~T:Krafted.IntegrationTest.Startup")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Startup class", Scope = "type", Target = "~T:Krafted.IntegrationTest.Startup")]
[assembly: SuppressMessage("Design", "CC0091:Use static method", Justification = "Startup class", Scope = "type", Target = "~T:Krafted.IntegrationTest.InfrastructureStartup")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Startup class", Scope = "type", Target = "~T:Krafted.IntegrationTest.InfrastructureStartup")]