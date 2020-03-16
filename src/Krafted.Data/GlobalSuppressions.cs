// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "The intent here is to reference the author")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name must match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "type", Target = "~T:Krafted.Data.SqlBuilder.SqlBuilderFactory`1")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name must match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "type", Target = "~T:Krafted.Data.Sql.SqlBuilderFactory`1")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1127:Generic type constraints must be on their own line", Justification = "Not applicable to expression bodied methods.", Scope = "member", Target = "~M:Krafted.Data.Sql.SqlBuilderFactory2.NewSqlBuilder``1(System.Data.IDbConnection)~Krafted.Data.Sql.ISqlBuilder")]
[assembly: SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "This query is automatically generated", Scope = "member", Target = "~M:Krafted.UnitTest.BultinSqlBuilder`1.GetCommandBuilder(System.Data.StatementType)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => factory, () => connection)", Scope = "member", Target = "~M:Krafted.Data.Sql.SqlBuilderFactory.NewSqlBuilder``1(Krafted.Data.Sql.ISqlBuilderFactory,System.Data.IDbConnection)~Krafted.Data.Sql.ISqlBuilder")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "factory.ThrowIfNull(nameof(factory))", Scope = "member", Target = "~M:Krafted.Data.Connection.ConnectionFactory.NewConnection(Krafted.Data.Connection.IConnectionFactory,System.String)~System.Data.IDbConnection")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.Data.EntityExtension.SetNewId(Krafted.Entity)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.Data.EntityExtension.SetNewId(Krafted.Data.Entity)")]