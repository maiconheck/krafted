using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;

namespace Krafted.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(KraftedAnalyzersCodeFixProvider)), Shared]
    public class KraftedAnalyzersCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(UnitTestMethodNameAnalyzer.Id);

        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            // TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the type declaration identified by the diagnostic.
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

            const string codeFixTitle = "Rename to the MethodName_StateUnderTest_ExpectedBehavior Osherove's naming convention";

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: codeFixTitle,
                    createChangedSolution: c => MakeSnakeCaseAsync(context.Document, declaration, c),
                    equivalenceKey: nameof(codeFixTitle)),
                diagnostic);
        }

        private async Task<Solution> MakeSnakeCaseAsync(Document document, TypeDeclarationSyntax declaration, CancellationToken cancellationToken)
        {
            // Compute new MethodName_StateUnderTest_ExpectedBehavior name.
            var identifierToken = declaration.Identifier;
            var newName = identifierToken.Text.PascalCaseToSnakeCase();

            // Get the symbol representing the type to be renamed.
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
            var typeSymbol = semanticModel.GetDeclaredSymbol(declaration, cancellationToken);

            // Produce a new solution that has all references to that type renamed, including the declaration.
            var originalSolution = document.Project.Solution;
            var optionSet = originalSolution.Workspace.Options;
            var newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, typeSymbol, newName, optionSet, cancellationToken).ConfigureAwait(false);

            // Return the new solution with the now-uppercase type name.
            return newSolution;
        }
    }
}
