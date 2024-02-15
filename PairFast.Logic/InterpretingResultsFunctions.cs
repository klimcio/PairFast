namespace PairFast.Logic;

public static class InterpretingResultsFunctions
{
    public static PairComparisonResults InterpretResults(IEnumerable<PairCompared> comparisons)
    {
        List<ItemAfterComparison> phase1results = comparisons.InterpretResultsBasically();
        int allItemsCount = phase1results.Count;

        List<ItemAfterComparison> phase2results = new();

        foreach (var group in phase1results.GroupBy(x => x.Percentage).OrderByDescending(x => x.Key))
        {
            if (group.Count() == 1)
            {
                phase2results.Add(group.First());
                continue;
            }

            var itemNames = group.Select(x => x.ItemName).ToArray();
            var comparedPairs = comparisons.ExtractSubgroup(itemNames);

            var subgroupInterpretations = comparedPairs?.InterpretResultsBasically() ?? new List<ItemAfterComparison>();

            foreach (var item in subgroupInterpretations)
            {
                var originalItem = phase1results.First(x => x.ItemName == item.ItemName);

                double percentage = CalculatePercentage(originalItem.VoteCount, allItemsCount, item.VoteCount * 0.01);
                phase2results.Add(
                    new ItemAfterComparison(item.ItemName, originalItem.VoteCount, allItemsCount, percentage)
                );
            }
        }

        return PairComparisonResults.New(phase2results);
    }

    private static List<ItemAfterComparison> InterpretResultsBasically(this IEnumerable<PairCompared> comparisons)
    {
        var items = comparisons.Select(x => x.Left).Union(comparisons.Select(x => x.Right)).Distinct();
        var itemsCount = items.Count();

        List<ItemAfterComparison> phase1results = new();
        foreach (var item in items)
        {
            var ofInterest = comparisons
                .Select(x => x.DidItemWon(item))
                .Where(x => x != null)
                .Count(x => x!.Value);

            phase1results.Add(new ItemAfterComparison(item, ofInterest, itemsCount, CalculatePercentage(ofInterest, itemsCount)));
        }

        return phase1results;
    }

    internal static double CalculatePercentage(int voteCount, int allItemsCount, double modifier = 0.00)
    {
        return ((double)voteCount / (double)allItemsCount) + modifier;
    }

    private static IEnumerable<PairCompared> ExtractSubgroup(this IEnumerable<PairCompared> compareds, string[] items)
    {
        List<PairCompared> returnList = new();

        foreach (var pair in compareds)
        {
            if (items.Contains(pair.Left) && items.Contains(pair.Right))
            {
                returnList.Add(pair);
            }
        }

        return returnList;
    }
}
