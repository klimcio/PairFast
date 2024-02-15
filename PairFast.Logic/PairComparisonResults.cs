namespace PairFast.Logic;

public record ItemAfterComparison(string ItemName, int VoteCount, int AllItemsCount, double Percentage)
{
    public override string ToString() 
        => $"{ItemName} ({VoteCount}/{AllItemsCount}={Percentage})";
}

public class PairComparisonResults
{
    private readonly IEnumerable<ItemAfterComparison> comparisons;

    private PairComparisonResults(IEnumerable<ItemAfterComparison> comparisons)
    {
        this.comparisons = comparisons;
    }

    public ItemAfterComparison? this[string index] 
        => comparisons.FirstOrDefault(x => x.ItemName == index);

    public List<ItemAfterComparison> Ranking 
        => comparisons.OrderByDescending(x => x.Percentage).ToList();

    public static PairComparisonResults New(IEnumerable<ItemAfterComparison> comparisons)
    {
        return new PairComparisonResults(comparisons);
    }
}
