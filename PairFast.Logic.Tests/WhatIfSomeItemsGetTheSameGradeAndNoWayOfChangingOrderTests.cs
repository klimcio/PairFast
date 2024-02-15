namespace PairFast.Logic.Tests;

[TestFixture]
public class WhatIfSomeItemsGetTheSameGradeAndNoWayOfChangingOrderTests
{
    private const string akc = "kdp";
    private const string bp = "bl";
    private const string rm = "rm";
    private const string gdt = "gdt";
    private const string mpp = "mpp";
    private const string fup = "fpp";
    private const string gc = "gc";
    private const string css = "css";
    private const string tch = "tch";

    private readonly List<PairCompared> comparisons = new()
    {
        new PairCompared(akc, bp, true),
        new PairCompared(akc, rm, true),
        new PairCompared(akc, gdt, false),
        new PairCompared(akc, mpp, false),
        new PairCompared(akc, fup, false),
        new PairCompared(akc, gc, true),
        new PairCompared(akc, css, false),
        new PairCompared(akc, tch, false),

        new PairCompared(bp, rm, false),
        new PairCompared(bp, gdt, false),
        new PairCompared(bp, mpp, false),
        new PairCompared(bp, fup, false),
        new PairCompared(bp, gc, true),
        new PairCompared(bp, css, false),
        new PairCompared(bp, tch, true),

        new PairCompared(rm, gdt, false),
        new PairCompared(rm, mpp, false),
        new PairCompared(rm, fup, false),
        new PairCompared(rm, gc, true),
        new PairCompared(rm, css, false),
        new PairCompared(rm, tch, false),

        new PairCompared(gdt, mpp, false),
        new PairCompared(gdt, fup, false),
        new PairCompared(gdt, gc, true),
        new PairCompared(gdt, css, false),
        new PairCompared(gdt, tch, false),

        new PairCompared(mpp, fup, false),
        new PairCompared(mpp, gc, true),
        new PairCompared(mpp, css, true),
        new PairCompared(mpp, tch, true),

        new PairCompared(fup, gc, true),
        new PairCompared(fup, css, false),
        new PairCompared(fup, tch, true),

        new PairCompared(gc, css, false),
        new PairCompared(gc, tch, false),

        new PairCompared(css, tch, true)
    };

    private PairComparisonResults interpreted;

    [SetUp]
    public void SetUp()
    {
        interpreted = InterpretingResultsFunctions.InterpretResults(comparisons);
    }

    [Test]
    public void Checking_vote_count()
    {
        interpreted[akc]?.VoteCount.Should().Be(3);
        interpreted[bp]?.VoteCount.Should().Be(2);
        interpreted[rm]?.VoteCount.Should().Be(2);
        interpreted[gdt]?.VoteCount.Should().Be(4);
        interpreted[mpp]?.VoteCount.Should().Be(7);
        interpreted[fup]?.VoteCount.Should().Be(7);
        interpreted[gc]?.VoteCount.Should().Be(0);
        interpreted[css]?.VoteCount.Should().Be(7);
        interpreted[tch]?.VoteCount.Should().Be(4);
    }

    [Test]
    public void Checking_percentage()
    {
        interpreted[akc]?.Percentage.AsString().Should().Be("0.33");
        interpreted[bp]?.Percentage.AsString().Should().Be("0.22", because: "1. no stalemate");
        interpreted[rm]?.Percentage.AsString().Should().Be("0.23", because: "1. no stalemate");
        interpreted[gdt]?.Percentage.AsString().Should().Be("0.44", because: "2. no stalemate");
        interpreted[mpp]?.Percentage.AsString().Should().Be("0.79", because: "3. stalemate result for the same votecount");
        interpreted[fup]?.Percentage.AsString().Should().Be("0.79", because: "3. stalemate result for the same votecount");
        interpreted[gc]?.Percentage.AsString().Should().Be("0.00");
        interpreted[css]?.Percentage.AsString().Should().Be("0.79", because: "3. stalemate result for the same votecount");
        interpreted[tch]?.Percentage.AsString().Should().Be("0.45", because: "2. no stalemate");
    }
}