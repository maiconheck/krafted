// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "This comment is a header documentation")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the type is not obvious", Scope = "member", Target = "~M:Krafted.Specification`1.IsSatisfiedBy(`0)~System.Boolean")]
[assembly: SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.GuardAgainst.AnyNull(System.Linq.Expressions.Expression{System.Func{System.Object}}[])")]
[assembly: SuppressMessage("Design", "RCS1225:Make class sealed.", Justification = "Not applicable", Scope = "type", Target = "~T:Krafted.Guards.Guard")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1609:Property documentation should have value", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:Property summary documentation should match accessors", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
