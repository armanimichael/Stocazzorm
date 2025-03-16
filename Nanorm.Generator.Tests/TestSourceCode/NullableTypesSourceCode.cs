namespace Nanorm.Generator.Tests.TestSourceCode;

public static class NullableTypesSourceCode
{
    public const string SampleCode =
        //lang=csharp
        """
        using System;

        namespace TestNamespace

        [Nanorm.DataRecordMapperAttribute]
        public sealed partial class Sample
        {
            public byte? A { get; set; }
            public short? B { get; set; }
            public int? C { get; set; }
            public long? D { get; set; }
            public float? E { get; set; }
            public double? F { get; set; }
            public decimal? G { get; set; }
            public string? H { get; set; }
            public bool? I { get; set; }
            public Guid? J { get; set; }
            public char? K { get; set; }
            public DateTime? L { get; set; }
        }
        """;

    public const string ExpectedGeneratorCode =
        //lang=csharp
        """
        using global::Nanorm;
        namespace TestNamespace
        {
            partial class Sample : IDataRecordMapper<global::TestNamespace.Sample>
            {
                public static global::TestNamespace.Sample Map(global::System.Data.IDataRecord dataRecord) =>
                    new()
                    {
                        // 12 members
                        A = dataRecord.GetNullableByte("A"),
                        B = dataRecord.GetNullableInt16("B"),
                        C = dataRecord.GetNullableInt32("C"),
                        D = dataRecord.GetNullableInt64("D"),
                        E = dataRecord.GetNullableFloat("E"),
                        F = dataRecord.GetNullableDouble("F"),
                        G = dataRecord.GetNullableDecimal("G"),
                        H = dataRecord.GetNullableString("H"),
                        I = dataRecord.GetNullableBoolean("I"),
                        J = dataRecord.GetNullableGuid("J"),
                        K = dataRecord.GetNullableChar("K"),
                        L = dataRecord.GetNullableDateTime("L"),
                    };
            }
        }
        
        """;
}