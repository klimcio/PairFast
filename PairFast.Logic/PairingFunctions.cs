namespace PairFast.Logic;

public static class PairingFunctions
{     
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
