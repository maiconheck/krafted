// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "This comment is a header documentation")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1609:Property documentation should have value", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:Property summary documentation should match accessors", Justification = "Not applicable", Scope = "member", Target = "~P:Krafted.Guards.Guard.Against")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.Guards.Br.Validator.ValidateCnpj(System.String)~System.Boolean")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.Guards.Br.Validator.ValidateCpf(System.String)~System.Boolean")]
