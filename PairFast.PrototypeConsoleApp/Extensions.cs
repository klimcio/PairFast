using PairFast.Logic;

namespace PairFast.PrototypeConsoleApp;

internal static class Extensions
{
    public static IEnumerable<string> CollectItems()
    {
        List<string> items = new();
        string? input;

        Console.WriteLine("Add new item (hit Enter after each one, hit Enter without any data to go to the next step");

        do
        {
            Console.Write(">> ");
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (items.Contains(input))
                continue;

            items.Add(input);
        }
        while (!string.IsNullOrWhiteSpace(input));

        return items;
    }

    public static IEnumerable<Pair> PairItems(this IEnumerable<string> items) 
        => PairFastLogic.PairItems(items);

    public static IEnumerable<PairCompared> CompareItems(this IEnumerable<Pair> pairs)
    {
        throw new NotImplementedException();
    }

    public static IDictionary<string, int> InterpretResults(this IEnumerable<PairCompared> pairs) 
        => PairFastLogic.InterpretResults(pairs);

    public static void ViewResults(this IDictionary<string, int> pairs)
    {
        throw new NotImplementedException();
    }

}