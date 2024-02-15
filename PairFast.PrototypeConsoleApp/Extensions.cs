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
        => PairingFunctions.PairItems(items);

    public static IEnumerable<PairCompared> CompareItems(this IEnumerable<Pair> pairs)
    {
        List<PairCompared> compared = new();
        var template = "{0} (0) vs {1} (1) : ";

        foreach (var pair in pairs)
        {
            Console.Write(template, pair.Left, pair.Right);
            var comparison = Console.ReadLine();
            
            compared.Add(new PairCompared(pair.Left, pair.Right, comparison == "0"));
        }

        return compared;
    }

    public static PairComparisonResults InterpretResults(this IEnumerable<PairCompared> pairs) 
        => InterpretingResultsFunctions.InterpretResults(pairs);

    public static void ViewResults(this PairComparisonResults pairs)
    {
        Console.WriteLine();
        foreach(var pair in pairs.Ranking)
            Console.WriteLine(pair.ToString());
    }
}