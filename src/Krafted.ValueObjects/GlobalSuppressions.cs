// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This project no target other languages that no support operator overloading.", Scope = "type", Target = "~T:Krafted.ValueObjects.Email")]
[assembly: SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This project no target other languages that no support operator overloading.", Scope = "type", Target = "~T:Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => value)", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Implicit(Krafted.ValueObjects.Money)~System.Decimal")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => value)", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Addition(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => value)", Scope = "member", Target = "~M:Krafted.ValueObjects.Money.op_Subtraction(Krafted.ValueObjects.Money,System.Decimal)~Krafted.ValueObjects.Money")]