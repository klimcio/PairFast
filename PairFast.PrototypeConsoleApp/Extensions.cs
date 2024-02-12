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
        List<PairCompared> compared = new();
        var template = "{0} (0) vs {1} (1) : ";

        foreach (var pair in pairs)
        {
            Console.Write(template, pair.Left, pair.Right);
            var comparison = Console.ReadLine();

            if (comparison == "0") 
                compared.Add(new PairCompared(pair.Left, pair.Right, true));
            else
                compared.Add(new PairCompared(pair.Left, pair.Right, false));
        }

        return compared;
    }

    public static IDictionary<string, int> InterpretResults(this IEnumerable<PairCompared> pairs) 
        => PairFastLogic.InterpretResults(pairs);

    public static void ViewResults(this IDictionary<string, int> pairs)
    {
        Console.WriteLine();
        foreach(var pair in pairs.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{pair.Key} ({pair.Value})");
        }
    }
}