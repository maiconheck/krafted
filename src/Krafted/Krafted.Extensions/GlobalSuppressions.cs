// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:System.Net.Http.HttpResponseMessageExtension.EnsureContentType(System.Net.Http.HttpResponseMessage,System.String)~System.Net.Http.HttpResponseMessage")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:System.Net.Http.HttpResponseMessageExtension.DeserializeAsync``1(System.Net.Http.HttpResponseMessage,System.Boolean)~System.Threading.Tasks.Task{``0}")]
[assembly: SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Not applicable", Scope = "member", Target = "~M:System.StringExtension.ToSlug(System.String,System.Int32)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:System.Collections.Generic.ListExtension.Move``1(System.Collections.Generic.IList{``0},System.Int32,System.Int32)")]
[assembly: SuppressMessage("Major Code Smell", "S2589:Boolean expressions should not be gratuitous", Justification = "This expression will be true when attribute is not defined but the fallback is true.", Scope = "member", Target = "~M:System.EnumExtension.GetDisplayName(System.Enum,System.Boolean)~System.String")]
[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "Not applicable", Scope = "member", Target = "~M:System.EnumExtension.GetDisplayName(System.Enum,System.Boolean)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.Against", Scope = "member", Target = "~M:System.EnumExtension.GetDisplayName(System.Enum,System.Boolean)~System.String")]
