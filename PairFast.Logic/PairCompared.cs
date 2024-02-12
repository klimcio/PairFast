namespace PairFast.Logic;

public record PairCompared(string Left, string Right, bool LeftWins)
{
    public bool Contains(string item)
        => Left == item || Right == item;

    public bool? DidItemWon(string item)
    {
        if (Left == item)
            return LeftWins;
        else if (Right == item)
            return !LeftWins;
        else
            return null;
    }
}
