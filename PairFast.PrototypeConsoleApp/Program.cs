
using PairFast.Logic;

namespace PairFast.PrototypeConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Extensions.CollectItems()
            .PairItems()
            .CompareItems()
            .InterpretResults()
            .ViewResults();
    }

}

internal static class Extensions
{
    public static IEnumerable<string> CollectItems()
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<Pair> PairItems(this IEnumerable<string> items) 
        => PairFastLogic.PairItems(items);

    public static IEnumerable<PairCompared> CompareItems(this IEnumerable<Pair> pairs)
    {
        throw new NotImplementedException();
    }

    public static IDictionary<string, int> InterpretResults(this IEnumerable<PairCompared> pairs)
    {
        throw new NotImplementedException();
    }

    public static void ViewResults(this IDictionary<string, int> pairs)
    {
        throw new NotImplementedException();
    }

}