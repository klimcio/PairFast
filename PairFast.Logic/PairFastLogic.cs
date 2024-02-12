namespace PairFast.Logic;

public static class PairFastLogic
{
    public static IDictionary<string, int> InterpretResults(IEnumerable<PairCompared> comparisons)
    {
        Dictionary<string, int> results = new();
        var items = comparisons.Select(x => x.Left).Union(comparisons.Select(x => x.Right)).Distinct();

        foreach(var item in items)
        {
            var ofInterest = comparisons
                .Select(x => x.DidItemWon(item))
                .Where(x => x != null)
                .Count(x => x!.Value);

            results.Add(item, ofInterest);
        }

        return results;
    }

    public static IEnumerable<Pair> PairItems(IEnumerable<string> items)
    {
        List<Pair> result = new();

        foreach(var i in items)
        {
            foreach(var j in items)
            {
                Pair? newPair = Pair.New(i, j);

                if (newPair == null)
                    continue;

                if (result.Any(x => x.Equals(newPair)))
                    continue;

                result.Add(newPair);
            }
        }

        return result;
    }
}
