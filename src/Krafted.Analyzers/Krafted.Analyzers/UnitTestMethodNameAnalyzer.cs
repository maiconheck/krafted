using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Krafted.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class UnitTestMethodNameAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = DiagnosticDescriptorFactory.Create(
            id: Id,
            title: "Test method should be named with the MethodName_StateUnderTest_ExpectedBehavior Osherove's naming convention",
            messageFormat: "Rename the {0} method to the MethodName_StateUnderTest_ExpectedBehavior Osherove's naming convention",
            category: DiagnosticCategory.Naming,
            description: "Examples: IsAdult_AgeLessThan18_False, ValidateEmail_InvalidEmail_ThrowsException, ValidateEmail_ValidEmail_DoesNotThrowsException",
            helpLinkUri: "https://stackoverflow.com/a/1594049/5219344");

        public static string Id => "KT1000";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;

            // Find only the methods that do not compliance to the naming convention to unit tests.
            if (IsTestMethod(methodSymbol) && !MatchesNamingConvention(methodSymbol.Name))
            {
                // For all such symbols, produce a diagnostic.
                var diagnostic = Diagnostic.Create(_rule, methodSymbol.Locations[0], methodSymbol.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static bool IsTestMethod(IMethodSymbol methodSymbol)
        {
            var testMethodAttributeNames = new string[] { "FactAttribute", "TheoryAttribute", "TestAttribute" };

            var attributes = methodSymbol.GetAttributes().Where(a => testMethodAttributeNames.Contains(a.AttributeClass.Name));
            return attributes.Any();
        }

        private static bool MatchesNamingConvention(string methodName)
        {
            const string pattern = @"^([A-Z]{1}[a-z]{1,}[A-Za-z]+)_([A-Z]{1}[a-z]{1,}[A-Za-z]+)_([A-Z]{1}[a-z]{1,}[A-Za-z]+)+$";
            var regEx = new Regex(pattern, RegexOptions.Compiled, TimeSpan.FromSeconds(5.0));

            return regEx.IsMatch(methodName);
        }
    }
}
