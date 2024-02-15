namespace PairFast.Logic.Tests;

[TestFixture]
public class WhatIfSomeItemsGetTheSameGradeTests
{
    private const string mp = "mp";
    private const string bo = "bo";
    private const string sl = "sl";
    private const string ac = "ac";
    private const string mr = "mr";
    private const string s13 = "s13";
    private const string o = "o";
    private const string ts = "ts";
    private const string ss = "ss";
    private const string fee = "fee";
    private const string bd2 = "bd2";
    private const string feth = "feth";
    private const string xc2 = "xc2";
    private const string xc3 = "xc3";
    private const string totk = "totk";

    private readonly List<PairCompared> comparisons = new()
    {
        new PairCompared(mp, bo, true),
        new PairCompared(mp, sl, true),
        new PairCompared(mp, ac, false),
        new PairCompared(mp, mr, true),
        new PairCompared(mp, s13, false),
        new PairCompared(mp, o, true),
        new PairCompared(mp, ts, true),
        new PairCompared(mp, ss, true),
        new PairCompared(mp, fee, true),
        new PairCompared(mp, bd2, true),
        new PairCompared(mp, feth, true),
        new PairCompared(mp, xc2, true),
        new PairCompared(mp, xc3, true),
        new PairCompared(mp, totk, true),

        new PairCompared(bo, sl, false),
        new PairCompared(bo, ac, false),
        new PairCompared(bo, mr, true),
        new PairCompared(bo, s13, false),
        new PairCompared(bo, o, true),
        new PairCompared(bo, ts, true),
        new PairCompared(bo, ss, true),
        new PairCompared(bo, fee, false),
        new PairCompared(bo, bd2, false),
        new PairCompared(bo, feth, true),
        new PairCompared(bo, xc3, true),
        new PairCompared(bo, totk, true),
        new PairCompared(bo, xc2, true),

        new PairCompared(sl, ac, false),
        new PairCompared(sl, mr, true),
        new PairCompared(sl, s13, false),
        new PairCompared(sl, o, true),
        new PairCompared(sl, ts, true),
        new PairCompared(sl, ss, true),
        new PairCompared(sl, fee, false),
        new PairCompared(sl, bd2, false),
        new PairCompared(sl, feth, true),
        new PairCompared(sl, xc3, true),
        new PairCompared(sl, totk, true),
        new PairCompared(sl, xc2, false),

        new PairCompared(ac, mr, true),
        new PairCompared(ac, s13, false),
        new PairCompared(ac, o, true),
        new PairCompared(ac, ts, true),
        new PairCompared(ac, ss, true),
        new PairCompared(ac, fee, false),
        new PairCompared(ac, bd2, false),
        new PairCompared(ac, feth, true),
        new PairCompared(ac, xc3, true),
        new PairCompared(ac, totk, true),
        new PairCompared(ac, xc2, false),

        new PairCompared(mr, s13, false),
        new PairCompared(mr, o, true),
        new PairCompared(mr, ts, true),
        new PairCompared(mr, ss, true),
        new PairCompared(mr, fee, false),
        new PairCompared(mr, bd2, false),
        new PairCompared(mr, feth, true),
        new PairCompared(mr, xc3, true),
        new PairCompared(mr, totk, true),
        new PairCompared(mr, xc2, false),

        new PairCompared(s13, o, true),
        new PairCompared(s13, ts, true),
        new PairCompared(s13, ss, true),
        new PairCompared(s13, fee, false),
        new PairCompared(s13, bd2, false),
        new PairCompared(s13, feth, true),
        new PairCompared(s13, xc3, true),
        new PairCompared(s13, totk, true),
        new PairCompared(s13, xc2, false),

        new PairCompared(o, ts, false),
        new PairCompared(o, ss, true),
        new PairCompared(o, fee, false),
        new PairCompared(o, bd2, false),
        new PairCompared(o, feth, false),
        new PairCompared(o, xc3, true),
        new PairCompared(o, totk, true),
        new PairCompared(o, xc2, false),

        new PairCompared(ts, ss, true),
        new PairCompared(ts, fee, false),
        new PairCompared(ts, bd2, false),
        new PairCompared(ts, feth, false),
        new PairCompared(ts, xc3, true),
        new PairCompared(ts, totk, true),
        new PairCompared(ts, xc2, false),

        new PairCompared(ss, fee, false),
        new PairCompared(ss, bd2, false),
        new PairCompared(ss, feth, false),
        new PairCompared(ss, xc3, true),
        new PairCompared(ss, totk, true),
        new PairCompared(ss, xc2, false),

        new PairCompared(fee, bd2, true),
        new PairCompared(fee, feth, true),
        new PairCompared(fee, xc3, true),
        new PairCompared(fee, totk, true),
        new PairCompared(fee, xc2, true),

        new PairCompared(bd2, feth, true),
        new PairCompared(bd2, xc3, true),
        new PairCompared(bd2, totk, true),
        new PairCompared(bd2, xc2, false),

        new PairCompared(feth, xc3, true),
        new PairCompared(feth, totk, true),
        new PairCompared(feth, xc2, false),

        new PairCompared(xc3, totk, false),
        new PairCompared(xc3, xc2, false),

        new PairCompared(totk, xc2, false)
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
        interpreted[fee]?.VoteCount.Should().Be(13);
        interpreted[mp]?.VoteCount.Should().Be(12);
        interpreted[s13]?.VoteCount.Should().Be(11);
        interpreted[bd2]?.VoteCount.Should().Be(11);
        interpreted[xc2]?.VoteCount.Should().Be(11);
        interpreted[ac]?.VoteCount.Should().Be(10);
        interpreted[bo]?.VoteCount.Should().Be(8);
        interpreted[sl]?.VoteCount.Should().Be(8);
        interpreted[mr]?.VoteCount.Should().Be(6);
        interpreted[feth]?.VoteCount.Should().Be(5);
        interpreted[ts]?.VoteCount.Should().Be(4);
        interpreted[o]?.VoteCount.Should().Be(3);
        interpreted[ss]?.VoteCount.Should().Be(2);
        interpreted[totk]?.VoteCount.Should().Be(1);
        interpreted[xc3]?.VoteCount.Should().Be(0);
    }

    [Test]
    public void Checking_percentage()
    {
        interpreted[fee]?.Percentage.AsString().Should().Be("0.87");
        interpreted[mp]?.Percentage.AsString().Should().Be("0.80");
        interpreted[s13]?.Percentage.AsString().Should().Be("0.73", because: "although vote count was the same, it was possible to have order based on data we have");
        interpreted[bd2]?.Percentage.AsString().Should().Be("0.74", because: "although vote count was the same, it was possible to have order based on data we have");
        interpreted[xc2]?.Percentage.AsString().Should().Be("0.75", because: "although vote count was the same, it was possible to have order based on data we have");
        interpreted[ac]?.Percentage.AsString().Should().Be("0.67");
        interpreted[bo]?.Percentage.AsString().Should().Be("0.53", because: "although vote count was the same, it was possible to have order based on data we have");
        interpreted[sl]?.Percentage.AsString().Should().Be("0.54", because: "although vote count was the same, it was possible to have order based on data we have");
        interpreted[mr]?.Percentage.AsString().Should().Be("0.40");
        interpreted[feth]?.Percentage.AsString().Should().Be("0.33");
        interpreted[ts]?.Percentage.AsString().Should().Be("0.27");
        interpreted[o]?.Percentage.AsString().Should().Be("0.20");
        interpreted[ss]?.Percentage.AsString().Should().Be("0.13");
        interpreted[totk]?.Percentage.AsString().Should().Be("0.07");
        interpreted[xc3]?.Percentage.Should().Be(0);
    }
}
