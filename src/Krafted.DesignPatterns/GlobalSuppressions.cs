// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name must match first type name", Justification = "This is a common way to name files that correspond to a generic type. The number after ` correspond to the quantity of generic arguments.", Scope = "NamespaceAndDescendants", Target = "Krafted.DesignPatterns.Factories")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "CA1716: Rename virtual/interface member", Justification = "NewSomething is the name commonly used for the creation method in FactoryMethod. In this case FactoryMethod is generic and New can be any type .So in this context, New is a good name", Scope = "NamespaceAndDescendants", Target = "Krafted.DesignPatterns.Factories")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "This type is obvious", Scope = "member", Target = "~M:Krafted.DesignPatterns.Specifications.Specification`1.IsSatisfiedBy(`0)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => aggregate)", Scope = "member", Target = "~M:Krafted.NotifiableExtension.Notifications(Flunt.Notifications.Notifiable)~System.Collections.Generic.List{Flunt.Notifications.Notification}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => aggregate)", Scope = "member", Target = "~M:Krafted.NotifiableExtension.Invalid(Flunt.Notifications.Notifiable)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => aggregate)", Scope = "member", Target = "~M:Krafted.DesignPatterns.Notifications.NotifiableExtension.Invalid(Flunt.Notifications.Notifiable)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "ExceptionHelper.ThrowIfNull(() => aggregate)", Scope = "member", Target = "~M:Krafted.DesignPatterns.Notifications.NotifiableExtension.Notifications(Flunt.Notifications.Notifiable)~System.Collections.Generic.List{Flunt.Notifications.Notification}")]