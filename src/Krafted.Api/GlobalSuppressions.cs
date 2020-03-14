// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name must match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "type", Target = "~T:Krafted.Api.Startup`1")]
[assembly: SuppressMessage("General", "RCS1181:Replace comment with documentation comment.", Justification = "Auto-generated comments", Scope = "member", Target = "~M:Krafted.Api.Startup`1.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
[assembly: SuppressMessage("General", "RCS1181:Replace comment with documentation comment.", Justification = "Auto-generated comments", Scope = "member", Target = "~M:Krafted.Api.Startup`1.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IHostingEnvironment)")]