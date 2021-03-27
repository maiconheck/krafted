// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Addition(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Subtraction(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Implicit(Krafted.ValueObjects.Money)~System.Decimal")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.ToString~System.String")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "type", Target = "~T:Krafted.ValueObjects.ValueObject`1")]
