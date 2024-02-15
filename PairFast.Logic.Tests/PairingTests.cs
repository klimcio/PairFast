namespace PairFast.Logic.Tests;

[TestFixture]
public class PairingTests
{
    private IEnumerable<Pair> pairs;

    [SetUp]
    public void Setup()
    {
        List<string> list = new()
        {
            "apples", "oranges", "plums"
        };

        pairs = PairingFunctions.PairItems(list);
    }

    [Test]
    public void List_contains_only_the_distinct_pairs()
    {
        pairs.Count().Should().Be(3);
        pairs.Any(x => x.Equals(Pair.New("apples", "oranges")!)).Should().BeTrue();
        pairs.Any(x => x.Equals(Pair.New("apples", "plums")!)).Should().BeTrue();
        pairs.Any(x => x.Equals(Pair.New("oranges", "plums")!)).Should().BeTrue();
    }
}