using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.Sqlite;
using Nanorm.IntegrationTests.Utils;

namespace Nanorm.IntegrationTests;

[SuppressMessage(
    "ReSharper",
    "ConvertToConstant.Local",
    Justification = "Must be converted to `SqliteInterpolatedStringHandler`"
)]
[SuppressMessage(
    "ReSharper",
    "SuggestVarOrType_BuiltInTypes",
    Justification = "Must be converted to `SqliteInterpolatedStringHandler`"
)]
public sealed class SqliteTests : IDisposable
{
    private readonly SqliteConnection _connection;

    public SqliteTests()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.ExecuteAsync(SqliteEnsureDb.CreateTables);
    }

    [Fact]
    public async Task ValidateByte()
    {
        byte expected = 69;
        var actual = await SqliteQueries.CreateByteAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateShort()
    {
        short expected = 69;
        var actual = await SqliteQueries.CreateShortAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateInt()
    {
        int expected = 69;
        var actual = await SqliteQueries.CreateIntAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateLong()
    {
        long expected = 69;
        var actual = await SqliteQueries.CreateLongAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateFloat()
    {
        float expected = 69.420f;
        var actual = await SqliteQueries.CreateFloatAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateDouble()
    {
        double expected = 69.420d;
        var actual = await SqliteQueries.CreateDoubleAsync(_connection, expected);
        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateDecimal()
    {
        decimal expected = 69.420m;
        var actual = await SqliteQueries.CreateDecimalAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateString()
    {
        var expected = "Some string, I don't know";
        var actual = await SqliteQueries.CreateStringAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateBool(bool expected)
    {
        var actual = await SqliteQueries.CreateBoolAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateGuid()
    {
        var expected = Guid.Parse("43c7ee03-b038-4c50-9b78-2a03b224ebf6");
        var actual = await SqliteQueries.CreateGuidAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateChar()
    {
        var expected = 'f';
        var actual = await SqliteQueries.CreateCharAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Fact]
    public async Task ValidateDateTime()
    {
        var expected = DateTime.Now;
        var actual = await SqliteQueries.CreateDateTimeAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableByte(bool isNull)
    {
        byte? expected = isNull
            ? null
            : 69;
        
        var actual = await SqliteQueries.CreateNullableByteAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableShort(bool isNull)
    {
        short? expected = isNull
            ? null
            : 69;

        var actual = await SqliteQueries.CreateNullableShortAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(69)]
    public async Task ValidateNullableInt(int? expected)
    {
        var actual = await SqliteQueries.CreateNullableIntAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableLong(bool isNull)
    {
        long? expected = isNull
            ? null
            : 69;

        var actual = await SqliteQueries.CreateNullableLongAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(69.420f)]
    public async Task ValidateNullableFloat(float? expected)
    {
        var actual = await SqliteQueries.CreateNullableFloatAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(69.420d)]
    public async Task ValidateNullableDouble(double? expected)
    {
        var actual = await SqliteQueries.CreateNullableDoubleAsync(_connection, expected);
        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableDecimal(bool isNull)
    {
        decimal? expected = isNull
            ? null
            : 69.420m;

        var actual = await SqliteQueries.CreateNullableDecimalAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("Some string, I don't know")]
    public async Task ValidateNullableString(string? expected)
    {
        var actual = await SqliteQueries.CreateNullableStringAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableBool(bool? expected)
    {
        var actual = await SqliteQueries.CreateNullableBoolAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableGuid(bool isNull)
    {
        Guid? expected = isNull
            ? null
            : Guid.Parse("43c7ee03-b038-4c50-9b78-2a03b224ebf6");

        var actual = await SqliteQueries.CreateNullableGuidAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(null)]
    [InlineData('f')]
    public async Task ValidateNullableChar(char? expected)
    {
        var actual = await SqliteQueries.CreateNullableCharAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ValidateNullableDateTime(bool isNull)
    {
        DateTime? expected = isNull
            ? null
            : DateTime.Now;

        var actual = await SqliteQueries.CreateNullableDateTimeAsync(_connection, expected);

        Assert.Equal(expected, actual!.Val);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}