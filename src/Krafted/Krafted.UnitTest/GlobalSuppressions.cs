// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "In this case the goal is to test the behavior with a null parameter", Scope = "member", Target = "~M:Krafted.UnitTest.Krafted.Guards.GuardNullTest.GuardAgainstNullOrEmpty_NullOrEmpty_ThrowsException(System.String)")]
[assembly: SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "In this case the goal is to test the behavior with a null parameter", Scope = "member", Target = "~M:Krafted.UnitTest.Krafted.Guards.GuardNullTest.GuardAgainstNullOrWhiteSpace_NullOrWhiteSpace_ThrowsException(System.String)")]
