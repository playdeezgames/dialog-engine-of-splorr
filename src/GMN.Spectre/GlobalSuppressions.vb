' This file is used by Code Analysis to maintain SuppressMessage
' attributes that are applied to this project.
' Project-level suppressions either have no target or are given
' a specific target and scoped to a namespace, type, member, etc.

Imports System.Diagnostics.CodeAnalysis

<Assembly: SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance", Justification:="Read only dictionaries like this are small lookup tables and should not suffer from performance problems.", Scope:="member", Target:="~F:GMN.Spectre.Program.moodColors")>
