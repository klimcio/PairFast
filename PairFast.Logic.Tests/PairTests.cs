namespace PairFast.Logic.Tests;

[TestFixture]
public class PairTests
{
    [Test]
    public void Each_pair_of_items_is_considered_unique()
    {
        Pair? pair = Pair.New("apples", "oranges");

        pair!.Equals(Pair.New("apples", "oranges")).Should().BeTrue();
        pair!.Equals(Pair.New("oranges", "apples")).Should().BeTrue();
    }

    [Test]
    public void You_cannot_create_an_item_with_two_same_items() 
        => Pair.New("apples", "apples").Should().BeNull();
}