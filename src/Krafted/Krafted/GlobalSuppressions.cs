// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "This comment is a header documentation")]
[assembly: SuppressMessage("Design", "RCS1225:Make class sealed.", Justification = "Not applicable", Scope = "type", Target = "~T:Krafted.Guards.Guard")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1609:Property documentation should have value", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:Property summary documentation should match accessors", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
[assembly: SuppressMessage("Usage", "RCS1221:Use pattern matching instead of combination of 'as' operator and null check.", Justification = "Not Applicable", Scope = "member", Target = "~M:Krafted.DataAnnotations.NotEmptyCollectionAttribute.IsValid(System.Object)~System.Boolean")]
[assembly: SuppressMessage("Redundancy", "RCS1175:Unused this parameter.", Justification = "Needed for extension method", Scope = "member", Target = "~M:System.EnumExtension.GetName``1(System.Enum,System.Object)~System.String")]
