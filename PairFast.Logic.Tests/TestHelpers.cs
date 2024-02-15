using System.Globalization;

namespace PairFast.Logic.Tests;

internal static class TestHelpers
{
    public static string AsString(this double value) 
        => value.ToString("0.00", CultureInfo.InvariantCulture);
}
