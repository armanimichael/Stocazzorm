using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Stocazzorm.Generator.Tests.TestingUtils;

public static class DataRecordMapperGeneratorUtils
{
    public static string GenerateCode(string sampleCode)
    {
        var driver = CSharpGeneratorDriver.Create(new DataRecordMapperGenerator());

        var compilation = CSharpCompilation.Create(
            nameof(DataRecordMapperGeneratorTests),
            [CSharpSyntaxTree.ParseText(sampleCode)],
            [
                // To support 'System.Attribute' inheritance, add reference to 'System.Private.CoreLib'
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                // and to 'System.Runtime'
                MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
                // and to the Attribute class
                MetadataReference.CreateFromFile(typeof(DataRecordMapperAttribute).Assembly.Location)
            ]
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();

        var generatedFileSyntax = runResult.GeneratedTrees.Single(
            tree => tree.FilePath.EndsWith("DataRecordMapperPartialTypes.g.cs")
        );
        var generatedCode = generatedFileSyntax.GetText().ToString();

        return generatedCode;
    }
}