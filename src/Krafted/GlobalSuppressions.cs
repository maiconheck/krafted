// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "CC0037:Remove commented code.", Justification = "This commented code is a documentation.")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "The concern of this class is generates SQL, and in this case the suffix 'pk' is useful, because represents the primary key from the table.", Scope = "member", Target = "~M:Krafted.Dapper.EntityExtension.ToParams(Krafted.Entity,System.String)~Dapper.DynamicParameters")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "The concern of this class is generates SQL, and in this case the suffix 'pk' is useful, because represents the primary key from the table.", Scope = "member", Target = "~M:Krafted.Dapper.EntityExtension.ToParam(Krafted.Entity,System.String)~Dapper.DynamicParameters")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "The concern of this class is generates SQL, and in this case the suffix 'pk' is useful, because represents the primary key from the table.", Scope = "member", Target = "~M:Krafted.Dapper.EntityExtension.GetColumnNames(Krafted.Entity,System.String)~System.Collections.Generic.IList{System.String}")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "In this case the type is not obvious", Scope = "member", Target = "~M:Krafted.Specification`1.IsSatisfiedBy(`0)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable", Scope = "member", Target = "~M:Krafted.EntityExtension.SetNewId(Krafted.Entity)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "aggregate.ThrowIfNull(nameof(aggregate))", Scope = "member", Target = "~M:Krafted.NotifiableExtension.Notifications(Flunt.Notifications.Notifiable)~System.Collections.Generic.List{Flunt.Notifications.Notification}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "aggregate.ThrowIfNull(nameof(aggregate))", Scope = "member", Target = "~M:Krafted.NotifiableExtension.Invalid(Flunt.Notifications.Notifiable)~System.Boolean")]