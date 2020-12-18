// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Internal type that doesn't expose public API", Scope = "type", Target = "~T:Krafted.DesignPatterns.Specifications.OrSpecification`1")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Internal type that doesn't expose public API", Scope = "type", Target = "~T:Krafted.DesignPatterns.Specifications.NotSpecification`1")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Internal type that doesn't expose public API", Scope = "type", Target = "~T:Krafted.DesignPatterns.Specifications.IdentitySpecification`1")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Internal type that doesn't expose public API", Scope = "type", Target = "~T:Krafted.DesignPatterns.Specifications.AndSpecification`1")]
[assembly: SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.IdentitySpecification`1.ToExpression~System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the explicit type improves readability", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.OrSpecification`1.ToExpression~System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the explicit type improves readability", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.NotSpecification`1.ToExpression~System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the explicit type improves readability", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.AndSpecification`1.ToExpression~System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the explicit type improves readability", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.Specification`1.IsSatisfiedBy(`0)~System.Boolean")]
[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "This comment is a header documentation")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Not Applicable", Scope = "member", Target = "~F:Krafted.DesignPatterns.Specifications.Specification`1.All")]
