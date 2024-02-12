namespace PairFast.Logic.Tests;

[TestFixture]
public class InterpretingResultsTests
{
    private IDictionary<string, int> interpretations;

    [SetUp]
    public void Setup()
    {
        List<PairCompared> comparisons = new()
        {
            new PairCompared("apples", "oranges", true),        //apples
            new PairCompared("apples", "plums", false),         //plums
            new PairCompared("oranges", "plums", true),         //oranges
        };

        interpretations = PairFastLogic.InterpretResults(comparisons);
    }

    [Test]
    public void Apples_get_one_point()
        => interpretations["apples"].Should().Be(1);

    [Test]
    public void Oranges_get_one_point()
        => interpretations["oranges"].Should().Be(1);

    [Test]
    public void Plums_get_two_points()
        => interpretations["plums"].Should().Be(1);
}