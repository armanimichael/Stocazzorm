using Stocazzorm.Generator.Tests.TestingUtils;
using Stocazzorm.Generator.Tests.TestSourceCode;
using Xunit;

namespace Stocazzorm.Generator.Tests;

public class DataRecordMapperGeneratorTests
{
    [Fact(DisplayName = "Validate non-nullable types")]
    public void ValidateNonNullableTypes()
    {
        var generatedCode = DataRecordMapperGeneratorUtils.GenerateCode(NonNullableTypesSourceCode.SampleCode);

        Assert.Equal(
            NonNullableTypesSourceCode.ExpectedGeneratorCode,
            generatedCode,
            ignoreLineEndingDifferences: true,
            ignoreWhiteSpaceDifferences: true,
            ignoreAllWhiteSpace: true
        );
    }

    [Fact(DisplayName = "Validate nullable types")]
    public void ValidateNullableTypes()
    {
        var generatedCode = DataRecordMapperGeneratorUtils.GenerateCode(NullableTypesSourceCode.SampleCode);

        Assert.Equal(
            NullableTypesSourceCode.ExpectedGeneratorCode,
            generatedCode,
            ignoreLineEndingDifferences: true,
            ignoreWhiteSpaceDifferences: true,
            ignoreAllWhiteSpace: true
        );
    }
}