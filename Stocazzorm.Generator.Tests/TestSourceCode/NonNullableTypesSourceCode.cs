namespace Stocazzorm.Generator.Tests.TestSourceCode;

public static class NonNullableTypesSourceCode
{
    public const string SampleCode =
        //lang=csharp
        """
        using System;

        namespace TestNamespace

        [Stocazzorm.DataRecordMapperAttribute]
        public sealed partial class Sample
        {
            public byte A { get; set; }
            public short B { get; set; }
            public int C { get; set; }
            public long D { get; set; }
            public float E { get; set; }
            public double F { get; set; }
            public decimal G { get; set; }
            public string H { get; set; }
            public bool I { get; set; }
            public Guid J { get; set; }
            public char K { get; set; }
            public DateTime L { get; set; }
        }
        """;

    public const string ExpectedGeneratorCode =
        //lang=csharp
        """
        using global::Stocazzorm;
        namespace TestNamespace
        {
            partial class Sample : IDataRecordMapper<global::TestNamespace.Sample>
            {
                public static global::TestNamespace.Sample Map(global::System.Data.IDataRecord dataRecord) =>
                    new()
                    {
                        // 12 members
                        A = dataRecord.GetByte("A"),
                        B = dataRecord.GetInt16("B"),
                        C = dataRecord.GetInt32("C"),
                        D = dataRecord.GetInt64("D"),
                        E = dataRecord.GetFloat("E"),
                        F = dataRecord.GetDouble("F"),
                        G = dataRecord.GetDecimal("G"),
                        H = dataRecord.GetString("H"),
                        I = dataRecord.GetBoolean("I"),
                        J = dataRecord.GetGuid("J"),
                        K = dataRecord.GetChar("K"),
                        L = dataRecord.GetDateTime("L"),
                    };
            }
        }
        
        """;
}