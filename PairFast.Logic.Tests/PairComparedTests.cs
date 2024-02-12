namespace PairFast.Logic.Tests;

[TestFixture]
public class PairComparedTests
{
    [Test]
    public void Pair_object_contains_item_as_left()
        => new PairCompared("apples", "plums", true).Contains("apples").Should().BeTrue();

    [Test]
    public void Pair_object_contains_item_as_right()
        => new PairCompared("apples", "plums", true).Contains("plums").Should().BeTrue();

    [Test]
    public void Pair_object_does_not_contain_item()
        => new PairCompared("apples", "plums", true).Contains("pineapples").Should().BeFalse();

    [Test]
    public void Pair_object_returns_true_when_item_of_interest_being_left_won()
        => new PairCompared("apples", "plums", true).DidItemWon("apples").Should().BeTrue();

    [Test]
    public void Pair_object_returns_true_when_item_of_interest_being_right_won()
        => new PairCompared("apples", "plums", false).DidItemWon("plums").Should().BeTrue();

    [Test]
    public void Pair_object_returns_false_when_item_of_interest_being_left_lost()
        => new PairCompared("apples", "plums", false).DidItemWon("apples").Should().BeFalse();

    [Test]
    public void Pair_object_returns_false_when_item_of_interest_being_right_lost()
        => new PairCompared("apples", "plums", true).DidItemWon("plums").Should().BeFalse();

    [Test]
    public void Pair_object_returns_null_when_item_of_interest_is_not_in_comparison()
        => new PairCompared("apples", "plums", true).DidItemWon("pineapples").Should().BeNull();
}
