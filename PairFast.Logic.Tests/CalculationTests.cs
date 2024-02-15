namespace PairFast.Logic.Tests;

[TestFixture]
public class CalculationTests
{
    [Test]
    public void Basic_calculation_no_modifier() 
        => InterpretingResultsFunctions.CalculatePercentage(13, 15).Should().BeApproximately(0.86, 0.1);

    [Test]
    public void Basic_calculation_with_modifier() 
        => InterpretingResultsFunctions.CalculatePercentage(8, 15, 0.02).Should().BeApproximately(0.55, 0.1);
}
