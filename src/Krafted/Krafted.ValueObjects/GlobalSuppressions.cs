// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("General", "RCS1181:Convert comment to documentation comment.", Justification = "In this case, it's just a comment, and not a documentation comment.", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.#ctor")]
[assembly: SuppressMessage("General", "RCS1181:Convert comment to documentation comment.", Justification = "In this case, it's just a comment, and not a documentation comment.", Scope = "member", Target = "~M:Krafted.ValueObjects.Pt.Nif.#ctor")]
[assembly: SuppressMessage("General", "RCS1181:Convert comment to documentation comment.", Justification = "In this case, it's just a comment, and not a documentation comment.", Scope = "member", Target = "~M:Krafted.ValueObjects.Email.#ctor")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Addition(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Subtraction(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Implicit(Krafted.ValueObjects.Money)~System.Decimal")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.ToString~System.String")]
[assembly: SuppressMessage("Usage", "RCS1206:Use conditional access instead of conditional expression.", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.ValueObjects.ValueObject.GetHashCode~System.Int32")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "type", Target = "~T:Krafted.ValueObjects.ValueObject`1")]
[assembly: SuppressMessage("Usage", "RCS1206:Use conditional access instead of conditional expression.", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.ValueObjects.ValueObject`1.GetHashCode~System.Int32")]
